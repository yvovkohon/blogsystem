using BlogSystem.Models;
using BlogSystem.Models.Models;
using BlogSystem.Repositories.Interfaces;
using System.Threading.Tasks;
using BlogSystem.Models.Common;
using BlogSystem.Repositories.Resources;

namespace BlogSystem.Repositories.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly BlogSystemContext _context;

        public CommentRepository(BlogSystemContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add a new comment
        /// </summary>
        /// <param name="comment">Comment details</param>
        /// <returns>Comment Id</returns>
        public async Task<int> AddComment(Comment comment)
        {
            if (_context.Posts.Find(comment.PostId) == null)
            {
                throw new BlogSystemException(string.Format(ExceptionMessages.PostDoesNotExist, comment.PostId));
            }

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return comment.Id;
        }
    }
}