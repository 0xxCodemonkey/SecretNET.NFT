namespace SecretNET.NFT;

public class MintNftClonesRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("mint_nft_clones")]
    public MintNftClonesRequest_Payload Payload { get; set; }

    /// <summary>
    /// Creates NFT mint options
    /// </summary>
    /// <param name="tokenId">Identifier for the token to be minted.</param>
    /// <param name="publicMetadata">The metadata that is publicly viewable.</param>
    /// <param name="privateMetadata">The metadata that is viewable only by the token owner and addresses the owner has whitelisted.</param>
    /// <param name="serialNumber">The SerialNumber for this token.</param>
    /// <param name="memo">Memo for the mint tx that is only viewable by addresses involved in the mint (minter, owner).</param>
    /// <param name="royaltyInfo">RoyaltyInfo for this token</param>
    /// <param name="transferable">True if the minted token should be transferable (default: true).</param>
    /// <returns></returns>
    public static MintNftRequest Create(
        string tokenId = null,
        Metadata? publicMetadata = null,
        Metadata? privateMetadata = null,
        SerialNumberType? serialNumber = null,
        string? memo = null,
        RoyaltyInfo? royaltyInfo = null,
        bool? transferable = null
        )
    {
        var request = new MintNftRequest();
        request.Payload = new Mint()
        {
            TokenId = tokenId,
            PublicMetadata = publicMetadata,
            PrivateMetadata = privateMetadata,
            SerialNumber = serialNumber,
            Memo = memo,
            RoyaltyInfo = royaltyInfo,
            Transferable = transferable
        };

        return request;
    }
}

public class MintNftClonesRequest_Payload
{
    /// <summary>
    /// Optional ID used to track mint run numbers over multiple calls.
    /// </summary>
    [JsonProperty("mint_run_id")]
    public string? MintRunId { get; set; }

    [JsonProperty("quantity")]
    public uint Quantity { get; set; }

    /// <summary>
    /// Address of the owner of the minted token.
    /// Value If Omitted: env.message.sender
    /// </summary>
    [JsonProperty("owner")]
    public string? Owner { get; set; }

    /// <summary>
    /// The metadata that is publicly viewable.
    /// </summary>
    [JsonProperty("public_metadata")]
    public Metadata? PublicMetadata { get; set; }

    /// <summary>
    /// The metadata that is viewable only by the token owner and addresses the owner has whitelisted.
    /// </summary>
    [JsonProperty("private_metadata")]
    public Metadata? PrivateMetadata { get; set; }

    /// <summary>
    /// RoyaltyInfo for this token
    /// Value If Omitted: default RoyaltyInfo
    /// 
    /// Setting royalties for a non-transferable token has no purpose, because it can never be transferred as part of a sale, 
    /// so this implementation will not store any RoyaltyInfo for non-transferable tokens.
    /// </summary>
    [JsonProperty("royalty_info")]
    public RoyaltyInfo? RoyaltyInfo { get; set; }

    /// <summary>
    /// Memo for the mint tx that is only viewable by addresses involved in the mint (minter, owner).
    /// </summary>
    [JsonProperty("memo")]
    public string? Memo { get; set; }

    /// <summary>
    /// True if the minted token should be transferable (default: true).
    /// </summary>
    [JsonProperty("transferable")]
    public bool? Transferable { get; set; } = true;

    /// <summary>
    /// An ignored string that can be used to maintain constant message length.
    /// </summary>
    [JsonProperty("padding")]
    public string? Padding { get; set; }
}


