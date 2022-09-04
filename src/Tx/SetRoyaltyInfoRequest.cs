namespace SecretNET.SNIP721;

public class SetRoyaltyInfoRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("set_royalty_info")]
    public SetRoyaltyInfoRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SetRoyaltyInfoRequest" /> class.
    /// </summary>
    /// <param name="tokenId">If no token_id is provided, SetRoyaltyInfo will update the contract's default RoyaltyInfo to the input, or delete it if no RoyaltyInfo is provided.</param>
    /// <param name="royaltyInfo">If no RoyaltyInfo is provided, it will delete the RoyaltyInfo and replace it with the contract's default RoyaltyInfo (if there is one).</param>
    /// <param name="padding">An ignored string that can be used to maintain constant message length.</param>
    public SetRoyaltyInfoRequest(string tokenId = null, RoyaltyInfo? royaltyInfo = null, string padding = null)
    {
        Payload = new SetRoyaltyInfoRequest_Payload
        {
            TokenId = tokenId,
            RoyaltyInfo = royaltyInfo
        };
    }

}

public class SetRoyaltyInfoRequest_Payload
{
    /// <summary>
    /// ID of the token whose metadata should be updated (not optional).
    /// </summary>
    [JsonProperty("token_id")]
    public string TokenId { get; set; }

    /// <summary>
    /// Gets or sets the royalty information.
    /// </summary>
    /// <value>The royalty information.</value>
    [JsonProperty("royalty_info")]
    public RoyaltyInfo? RoyaltyInfo { get; set; }

    /// <summary>
    /// An ignored string that can be used to maintain constant message length.
    /// </summary>
    [JsonProperty("padding", NullValueHandling = NullValueHandling.Ignore)]
    public string Padding { get; set; }
}


