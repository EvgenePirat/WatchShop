using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WatchShop_Core.Domain.Entities.Identities;
using WatchShop_Core.Domain.RepositoryContracts;
using WatchShop_Core.Exceptions;
using WatchShop_Core.Models.Users.Request;
using WatchShop_Core.Models.Users.Response;
using WatchShop_Core.ServiceContracts;

namespace WatchShop_Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);

            if(user == null)
            {
                throw new UserArgumentException("User for delete with id not found");
            }

            await _userManager.DeleteAsync(user);

            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();

            var modelUsers = _mapper.Map<IEnumerable<UserModel>>(users);

            foreach (var user in users)
            {
                var modelUser = modelUsers.SingleOrDefault(m => m.Id == user.Id);
                modelUser.Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
            }
            return modelUsers;
        }

        public async Task<UserModel> GetUserByIdAsync(Guid id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);

            if (user == null)
            {
                throw new UserArgumentException("User by id not found");
            }

            var userModel = _mapper.Map<UserModel>(user);

            userModel.Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

            return userModel;
        }

        public async Task<UserModel> GetUserByUserNameAsync(string username)
        {
            var user = await _unitOfWork.UserRepository.FindUserByUserNameAsync(username);

            if (user == null)
            {
                throw new UserArgumentException("User by username not found");
            }

            var userModel = _mapper.Map<UserModel>(user);

            userModel.Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

            return userModel;
        }

        public async Task<bool> SetSubscriptionLetters(string email, bool isActive)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.GetByEmailAsync(email);

                if (user == null)
                {
                    throw new UserArgumentException("User by email not found");
                }

                if(user.IsSubscriptionLetters != isActive)
                {
                    user.IsSubscriptionLetters = isActive;

                    await _userManager.UpdateAsync(user);

                    await _unitOfWork.SaveAsync();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new UserArgumentException(ex.Message);
            }
        }

        public async Task<UserModel> UpdateUserAsync(Guid id, UpdateUserModel model)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);

            if (user == null)
            {
                throw new UserArgumentException("User by id not found for update");
            }

            user.UserName = model.UserName;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.City = model.City;
            user.Email = model.Email;

            if(await _userManager.IsInRoleAsync(user, model.Role.ToString()) == false)
            {
                var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
                await _userManager.RemoveFromRoleAsync(user, role);
                await _userManager.AddToRoleAsync(user, model.Role.ToString());
            }
            
            await _userManager.UpdateAsync(user);

            await _unitOfWork.SaveAsync();

            var modelUser = _mapper.Map<UserModel>(user);

            modelUser.Role = model.Role.ToString();

            return modelUser;
        }
    }
}
