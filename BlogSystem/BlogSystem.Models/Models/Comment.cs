using System;

namespace BlogSystem.Models.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        public string Text { get; set; }

        public DateTime CommentDate { get; set; }

        public Post Post { get; set; }
    }
}