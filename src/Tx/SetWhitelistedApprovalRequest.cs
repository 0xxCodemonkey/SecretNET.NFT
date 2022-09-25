namespace SecretNET.NFT;

public class SetWhitelistedApprovalRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("set_whitelisted_approval")]
    public SetWhitelistedApprovalRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SetWhitelistedApprovalRequest" /> class.
    /// </summary>
    /// <param name="address">Address to grant or revoke approval to/from.</param>
    /// <param name="tokenId">If supplying either approve_token or revoke_token access, the token whose privacy is being set.</param>
    /// <param name="viewOwner">Grant or revoke everyone's permission to view the ownership of a token/inventory.</param>
    /// <param name="viewPrivateMetadata">Grant or revoke everyone's permission to view the private metadata of a token/inventory.</param>
    /// <param name="transfer">Grant or revoke the address' permission to transfer a token/inventory.</param>
    /// <param name="expires">The expiration of this transfer approval.
    /// Can be a blockheight, time, or never.
    /// Of type =&gt; "never" | {"at_height": 999999} | {"at_time":999999}</param>
    /// <param name="padding">The padding.</param>
    public SetWhitelistedApprovalRequest(string address, string tokenId = null, AccessLevel? viewOwner = null, AccessLevel? viewPrivateMetadata = null, AccessLevel? transfer = null, object expires = null, string padding = null)
    {
        Payload = new SetWhitelistedApprovalRequest_Payload
        {
            TokenId = tokenId,
            ViewOwner = viewOwner,
            ViewPrivateMetadata = viewPrivateMetadata,
            Transfer = transfer,
            Expires = expires,
            Padding = padding
        };
    }
}

public class SetWhitelistedApprovalRequest_Payload
{
    /// <summary>
    /// Address to grant or revoke approval to/from (not optional).
    /// </summary>
    [JsonProperty("address")]
    public string Address { get; set; }

    /// <summary>
    /// If supplying either approve_token or revoke_token access, the token whose privacy is being set.
    /// </summary>
    [JsonProperty("token_id")]
    public string TokenId { get; set; }

    /// <summary>
    /// Gets or sets the view owner.
    /// </summary>
    /// <value>The view owner.</value>
    [JsonProperty("view_owner", NullValueHandling = NullValueHandling.Ignore)]
    public AccessLevel? ViewOwner { get; set; }

    /// <summary>
    /// Gets or sets the view private metadata.
    /// </summary>
    /// <value>The view private metadata.</value>
    [JsonProperty("view_private_metadata", NullValueHandling = NullValueHandling.Ignore)]
    public AccessLevel? ViewPrivateMetadata { get; set; }

    [JsonProperty("transfer", NullValueHandling = NullValueHandling.Ignore)]
    public AccessLevel? Transfer { get; set; }

    /// <summary>
    /// The expiration of this transfer approval. 
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


