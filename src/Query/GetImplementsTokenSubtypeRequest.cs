namespace SecretNET.SNIP721;

public class GetImplementsTokenSubtypeRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("implements_token_subtype")]
    public object Payload { get; set; } = new object();
}


