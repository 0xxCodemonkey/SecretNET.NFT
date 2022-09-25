﻿namespace SecretNET.NFT;

public class GetRoyaltyInfoRequest
{
    /// <summary>
    /// Payload of the request.
    /// </summary>
    [JsonProperty("royalty_info")]
    public GetRoyaltyInfoRequest_Payload Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GetRoyaltyInfoRequest" /> class.
    /// </summary>
    /// <param name="tokenId">The ID of the token being queried.</param>
    /// <param name="viewerInfo">The viewer information.</param>
    public GetRoyaltyInfoRequest(string tokenId, ViewerInfo viewerInfo = null)
    {
        Payload = new GetRoyaltyInfoRequest_Payload
        {
            TokenId = tokenId,
            ViewerInfo = viewerInfo
        };
    }
}

public class GetRoyaltyInfoRequest_Payload
{
    /// <summary>
    /// The ID of the token being queried (not optional).
    /// </summary>
    /// <value>The token identifier.</value>
    [JsonProperty("token_id")]
    public string TokenId { get; set; }

    /// <summary>
    /// The address and viewing key performing this query.
    /// </summary>
    /// <value>The address.</value>
    [JsonProperty("viewer", NullValueHandling = NullValueHandling.Ignore)]
    public ViewerInfo ViewerInfo { get; set; }

}