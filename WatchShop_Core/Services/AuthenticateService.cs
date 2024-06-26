﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using WatchShop_Core.Domain.Entities.Identities;
using WatchShop_Core.Domain.RepositoryContracts;
using WatchShop_Core.Exceptions;
using WatchShop_Core.Models.Auth.Request;
using WatchShop_Core.Models.Auth.Response;
using WatchShop_Core.Models.Enums;
using WatchShop_Core.ServiceContracts;

namespace WatchShop_Core.Services
{
    public class AuthenticateService : IAuthenticateService
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtService _jwtService;

        public AuthenticateService(IJwtService jwtService, IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
        }

        public async Task<AuthResponseModel> LoginAsync(LoginModel model)
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();

            var userExist = users.FirstOrDefault(u => u.UserName.ToLower() == model.Username.ToLower());

            bool isValid = await _userManager.CheckPasswordAsync(userExist, model.Password);

            if (isValid == false)
                throw new AuthArgumentException("Username or password is incorrect");

            AuthResponseModel authResponseModel = new AuthResponseModel()
            {
                Username = userExist.UserName,

                Token = await _jwtService.CreateJwtTokenAsync(userExist)
            };

            return authResponseModel;
        }

        public async Task<RegisterResponseModel> RegisterAsync(RegisterModel model)
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();

            var userExist = users.FirstOrDefault(u => u.UserName.ToLower() == model.Username.ToLower());

            if (userExist != null)
                throw new AuthArgumentException("User with username already exist");

            ApplicationUser user = new ApplicationUser()
            {
                UserName = model.Username,
                CreateAccountDate = model.CreateAccountDate,
                Email = model.Email,
            };

            try
            {
                var result = await _userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                    throw new AuthArgumentException("User creation failed!");

                await CreateRoleIfNotExist();

                await _userManager.AddToRoleAsync(user, model.Role.ToString());

                return new RegisterResponseModel() { Id = user.Id, Username = user.UserName, Email = user.Email, Role = model.Role.ToString() };
            }
            catch (Exception ex)
            {
                throw new AuthArgumentException(ex.Message);
            }
        }

        private async Task CreateRoleIfNotExist()
        {
            if (!_roleManager.RoleExistsAsync(RoleEnum.Client.ToString()).GetAwaiter().GetResult())
            {
                await _roleManager.CreateAsync(new ApplicationRole() { Name = RoleEnum.Client.ToString() });
                await _roleManager.CreateAsync(new ApplicationRole() { Name = RoleEnum.Admin.ToString() });
            }
        }
    }
}
