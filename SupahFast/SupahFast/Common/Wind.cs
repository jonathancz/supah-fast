using System.Text.Json.Serialization;

namespace SupahFast.Infrastructure;

public class Wind
{
    [JsonPropertyName("speed")]
    public double Speed { get; set; }

    [JsonPropertyName("deg")]
    public int Deg { get; set; }
}