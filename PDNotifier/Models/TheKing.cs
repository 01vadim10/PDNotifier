using System.Text.Json.Serialization;

namespace PDNotifier.Models
{
    public class TheKing
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("nm")]
        public string Name { get; set; }
        [JsonPropertyName("cty")]
        public string Country { get; set; }
        [JsonPropertyName("hse")]
        public string House { get; set; }
        [JsonPropertyName("yrs")]
        public string Years { get; set; }
    }
}
