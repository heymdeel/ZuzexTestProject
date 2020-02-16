using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace ZuzexTestProject.Infrastructure.DTO
{
    public class CreatePostDTO
    {
        [JsonPropertyName("title")]
        [Required, StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }

        [JsonPropertyName("annotation")]
        [Required, StringLength(500, MinimumLength = 3)]
        public string Annotation { get; set; }

        [JsonPropertyName("content")]
        [Required]
        public string Content { get; set; }
    }
}
