using BlogSystem.Models.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlogSystem.Models.DTO
{
    /// <summary>
    /// Post
    /// </summary>
    public class PostDto
    {
        private DateTime _postDate;

        /// <summary>
        /// Title
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Text
        /// </summary>
        [Required]
        public string Text { get; set; }

        /// <summary>
        /// Post date
        /// </summary>
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime PostDate
        {
            get => _postDate;

            set
            {
                if (value > DateTime.Now)
                {
                    throw new InvalidOperationException(ExceptionMessages.DateCanNotBeInTheFuture);
                }
            }
        }
    }
}