﻿namespace SecretNET.NFT;

public class TransferNftResponse
{
    [JsonProperty("transfer_nft")]
    public SimpleStatusResponse_Result Result { get; set; }
}

