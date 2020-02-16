using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZuzexTestProject.UI.ViewModels
{
    public class PostsListVM
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("annotation")]
        public string Annotation { get; set; }

        [JsonPropertyName("date_posted")]
        public DateTime DatePosted { get; set; }

        [JsonPropertyName("date_refreshed")]
        public DateTime? DateRefreshed { get; set; }
    }
}
