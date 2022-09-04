namespace SecretNET.SNIP721;

public class GetAllTokensResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("token_list")]
    public GetAllTokensResponse_Result Result { get; set; }

}

public class GetAllTokensResponse_Result
{
    /// <summary>
    /// A list of token IDs controlled by this contract.
    /// </summary>
    /// <value>The count.</value>
    [JsonProperty("tokens")]
    public string[] Count { get; set; }

}

