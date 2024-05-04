using AutoMapper;
using Moq;
using WatchShop_Core.Domain.Entities;
using WatchShop_Core.Domain.RepositoryContracts;
using WatchShop_Core.Exceptions;
using WatchShop_Core.Models.Comments.Request;
using WatchShop_Core.Models.Comments.Response;
using WatchShop_Core.Services;

namespace WatchShopTest.ModuleTests.CoreTest
{
    public class CommentServiceTests
    {
        [Fact]
        public async Task CreateCommentAsync_ValidInput_ReturnsCreatedComment()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mapperMock = new Mock<IMapper>();

            var createCommentModel = new CreateCommentModel
            {
                Comment = "Top Watch",
                Grade = 4
            };

            var watchComment = new WatchComment
            {
                Comment = "Top Watch",
                Grade = 4
            };

            unitOfWorkMock.Setup(uow => uow.WatchCommentRepository).Returns(Mock.Of<IWatchCommentRepository>());
            unitOfWorkMock.Setup(uow => uow.SaveAsync());
            mapperMock.Setup(mapper => mapper.Map<WatchComment>(createCommentModel)).Returns(watchComment);
            mapperMock.Setup(mapper => mapper.Map<CommentModel>(watchComment)).Returns(new CommentModel() { Comment = "Top Watch", Grade = 4 });

            var service = new CommentService(unitOfWorkMock.Object, mapperMock.Object);

            // Act
            var result = await service.CreateCommentAsync(createCommentModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(createCommentModel.Grade, result.Grade);
            Assert.Equal(createCommentModel.Comment, result.Comment);
        }

