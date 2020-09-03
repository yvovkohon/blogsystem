using BlogSystem.Models.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlogSystem.Models.DTO
{
    /// <summary>
    /// Comment
    /// </summary>
    public class CommentDto
    {
        private DateTime _commentDate;

        /// <summary>
        /// Post id
        /// </summary>
        [Required]
        public int PostId { get; set; }

        /// <summary>
        /// Text
        /// </summary>
        [Required]
        public string Text { get; set; }

        /// <summary>
        /// Comment date
        /// </summary>
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CommentDate
        {
            get => _commentDate;

            set {
                if (value > DateTime.Now)
                {
                    throw new InvalidOperationException(ExceptionMessages.DateCanNotBeInTheFuture);
                } }
        }
    }
}