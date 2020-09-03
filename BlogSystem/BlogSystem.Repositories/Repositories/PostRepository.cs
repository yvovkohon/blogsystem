using BlogSystem.Models;
using BlogSystem.Models.Common;
using BlogSystem.Models.Models;
using BlogSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSystem.Repositories.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogSystemContext _context;

        public PostRepository(BlogSystemContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add a new post
        /// </summary>
        /// <param name="post">Post details</param>
        /// <returns>Post Id</returns>
        public async Task<int> AddPost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return post.Id;
        }

        /// <summary>
        /// Get the post by Id
        /// </summary>
        /// <param name="id">Post id</param>
        /// <returns>Post details</returns>
        public async Task<Post> GetPost(int id)
        {
            return await _context.Posts.Where(x => x.Id == id).Include(p => p.Comments).AsNoTracking().FirstOrDefaultAsync();
        }

        /// <summary>
        /// Get all posts ordered by date
        /// </summary>
        /// <returns>Posts</returns>
        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            return await _context.Posts.Include(x => x.Comments).OrderBy(p => p.PostDate).ToListAsync();
        }

        /// <summary>
        /// Delete the post by Id
        /// </summary>
        /// <param name="id">Post id</param>
        /// <returns>Is post removed</returns>
        public async Task<DeletePostResult> DeletePost(int id)
        {
            var post = await _context.Posts.Where(x => x.Id == id).Include(p => p.Comments).FirstOrDefaultAsync();
            if (post == null)
            {
                return DeletePostResult.NotFound;
            }

            if (post.Comments.Any())
            {
                return DeletePostResult.HasComments;
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return DeletePostResult.Succeed;
        }
    }
}