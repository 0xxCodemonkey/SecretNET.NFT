namespace SecretNET.SNIP721;

public class GetVerifyTransferApprovalRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("verify_transfer_approval")]
    public GetVerifyTransferApprovalRequest_Payload Payload { get; set; }


    /// <summary>
    /// Initializes a new instance of the <see cref="GetVerifyTransferApprovalRequest"/> class.
    /// </summary>
    /// <param name="tokenIds">List of tokens to check for the address' transfer approval.</param>
    /// <param name="address">Address being checked for transfer approval.</param>
    /// <param name="viewingKey">The address' viewing key.</param>
    public GetVerifyTransferApprovalRequest(string[] tokenIds, string address, string viewingKey)
    {
        Payload = new GetVerifyTransferApprovalRequest_Payload
        {
            TokenIds = tokenIds,
            Address = address,
            ViewingKey = viewingKey
        };
    }
}

public class GetVerifyTransferApprovalRequest_Payload
{
    /// <summary>
    /// List of tokens to check for the address' transfer approval.
    /// </summary>
    /// <value>The token ids.</value>
    [JsonProperty("token_ids")]
    public string[] TokenIds { get; set; }

    /// <summary>
    /// Address being checked for transfer approval.
    /// </summary>
    /// <value>The address.</value>
    [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
    public string Address { get; set; }

    /// <summary>
    /// The token owner's viewing key.
    /// </summary>
    /// <value>The viewing key.</value>
    [JsonProperty("viewing_key", NullValueHandling = NullValueHandling.Ignore)]
    public string ViewingKey { get; set; }

}