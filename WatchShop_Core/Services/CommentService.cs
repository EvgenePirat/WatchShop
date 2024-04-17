using AutoMapper;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Domain.RepositoryContracts;
using WatchShop_Core.Exceptions;
using WatchShop_Core.Models.Comments.Request;
using WatchShop_Core.Models.Comments.Response;
using WatchShop_Core.ServiceContracts;

namespace WatchShop_Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommentModel> CreateCommentAsync(CreateCommentModel model)
        {
            var commentToCreate = _mapper.Map<WatchComment>(model);

            _unitOfWork.WatchCommentRepository.Add(commentToCreate);

            await _unitOfWork.SaveAsync();

            return _mapper.Map<CommentModel>(commentToCreate);
        }

        public async Task DeleteCommentAsync(Guid id)
        {
            var commentToDelete = await _unitOfWork.WatchCommentRepository.GetByIdAsync(id);

            if (commentToDelete == null)
                throw new CommentWatchArgumentException($"Comment by id {id} not found for delete");

            _unitOfWork.WatchCommentRepository.Delete(commentToDelete);

            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<CommentModel>> GetAllCommentsAsync()
        {
            var comments = await _unitOfWork.WatchCommentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CommentModel>>(comments);
        }

        public async Task<CommentModel> GetCommentByIdAsync(Guid id)
        {
            var comment = await _unitOfWork.WatchCommentRepository.GetByIdAsync(id);

            if (comment == null)
                throw new CommentWatchArgumentException($"Comment by id {id} not found for delete");

            return _mapper.Map<CommentModel>(comment);
        }

        public async Task<IEnumerable<CommentModel>> GetCommentsByUserNameAsync(string username)
        {
            var comments = await _unitOfWork.WatchCommentRepository.FindCommentByUserNameAsync(username);

            if(comments.Count() == 0)
            {
                throw new CommentWatchArgumentException($"Comments by username not found");
            }

            return _mapper.Map<IEnumerable<CommentModel>>(comments);
        }

        public async Task<IEnumerable<CommentModel>> GetCommentsByWatchNameModelAsync(string nameModel)
        {
            var comments = await _unitOfWork.WatchCommentRepository.FindCommentByWatchNameModelAsync(nameModel);

            if (comments.Count() == 0)
            {
                throw new CommentWatchArgumentException($"Comments by watch nameModel {nameModel} not found");
            }

            return _mapper.Map<IEnumerable<CommentModel>>(comments);
        }

        public async Task<CommentModel> UpdateCommentAsync(Guid id, UpdateCommentModel model)
        {
            var commentToUpdate = await _unitOfWork.WatchCommentRepository.GetByIdAsync(id);

            if (commentToUpdate == null)
                throw new CommentWatchArgumentException($"Comment by id {id} not found for delete");

            commentToUpdate.Comment = model.Comment;
            commentToUpdate.Grade = model.Grade;

            _unitOfWork.WatchCommentRepository.Update(commentToUpdate);

            await _unitOfWork.SaveAsync();

            return _mapper.Map<CommentModel>(commentToUpdate);
        }
    }
}
