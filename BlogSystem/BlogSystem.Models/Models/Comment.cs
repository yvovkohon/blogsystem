using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogSystem.Models.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("PostId")]
        public int PostId { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime CommentDate { get; set; }
    }
}