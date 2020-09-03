using BlogSystem.Models.DTO;
using BlogSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BlogSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly ILogger<CommentController> _logger;

        public CommentController(ICommentService commentService, ILogger<CommentController> logger)
        {
            _commentService = commentService;
            _logger = logger;
        }

        /// <summary>
        /// Add a new comment
        /// </summary>
        /// <param name="comment">Comment details</param>
        /// <returns>Comment Id</returns>
        /// <response code="200">Returns id for the newly created comment</response>
        /// <response code="400">Exception has been thrown</response>
        [HttpPost("add")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddComment(CommentDto comment)
        {
            try
            {
                var id = await _commentService.AddComment(comment);
                return Ok(id);
            }
            catch (Exception e)
            {
                _logger.LogError($"Method {ControllerContext.ActionDescriptor.DisplayName} has thrown exception", e.Message, e.StackTrace);
                return BadRequest(e.Message);
            }
        }
    }
}
