using System.Threading.Tasks;
using BlogSystem.Models.DTO;

namespace BlogSystem.Services.Interfaces
{
    public interface ICommentService
    {
        /// <summary>
        /// Add a new comment
        /// </summary>
        /// <param name="comment">Comment details</param>
        /// <returns>Comment Id</returns>
        Task<int> AddComment(CommentDto comment);
    }
}