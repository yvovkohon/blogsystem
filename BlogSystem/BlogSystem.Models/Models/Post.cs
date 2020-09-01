using System;
using System.Collections.Generic;

namespace BlogSystem.Models.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }  

        public DateTime PostDate { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}