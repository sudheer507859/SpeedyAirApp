using System.Text.Json.Serialization;

public class OrderData
{
    [JsonPropertyName("destination")]
    public string Destination { get; set; }

}