namespace SecretNET.NFT;

public class SetMetadataRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("set_metadata")]
    public SetMetadataRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SetMetadataRequest" /> class.
    /// </summary>
    /// <param name="tokenId">ID of the token whose metadata should be updated.</param>
    /// <param name="publicMetadata">The new public metadata for the token.</param>
    /// <param name="privateMetadata">The new private metadata for the token.</param>
    /// <param name="padding">An ignored string that can be used to maintain constant message length.</param>
    public SetMetadataRequest(string tokenId, Metadata? publicMetadata = null, Metadata? privateMetadata = null, string padding = null)
    {
        Payload = new SetMetadataRequest_Payload
        {
            TokenId = tokenId,
            PublicMetadata = publicMetadata,
            PrivateMetadata = privateMetadata,
            Padding = padding
        };
    }

}

public class SetMetadataRequest_Payload
{
    /// <summary>
    /// ID of the token whose metadata should be updated (not optional).
    /// </summary>
    [JsonProperty("token_id")]
    public string TokenId { get; set; }

    /// <summary>
    /// The new public metadata for the token.
    /// </summary>
    /// <value>The public metadata.</value>
    [JsonProperty("public_metadata", NullValueHandling = NullValueHandling.Ignore)]
    public Metadata? PublicMetadata { get; set; }

    /// <summary>
    /// The new private metadata for the token.
    /// </summary>
    /// <value>The private metadata.</value>
    [JsonProperty("private_metadata", NullValueHandling = NullValueHandling.Ignore)]
    public Metadata? PrivateMetadata { get; set; }

    /// <summary>
    /// An ignored string that can be used to maintain constant message length.
    /// </summary>
    [JsonProperty("padding", NullValueHandling = NullValueHandling.Ignore)]
    public string Padding { get; set; }
}


