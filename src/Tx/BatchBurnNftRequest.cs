namespace SecretNET.NFT;

public class BatchBurnNftRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("batch_burn_nft")]
    public BatchBurnNftRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="BatchBurnNftRequest" /> class.
    /// </summary>
    /// <param name="burns">List of Burn objects to process.</param>
    /// <param name="padding">The padding.</param>
    public BatchBurnNftRequest(BatchBurn[] burns, string padding = null)
    {
        Payload = new BatchBurnNftRequest_Payload
        {
            Burns = burns,
            Padding = padding
        };
    }
}

public class BatchBurnNftRequest_Payload
{
    /// <summary>
    /// List of Burn objects to process (not optional).
    /// </summary>
    [JsonProperty("burns")]
    public BatchBurn[] Burns { get; set; }

    /// <summary>
    /// An ignored string that can be used to maintain constant message length.
    /// </summary>
    [JsonProperty("padding", NullValueHandling = NullValueHandling.Ignore)]
    public string Padding { get; set; }
}

public class BatchBurn
{
    /// <summary>
    /// ID of the token to be transferred (not optional).
    /// </summary>
    [JsonProperty("token_id")]
    public string[] TokenIds { get; set; }

    /// <summary>
    /// Memo for the transfer transaction that is only viewable by addresses involved in the transfer (recipient, sender, previous owner).
    /// </summary>
    [JsonProperty("memo")]
    public string Memo { get; set; }

}

