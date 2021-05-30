using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TakeApi.Models
{
    public class RepositoryModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("full_name")]
        public string Name { get; set; }
        [JsonPropertyName("owner")]
        public Owner owner { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("created_at")]
        public DateTime Created_at { get; set; }
        [JsonPropertyName("language")]
        public string Language { get; set; }
    }

    public class Owner
    {
      
        public string avatar_url { get; set; }
       
    }
}
