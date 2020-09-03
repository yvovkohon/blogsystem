using BlogSystem.Models.DTO;
using BlogSystem.Models.Models;
using BlogSystem.Repositories.Interfaces;
using BlogSystem.Services.Interfaces;
using System.Threading.Tasks;

namespace BlogSystem.Services.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _repository;

        public CommentService(ICommentRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Add a new comment
        /// </summary>
        /// <param name="commentDto">Comment details</param>
        /// <returns>Comment Id</returns>
        public async Task<int> AddComment(CommentDto commentDto)
        {
            var comment = new Comment()
            {
                PostId = commentDto.PostId,
                Text = commentDto.Text,
                CommentDate = commentDto.CommentDate
            };

            return await _repository.AddComment(comment);
        }
    }
}