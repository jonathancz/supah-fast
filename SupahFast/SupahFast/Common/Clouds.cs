using System.Text.Json.Serialization;

namespace SupahFast.Infrastructure;

public class Clouds
{
    [JsonPropertyName("all")]
    public int All { get; set; }
}