namespace SecretNET.SNIP721;

public class RegisterReceiveNftRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("register_receive_nft")]
    public RegisterReceiveNftRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterReceiveRequest" /> class.
    /// </summary>
    /// <param name="codeHash">A 32-byte hex encoded string, with the code hash of the receiver contract.</param>
    /// <param name="alsoImplementsBatchReceiveNft">true if the message sender contract also implements BatchReceiveNft so it can be informed that it was sent a list of tokens.</param>
    /// <param name="padding">Ignored string used to maintain constant-length messages.</param>
    public RegisterReceiveNftRequest(string codeHash, bool? alsoImplementsBatchReceiveNft = null, string? padding = null)
    {
        Payload = new RegisterReceiveNftRequest_Payload
        {
            CodeHash = codeHash,
            AlsoImplementsBatchReceiveNft = alsoImplementsBatchReceiveNft,
            Padding = padding
        };
    }
}

public class RegisterReceiveNftRequest_Payload
{
    /// <summary>
    /// A 32-byte hex encoded string, with the code hash of the receiver contract (not optional). 
    /// </summary>
    /// <value>The code hash.</value>
    [JsonProperty("code_hash")]
    public string CodeHash { get; set; }

    /// <summary>
    /// true if the message sender contract also implements BatchReceiveNft so it can be informed that it was sent a list of tokens.
    /// </summary>
    /// <value><c>null</c> if [also implements batch receive NFT] contains no value, <c>true</c> if [also implements batch receive NFT]; otherwise, <c>false</c>.</value>
    [JsonProperty("also_implements_batch_receive_nft")]
    public bool? AlsoImplementsBatchReceiveNft { get; set; }

    /// <summary>
    /// Ignored string used to maintain constant-length messages.
    /// </summary>
    /// <value>The padding.</value>
    [JsonProperty("padding")]
    public string? Padding { get; set; }
}
