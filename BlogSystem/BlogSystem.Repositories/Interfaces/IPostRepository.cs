using BlogSystem.Models.Common;
using BlogSystem.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogSystem.Repositories.Interfaces
{
    public interface IPostRepository
    {
        /// <summary>
        /// Add a new post
        /// </summary>
        /// <param name="post">Post details</param>
        /// <returns>Post Id</returns>
        Task<int> AddPost(Post post);

        /// <summary>
        /// Get the post by Id
        /// </summary>
        /// <param name="id">Post id</param>
        /// <returns>Post details</returns>
        Task<Post> GetPost(int id);

        /// <summary>
        /// Get all posts ordered by date
        /// </summary>
        /// <returns>Posts</returns>
        Task<IEnumerable<Post>> GetAllPosts();

        /// <summary>
        /// Delete the post by Id
        /// </summary>
        /// <param name="id">Post id</param>
        /// <returns>Is post removed</returns>
        Task<DeletePostResult> DeletePost(int id);
    }
}