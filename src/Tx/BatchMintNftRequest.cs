namespace SecretNET.SNIP721;

public class BatchMintNftRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("batch_mint_nft")]
    public BatchMintNftRequest_Payload Payload { get; set; }

}

public class BatchMintNftRequest_Payload
{
    /// <summary>
    /// Identifier for the token to be minted.
    /// Value If Omitted: minting order number
    /// </summary>
    [JsonProperty("mints")]
    public Mint[] Mints { get; set; }    

    /// <summary>
    /// An ignored string that can be used to maintain constant message length.
    /// </summary>
    [JsonProperty("padding")]
    public string? Padding { get; set; }
}


