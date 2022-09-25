namespace SecretNET.NFT;

public class GetInventoryApprovalsResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("inventory_approvals")]
    public GetInventoryApprovalsResponse_Result Result { get; set; }

}

public class GetInventoryApprovalsResponse_Result
{
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
    /// List of inventory-wide approvals for this address.
    /// </summary>
    /// <value>The approvals.</value>
    [JsonProperty("inventory_approvals")]
    public Snip721Approval[] Approvals { get; set; }

}

