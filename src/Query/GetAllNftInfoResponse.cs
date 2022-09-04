namespace SecretNET.SNIP721;

public class GetAllNftInfoResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("all_nft_info")]
    public GetAllNftInfoResponse_Result Result { get; set; }

}

public class GetAllNftInfoResponse_Result
{

    /// <summary>
    /// The token's owner and its transfer approvals if permitted to view this info.
    /// </summary>
    /// <value>The access.</value>
    [JsonProperty("access")]
    public GetAllNftInfoResponse_Access Access { get; set; }

    /// <summary>
    /// The token's public metadata.
    /// </summary>
    /// <value>The metadata.</value>
    [JsonProperty("info")]
    public Metadata Metadata { get; set; }

}

public class GetAllNftInfoResponse_Access
{
    /// <summary>
    /// Address of the token's owner.
    /// </summary>
    /// <value><c>true</c> if owner; otherwise, <c>false</c>.</value>
    [JsonProperty("owner")]
    public bool Owner { get; set; }

    /// <summary>
    /// List of approvals to transfer this token.
    /// </summary>
    /// <value>The approvals.</value>
    [JsonProperty("approvals")]
    public Approval[] Approvals { get; set; }

}

