namespace SecretNET.SNIP721;

public class GetTokensResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("token_list")]
    public GetTokensResponse_Result Result { get; set; }
}

public class GetTokensResponse_Result
{
    /// <summary>
    /// A list of token IDs owned by the specified owner.
    /// </summary>
    /// <value>The tokens.</value>
    [JsonProperty("tokens")]
    public string[] Tokens { get; set; }

}
