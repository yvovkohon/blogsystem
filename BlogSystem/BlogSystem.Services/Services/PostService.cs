using BlogSystem.Models.Common;
using BlogSystem.Models.DTO;
using BlogSystem.Models.Models;
using BlogSystem.Repositories.Interfaces;
using BlogSystem.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogSystem.Services.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        /// <summary>
        /// Add a new post
        /// </summary>
        /// <param name="post">Post details</param>
        /// <returns>Post Id</returns>
        public async Task<int> AddPost(PostDto postDto)
        {
            var post = new Post()
            {
                Title = postDto.Title,
                Text = postDto.Text,
                PostDate = postDto.PostDate
            };

            return await _postRepository.AddPost(post);
        }
        
        /// <summary>
        /// Get the post by Id
        /// </summary>
        /// <param name="id">Post id</param>
        /// <returns>Post details</returns>
        public async Task<Post> GetPost(int id)
        {
            return await _postRepository.GetPost(id);
        }

        /// <summary>
        /// Get all posts ordered by date
        /// </summary>
        /// <returns>Posts</returns>
        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            return await _postRepository.GetAllPosts();
        }

        /// <summary>
        /// Delete the post by Id
        /// </summary>
        /// <param name="id">Post id</param>
        /// <returns>Is post removed</returns>
        public async Task<DeletePostResult> DeletePost(int id)
        {
            return await _postRepository.DeletePost(id);
        }
    }
}