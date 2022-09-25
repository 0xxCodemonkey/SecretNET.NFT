namespace SecretNET.NFT;

public class MintNftRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("mint_nft")]
    public Mint Payload { get; set; }

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




