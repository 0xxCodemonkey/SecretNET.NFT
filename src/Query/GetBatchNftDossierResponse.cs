namespace SecretNET.NFT;

public class GetBatchNftDossierResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("batch_nft_dossier")]
    public GetBatchNftDossierResponse_Result Result { get; set; }

}

public class GetBatchNftDossierResponse_Result
{
    [JsonProperty("nft_dossiers")]
    public GetBatchNftDossierResponse_BatchNftDossierElement[] NftDossiers { get; set; }
}

public class GetBatchNftDossierResponse_BatchNftDossierElement
{
    /// <summary>
    /// Gets or sets the token identifier.
    /// </summary>
    /// <value>The token identifier.</value>
    [JsonProperty("token_id")]
    public string TokenId { get; set; }

    /// <summary>
    /// Address of the token's owner.
    /// </summary>
    /// <value><c>true</c> if owner; otherwise, <c>false</c>.</value>
    [JsonProperty("owner")]
    public string Owner { get; set; }

    /// <summary>
    /// The token's public metadata.
    /// </summary>
    /// <value>The public metadata.</value>
    [JsonProperty("public_metadata")]
    public Metadata PublicMetadata { get; set; }

    /// <summary>
    /// The token's private metadata.
    /// </summary>
    /// <value>The private metadata.</value>
    [JsonProperty("private_metadata")]
    public Metadata PrivateMetadata { get; set; }

    /// <summary>
    /// If the private metadata is not displayed, the corresponding error message.
    /// </summary>
    /// <value>The display private metadata error.</value>
    [JsonProperty("display_private_metadata_error")]
    public string DisplayPrivateMetadataError { get; set; }

    /// <summary>
    /// The token's RoyaltyInfo.
    /// </summary>
    /// <value>The royalty information.</value>
    [JsonProperty("royalty_info")]
    public RoyaltyInfo RoyaltyInfo { get; set; }

    /// <summary>
    /// The token's MintRunInfo.
    /// </summary>
    /// <value>The mint run information.</value>
    [JsonProperty("mint_run_info")]
    public MintRunInfo MintRunInfo { get; set; }

    /// <summary>
    /// True if this token is transferable.
    /// </summary>
    /// <value><c>null</c> if [transferable] contains no value, <c>true</c> if [transferable]; otherwise, <c>false</c>.</value>
    [JsonProperty("transferable")]
    public bool? Transferable { get; set; }

    /// <summary>
    /// False if this token's private metadata is sealed.
    /// </summary>
    /// <value><c>null</c> if [unwrapped] contains no value, <c>true</c> if [unwrapped]; otherwise, <c>false</c>.</value>
    [JsonProperty("unwrapped")]
    public bool? Unwrapped { get; set; }

    /// <summary>
    /// True if ownership is public for this token.
    /// </summary>
    /// <value><c>null</c> if [owner is public] contains no value, <c>true</c> if [owner is public]; otherwise, <c>false</c>.</value>
    [JsonProperty("owner_is_public")]
    public bool? OwnerIsPublic { get; set; }

    /// <summary>
    /// When public ownership expires for this token. 
    /// Can be a blockheight, time, or never.
    /// Of type => "never" | {"at_height": 999999} | {"at_time":999999}
    /// </summary>
    [JsonProperty("public_ownership_expiration")]
    public object PublicOwnershipExpiration { get; set; }

    /// <summary>
    /// True if private metadata is public for this token.
    /// </summary>
    /// <value><c>null</c> if [private metadata is public] contains no value, <c>true</c> if [private metadata is public]; otherwise, <c>false</c>.</value>
    [JsonProperty("private_metadata_is_public")]
    public bool? PrivateMetadataIsPublic { get; set; }

    /// <summary>
    /// When public display of private metadata expires. 
    /// Can be a blockheight, time, or never.
    /// Of type => "never" | {"at_height": 999999} | {"at_time":999999}
    /// </summary>
    [JsonProperty("private_metadata_is_public_expiration")]
    public object PrivateMetadataIsPublicExpiration { get; set; }

    /// <summary>
    /// List of approvals for this token.
    /// </summary>
    /// <value>The token approvals.</value>
    [JsonProperty("token_approvals")]
    public Snip721Approval[] TokenApprovals { get; set; }

    /// <summary>
    /// List of inventory-wide approvals for the token's owner.
    /// </summary>
    /// <value>The inventory approvals.</value>
    [JsonProperty("inventory_approvals")]
    public Snip721Approval[] InventoryApprovals { get; set; }
}

