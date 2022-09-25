namespace SecretNET.NFT;

public class GetTransactionHistoryRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("transaction_history")]
    public GetTransactionHistoryRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GetTransactionHistoryRequest"/> class.
    /// </summary>
    /// <param name="address">The address whose transaction history is being queried.</param>
    /// <param name="viewingKey">The address' viewing key.</param>
    /// <param name="page">The page number to display, where the first transaction shown skips the page * page_size most recent transactions.</param>
    /// <param name="pageSize">Number of transactions to return.</param>
    public GetTransactionHistoryRequest(string address, string viewingKey, int? page = null, int? pageSize = null)
    {
        Payload = new GetTransactionHistoryRequest_Payload
        {
            Address = address,
            ViewingKey = viewingKey,
            Page = page,
            PageSize = pageSize
        };
    }
}

public class GetTransactionHistoryRequest_Payload
{
    /// <summary>
    /// The address whose transaction history is being queried.
    /// </summary>
    /// <value>The address.</value>
    [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
    public string Address { get; set; }

    /// <summary>
    /// The address' viewing key.
    /// </summary>
    /// <value>The viewing key.</value>
    [JsonProperty("viewing_key", NullValueHandling = NullValueHandling.Ignore)]
    public string ViewingKey { get; set; }

    /// <summary>
    /// The page number to display, where the first transaction shown skips the page * page_size most recent transactions.
    /// </summary>
    /// <value>The page.</value>
    [JsonProperty("page")]
    public int? Page { get; set; }

    /// <summary>
    /// Number of transactions to return.
    /// </summary>
    /// <value>The size of the page.</value>
    [JsonProperty("page_size")]
    public int? PageSize { get; set; }

}