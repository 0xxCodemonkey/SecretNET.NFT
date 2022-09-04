namespace SecretNET.SNIP721;

public class GetRoyaltyInfoResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("royalty_info")]
    public GetRoyaltyInfoResponse_Result Result { get; set; }

}

public class GetRoyaltyInfoResponse_Result
{
    /// <summary>
    /// The token or default RoyaltyInfo as per the request.
    /// </summary>
    /// <value>The royalty information.</value>
    [JsonProperty("royalty_info")]
    public RoyaltyInfo RoyaltyInfo { get; set; }

}

