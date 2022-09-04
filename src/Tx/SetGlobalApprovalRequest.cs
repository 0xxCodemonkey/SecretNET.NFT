namespace SecretNET.SNIP721;

public class SetGlobalApprovalRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("set_global_approval")]
    public SetGlobalApprovalRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SetGlobalApprovalRequest" /> class.
    /// </summary>
    /// <param name="tokenId">If supplying either approve_token or revoke_token access, the token whose privacy is being set.</param>
    /// <param name="viewOwner">Grant or revoke everyone's permission to view the ownership of a token/inventory.</param>
    /// <param name="viewPrivateMetadata">Grant or revoke everyone's permission to view the private metadata of a token/inventory.</param>
    /// <param name="expires">The expiration of this transfer approval.
    /// Can be a blockheight, time, or never.
    /// Of type => "never" | {"at_height": 999999} | {"at_time":999999}
    /// </param>
    /// <param name="padding">The padding.</param>
    public SetGlobalApprovalRequest(string tokenId = null, AccessLevel? viewOwner = null, AccessLevel? viewPrivateMetadata = null, object expires = null, string padding = null)
    {
        Payload = new SetGlobalApprovalRequest_Payload
        {
            TokenId = tokenId,
            ViewOwner = viewOwner,
            ViewPrivateMetadata = viewPrivateMetadata,
            Expires = expires,
            Padding = padding
        };
    }
}

public class SetGlobalApprovalRequest_Payload
{
    /// <summary>
    /// ID of the token to unwrap.
    /// </summary>
    [JsonProperty("token_id")]
    public string TokenId { get; set; }

    /// <summary>
    /// Grant or revoke everyone's permission to view the ownership of a token/inventory.
    /// </summary>
    /// <value>The view owner.</value>
    [JsonProperty("view_owner", NullValueHandling = NullValueHandling.Ignore)]
    public AccessLevel? ViewOwner { get; set; }

    /// <summary>
    /// Grant or revoke everyone's permission to view the private metadata of a token/inventory.
    /// </summary>
    /// <value>The view private metadata.</value>
    [JsonProperty("view_private_metadata", NullValueHandling = NullValueHandling.Ignore)]
    public AccessLevel? ViewPrivateMetadata { get; set; }

    /// <summary>
    /// Expiration of any approval granted in this message.
    /// Can be a blockheight, time, or never.
    /// Of type => "never" | {"at_height": 999999} | {"at_time":999999}
    /// </summary>
    [JsonProperty("expires", NullValueHandling = NullValueHandling.Ignore)]
    public object Expires { get; set; }

    /// <summary>
    /// An ignored string that can be used to maintain constant message length.
    /// </summary>
    [JsonProperty("padding", NullValueHandling = NullValueHandling.Ignore)]
    public string Padding { get; set; }
}


