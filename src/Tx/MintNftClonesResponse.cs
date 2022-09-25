namespace SecretNET.NFT;

public class MintNftClonesResponse
{
    [JsonProperty("mint_nft_clones")]
    public MintNftClonesResponse_Result Result { get; set; }
}

public class MintNftClonesResponse_Result
{
    /// <summary>
    /// Token id of the first minted token.
    /// </summary>
    /// <value>The first minted.</value>
    [JsonProperty("first_minted")]
    public string FirstMinted { get; set; }

    /// <summary>
    /// Token id of the last minted token.
    /// </summary>
    /// <value>The last minted.</value>
    [JsonProperty("last_minted")]
    public string LastMinted { get; set; }
}


