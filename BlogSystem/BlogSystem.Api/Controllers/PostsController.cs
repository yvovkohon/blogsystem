using BlogSystem.Models.Common;
using BlogSystem.Models.DTO;
using BlogSystem.Models.Models;
using BlogSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogSystem.Api.Controllers
{
    /// <summary>
    /// Api to work with the posts
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly ILogger<PostsController> _logger;

        public PostsController(IPostService postService, ILogger<PostsController> logger)
        {
            _postService = postService;
            _logger = logger;
        }

        /// <summary>
        /// Add a new post
        /// </summary>
        /// <param name="post">Post details</param>
        /// <returns>Post Id</returns>
        /// <response code="200">Post was successfully added</response>
        /// <response code="400">Exception has been thrown</response>
        [HttpPost("add")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddPost(PostDto post)
        {
            try
            {
                var id = await _postService.AddPost(post);
                return Ok(id);
            }
            catch (Exception e)
            {
                _logger.LogError($"Method {ControllerContext.ActionDescriptor.DisplayName} has thrown exception", e.Message, e.StackTrace);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Get the post by Id
        /// </summary>
        /// <param name="id">Post id</param>
        /// <returns>Post details</returns>
        /// <response code="200">Returns post details</response>
        /// <response code="400">Exception has been thrown</response>
        /// <response code="404">Post was not found</response>
        [HttpGet("get/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Post))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPost(int id)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound();
                }

                var post = await _postService.GetPost(id);
                if (post == null) return NotFound();

                return Ok(post);
            }
            catch (Exception e)
            {
                _logger.LogError($"Method {ControllerContext.ActionDescriptor.DisplayName} has thrown exception", e.Message, e.StackTrace);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Get all posts ordered by date
        /// </summary>
        /// <returns>Posts</returns>
        /// <response code="200">Returns posts details</response>
        /// <response code="400">Exception has been thrown</response>
        [HttpGet("getAll")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Post>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllPosts()
        {
            try
            {
                var post = await _postService.GetAllPosts();
                return Ok(post);
            }
            catch (Exception e)
            {
                _logger.LogError($"Method {ControllerContext.ActionDescriptor.DisplayName} has thrown exception", e.Message, e.StackTrace);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Delete the post by Id
        /// </summary>
        /// <param name="id">Post id</param>
        /// <returns>Is post removed</returns>
        /// <response code="200">Post was successfully removed</response>
        /// <response code="400">Exception has been thrown</response>
        /// <response code="404">Post was not found</response>
        [HttpDelete("delete/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePost(int id)
        {
            var postResult = await _postService.DeletePost(id);

            switch (postResult)
            {
                case DeletePostResult.NotFound: return NotFound(id);
                case DeletePostResult.Succeed: return Ok();
                case DeletePostResult.HasComments: return BadRequest("Post can't be removed until it has comments");
                default: return Ok();
            }
        }
    }
}
