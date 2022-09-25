namespace SecretNET.NFT;

public class GetBatchNftDossierRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("batch_nft_dossier")]
    public GetBatchNftDossierRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GetBatchNftDossierRequest" /> class.
    /// </summary>
    /// <param name="tokenId">The IDs of the token being queried.</param>
    /// <param name="viewerInfo">The viewer information.</param>
    /// <param name="includeExpired">if set to <c>true</c> [include expired].</param>
    public GetBatchNftDossierRequest(string[] tokenIds, ViewerInfo viewerInfo = null, bool? includeExpired = null)
    {
        Payload = new GetBatchNftDossierRequest_Payload
        {
            TokenIds = tokenIds,
            ViewerInfo = viewerInfo,
            IncludeExpired = includeExpired
        };
    }
}

public class GetBatchNftDossierRequest_Payload
{
    /// <summary>
    /// The IDs of the token being queried (not optional).
    /// </summary>
    /// <value>The token identifier.</value>
    [JsonProperty("token_ids")]
    public string[] TokenIds { get; set; }

    /// <summary>
    /// The address and viewing key performing this query.
    /// </summary>
    /// <value>The address.</value>
    [JsonProperty("viewer", NullValueHandling = NullValueHandling.Ignore)]
    public ViewerInfo ViewerInfo { get; set; }

    /// <summary>
    /// True if expired transfer approvals should be included in the response.
    /// </summary>
    /// <value>The include expired.</value>
    [JsonProperty("include_expired")]
    public bool? IncludeExpired { get; set; }
}