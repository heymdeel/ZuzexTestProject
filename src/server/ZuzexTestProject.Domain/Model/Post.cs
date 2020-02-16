using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ZuzexTestProject.Domain.Model
{
    public class Post
    {
        public int ID { get; set; }

        [Required, StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }

        [Required, StringLength(500, MinimumLength = 3)]
        public string Annotation { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime DatePosted { get; set; }

        public DateTime DateRefreshed { get; set; }
    }
}