        [Fact]
        public async Task DeleteCommentAsync_CommentExists_DeletesComment()
        {
            // Arrange
            var commentId = Guid.NewGuid();
            var commentToDelete = new WatchComment { Id = commentId, Comment = "Top watch shop", Grade = 4 };

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var watchCommentRepositoryMock = new Mock<IWatchCommentRepository>();
            var mapperMock = new Mock<IMapper>();

            unitOfWorkMock.Setup(uow => uow.WatchCommentRepository).Returns(watchCommentRepositoryMock.Object);
            watchCommentRepositoryMock.Setup(repo => repo.GetByIdAsync(commentId)).ReturnsAsync(commentToDelete);

            var commentService = new CommentService(unitOfWorkMock.Object, mapperMock.Object);

            // Act
            await commentService.DeleteCommentAsync(commentId);

            // Assert
            watchCommentRepositoryMock.Verify(repo => repo.Delete(commentToDelete), Times.Once);
            unitOfWorkMock.Verify(uow => uow.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteCommentAsync_CommentNotExists_ThrowsException()
        {
            // Arrange
            var commentId = Guid.NewGuid();

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var watchCommentRepositoryMock = new Mock<IWatchCommentRepository>();
            var mapperMock = new Mock<IMapper>();

            unitOfWorkMock.Setup(uow => uow.WatchCommentRepository).Returns(watchCommentRepositoryMock.Object);
            watchCommentRepositoryMock.Setup(repo => repo.GetByIdAsync(commentId)).ReturnsAsync((WatchComment)null);

            var commentService = new CommentService(unitOfWorkMock.Object, mapperMock.Object);

            // Act & Assert
            await Assert.ThrowsAsync<CommentWatchArgumentException>(() => commentService.DeleteCommentAsync(commentId));
        }

        [Fact]
        public async Task GetAllCommentsAsync_ReturnsAllComments()
        {
            // Arrange
            var comments = new List<WatchComment>
            {
                new WatchComment { Comment = "Top Watch", Grade = 5 },
                new WatchComment { Comment = "Bad request", Grade = 3 },
            };

            var commentModels = comments.Select(c => new CommentModel { Comment = "Top Watch", Grade = 3 });

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var watchCommentRepositoryMock = new Mock<IWatchCommentRepository>();
            var mapperMock = new Mock<IMapper>();

            unitOfWorkMock.Setup(uow => uow.WatchCommentRepository).Returns(watchCommentRepositoryMock.Object);
            watchCommentRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(comments);
            mapperMock.Setup(mapper => mapper.Map<IEnumerable<CommentModel>>(comments)).Returns(commentModels);

            var commentService = new CommentService(unitOfWorkMock.Object, mapperMock.Object);

            // Act
            var result = await commentService.GetAllCommentsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(comments.Count, result.Count());
        }

        [Fact]
        public async Task GetCommentByIdAsync_ExistingId_ReturnsCommentModel()
        {
            // Arrange
            var commentId = Guid.NewGuid();
            var comment = new WatchComment { Id = commentId, Comment = "Top Watch", Grade = 5 };
            var commentModel = new CommentModel { Id = commentId, Comment = "Top Watch", Grade = 5 };

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var watchCommentRepositoryMock = new Mock<IWatchCommentRepository>();
            var mapperMock = new Mock<IMapper>();

            unitOfWorkMock.Setup(uow => uow.WatchCommentRepository).Returns(watchCommentRepositoryMock.Object);
            watchCommentRepositoryMock.Setup(repo => repo.GetByIdAsync(commentId)).ReturnsAsync(comment);
            mapperMock.Setup(mapper => mapper.Map<CommentModel>(comment)).Returns(commentModel);

            var commentService = new CommentService(unitOfWorkMock.Object, mapperMock.Object);

            // Act
            var result = await commentService.GetCommentByIdAsync(commentId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(commentModel.Id, result.Id);
            Assert.Equal(commentModel.Grade, result.Grade);
            Assert.Equal(commentModel.Comment, result.Comment);
        }

        [Fact]
        public async Task GetCommentsByUserNameAsync_ExistingUserName_ReturnsCommentModels()
        {
            // Arrange
            var username = "admin";
            var comments = new List<WatchComment>
            {
                new WatchComment { Comment = "Top Watch", Grade = 5 },
                new WatchComment { Comment = "Bad request", Grade = 3 },
            };
            var commentModels = comments.Select(comment => new CommentModel { Comment = "Top Watch", Grade = 5 });

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var watchCommentRepositoryMock = new Mock<IWatchCommentRepository>();
            var mapperMock = new Mock<IMapper>();

            unitOfWorkMock.Setup(uow => uow.WatchCommentRepository).Returns(watchCommentRepositoryMock.Object);
            watchCommentRepositoryMock.Setup(repo => repo.FindCommentByUserNameAsync(username)).ReturnsAsync(comments);
            mapperMock.Setup(mapper => mapper.Map<IEnumerable<CommentModel>>(comments)).Returns(commentModels);

            var commentService = new CommentService(unitOfWorkMock.Object, mapperMock.Object);

            // Act
            var result = await commentService.GetCommentsByUserNameAsync(username);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(commentModels.Count(), result.Count());
        }

        [Fact]
        public async Task GetCommentsByWatchNameModelAsync_ExistingWatchNameModel_ReturnsCommentModels()
        {
            // Arrange
            var nameModel = "testModel";
            var comments = new List<WatchComment>
            {
                new WatchComment { Comment = "Top Watch", Grade = 5 },
                new WatchComment { Comment = "Bad request", Grade = 3 },
            };

            var commentModels = comments.Select(comment => new CommentModel { Comment = "Top Watch", Grade = 5 });

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var watchCommentRepositoryMock = new Mock<IWatchCommentRepository>();
            var mapperMock = new Mock<IMapper>();

            unitOfWorkMock.Setup(uow => uow.WatchCommentRepository).Returns(watchCommentRepositoryMock.Object);
            watchCommentRepositoryMock.Setup(repo => repo.FindCommentByWatchNameModelAsync(nameModel)).ReturnsAsync(comments);
            mapperMock.Setup(mapper => mapper.Map<IEnumerable<CommentModel>>(comments)).Returns(commentModels);

            var commentService = new CommentService(unitOfWorkMock.Object, mapperMock.Object);

            // Act
            var result = await commentService.GetCommentsByWatchNameModelAsync(nameModel);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(commentModels.Count(), result.Count());
        }
    }
}
