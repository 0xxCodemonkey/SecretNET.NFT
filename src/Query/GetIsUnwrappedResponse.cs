namespace SecretNET.NFT;

public class GetIsUnwrappedResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("is_unwrapped")]
    public GetIsUnwrappedResponse_Result Result { get; set; }

}

public class GetIsUnwrappedResponse_Result
{
    /// <summary>
    /// True if the token is unwrapped (or sealed metadata is not enabled).
    /// </summary>
    /// <value><c>true</c> if [token is unwrapped]; otherwise, <c>false</c>.</value>
    [JsonProperty("token_is_unwrapped")]
    public bool TokenIsUnwrapped { get; set; }

}

