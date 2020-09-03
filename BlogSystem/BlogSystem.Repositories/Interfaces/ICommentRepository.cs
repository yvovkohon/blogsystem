using BlogSystem.Models.Models;
using System.Threading.Tasks;

namespace BlogSystem.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        /// <summary>
        /// Add a new comment
        /// </summary>
        /// <param name="comment">Comment details</param>
        /// <returns>Comment Id</returns>
        Task<int> AddComment(Comment comment);
    }
}