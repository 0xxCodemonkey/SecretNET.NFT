namespace SecretNET.SNIP721;

public class GetContractConfigResponse
{
    /// <summary>
    /// Payload of the response.
    /// </summary>
    [JsonProperty("contract_config")]
    public GetContractConfigResponse_Result Result { get; set; }
}

public class GetContractConfigResponse_Result
{
    /// <summary>
    /// True if token IDs and the number of tokens controlled by the contract are public.
    /// </summary>
    [JsonProperty("token_supply_is_public")]
    public bool TokenSupplyIsPublic { get; set; }

    /// <summary>
    /// True if newly minted coins have public ownership as default.
    /// </summary>
    [JsonProperty("owner_is_public")]
    public bool OwnerIsPublic { get; set; }

    /// <summary>
    /// True if newly minted coins have sealed metadata.
    /// </summary>
    [JsonProperty("sealed_metadata_is_enabled")]
    public bool SealedMetadataIsEnabled { get; set; }

    /// <summary>
    /// True if sealed metadata remains private after unwrapping.
    /// </summary>
    [JsonProperty("unwrapped_metadata_is_private")]
    public bool UnwrappedMetadataIsPrivate { get; set; }

    /// <summary>
    /// True if authorized minters may alter a token's metadata.
    /// </summary>
    [JsonProperty("minter_may_update_metadata")]
    public bool MinterMayUpdateMetadata { get; set; }

    /// <summary>
    /// True if a token owner may alter its metadata.
    /// </summary>
    [JsonProperty("owner_may_update_metadata")]
    public bool OwnerMayUpdateMetadata { get; set; }

    /// <summary>
    /// True if burn functionality is enabled.
    /// </summary>
    [JsonProperty("burn_is_enabled")]
    public bool BurnIsEnabled { get; set; }

}
