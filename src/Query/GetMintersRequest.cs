namespace SecretNET.SNIP721;

public class GetMintersRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("minters")]
    public object Payload { get; set; } = new object();
}


