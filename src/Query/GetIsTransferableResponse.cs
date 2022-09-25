namespace SecretNET.NFT;

public class GetIsTransferableResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("is_transferable")]
    public GetIsTransferableResponse_Result Result { get; set; }

}

public class GetIsTransferableResponse_Result
{
    /// <summary>
    /// True if the token is transferable.
    /// </summary>
    /// <value><c>true</c> if [token is unwrapped]; otherwise, <c>false</c>.</value>
    [JsonProperty("token_is_transferable")]
    public bool TokenIsTransferable { get; set; }

}

