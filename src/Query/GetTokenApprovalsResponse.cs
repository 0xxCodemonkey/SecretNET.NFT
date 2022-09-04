namespace SecretNET.SNIP721;

public class GetTokenApprovalsResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("token_approvals")]
    public GetTokenApprovalsResponse_Result Result { get; set; }

}

public class GetTokenApprovalsResponse_Result
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
    /// List of approvals for this token.
    /// </summary>
    /// <value>The token approvals.</value>
    [JsonProperty("token_approvals")]
    public Snip721Approval[] TokenApprovals { get; set; }

}

