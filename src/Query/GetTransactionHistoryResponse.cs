namespace SecretNET.SNIP721;

public class GetTransactionHistoryResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("transaction_history")]
    public GetTransactionHistoryResponse_Result Result { get; set; }
}

public class GetTransactionHistoryResponse_Result
{
    /// <summary>
    /// The total number of transactions that involve the specified address.
    /// </summary>
    /// <value>The total.</value>
    [JsonProperty("total")]
    public ulong Total { get; set; }

    /// <summary>
    /// List of transactions in reverse chronological order that involve the specified address.
    /// </summary>
    /// <value>The TXS.</value>
    [JsonProperty("txs")]
    public Tx[] Txs { get; set; }

}
