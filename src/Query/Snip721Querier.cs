using SecretNET.AccessControl;
using SecretNET.Query;

namespace SecretNET.NFT;

/// <summary>
/// Class Snip721Querier.
/// </summary>
public class Snip721Querier
{
    private SecretNetworkClient _secretNetworkClient;
    private ComputeQueryClient _computeQuery;

    /// <summary>
    /// Initializes a new instance of the <see cref="Snip721Querier"/> class.
    /// </summary>
    /// <param name="secretNetworkClient">The secret network client.</param>
    public Snip721Querier(SecretNetworkClient secretNetworkClient)
    {
        _secretNetworkClient = secretNetworkClient;
        _computeQuery = secretNetworkClient.Query.Compute;
    }

    /// <summary>
    /// ContractInfo returns the contract's name and symbol. 
    /// This query is not authenticated.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <returns>SecretQueryContractResult&lt;GetContractInfoResponse&gt;.</returns>
    public async Task<SecretQueryContractResult<GetContractInfoResponse>> GetTokenInfo(string contractAddress, string? codeHash = null)
    {
        var request = new GetContractInfoRequest();

        var result = await _computeQuery.QueryContract<GetContractInfoResponse>(contractAddress, request, codeHash);
        return result;
    }

    /// <summary>
    /// ContractConfig returns the configuration values that were selected when the contract was instantiated. See Config for an explanation of the configuration options. 
    /// This query is not authenticated.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <returns>SecretQueryContractResult&lt;GetContractConfigResponse&gt;.</returns>
    public async Task<SecretQueryContractResult<GetContractConfigResponse>> GetContractConfig(string contractAddress, string? codeHash = null)
    {
        var request = new GetContractConfigRequest();

        var result = await _computeQuery.QueryContract<GetContractConfigResponse>(contractAddress, request, codeHash);
        return result;
    }

    /// <summary>
    /// Minters returns the list of addresses that are authorized to mint tokens. 
    /// This query is not authenticated.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <returns>SecretQueryContractResult&lt;GetMintersResponse&gt;.</returns>
    public async Task<SecretQueryContractResult<GetMintersResponse>> GetMinters(string contractAddress, string? codeHash = null)
    {
        var request = new GetMintersRequest();

        var result = await _computeQuery.QueryContract<GetMintersResponse>(contractAddress, request, codeHash);
        return result;
    }

    /// <summary>
    /// RegisteredCodeHash will display the code hash of the specified contract if it has registered its receiver interface and will indicate whether the contract implements BatchReceiveNft.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <returns>SecretQueryContractResult&lt;GetRegisteredCodeHashResponse&gt;.</returns>
    public async Task<SecretQueryContractResult<GetRegisteredCodeHashResponse>> GetRegisteredCodeHash(string contractAddress, string? codeHash = null)
    {
        var request = new GetRegisteredCodeHashRequest(contractAddress);

        var result = await _computeQuery.QueryContract<GetRegisteredCodeHashResponse>(contractAddress, request, codeHash);
        return result;
    }

    /// <summary>
    /// NumTokens returns the number of tokens controlled by the contract. 
    /// If the contract's token supply is private, only an authenticated minter's address will be allowed to perform this query.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="address">Address of the querier if supplying optional ViewerInfo.</param>
    /// <param name="viewingKey">Viewer's key if supplying optional ViewerInfo.</param>
    /// <param name="permit">Authenticate with permit.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <returns>SecretQueryContractResult&lt;GetNumTokensResponse&gt;.</returns>
    public async Task<SecretQueryContractResult<GetNumTokensResponse>> GetNumTokens(string contractAddress, string address = null, string viewingKey = null, Permit? permit = null, string? codeHash = null)
    {
        var request = new GetNumTokensRequest(address, viewingKey);

        object queryMsg = null;
        if (permit == null)
        {
            queryMsg = request;
        }
        else
        {
            request.Payload.ViewerInfo = null; // extracted from permit

            var withPermitRequest = new WithPermitRequest(permit, request);
            queryMsg = withPermitRequest;
        }

        var result = await _computeQuery.QueryContract<GetNumTokensResponse>(contractAddress, queryMsg, codeHash);
        return result;
    }

    /// <summary>
    /// AllTokens returns an optionally paginated list of all the token IDs controlled by the contract.
    /// If the contract's token supply is private, only an authenticated minter's address will be allowed to perform this query.
    /// When paginating, supply the last token ID received in a response as the start_after token ID of the next query to continue listing where the previous query stopped.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="address">The address.</param>
    /// <param name="viewingKey">The viewing key.</param>
    /// <param name="permit">Authenticate with permit.</param>
    /// <param name="startAfter">The start after.</param>
    /// <param name="limit">The limit.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <returns>SecretQueryContractResult&lt;GetAllTokensResponse&gt;.</returns>
    public async Task<SecretQueryContractResult<GetAllTokensResponse>> GetAllTokens(string contractAddress, string address = null, string viewingKey = null, Permit? permit = null, string startAfter = null, int? limit = 300, string? codeHash = null)
    {
        var request = new GetAllTokensRequest(address, viewingKey, startAfter, limit);

        object queryMsg = null;
        if (permit == null)
        {
            queryMsg = request;
        }
        else
        {
            request.Payload.ViewerInfo = null; // extracted from permit

            var withPermitRequest = new WithPermitRequest(permit, request);
            queryMsg = withPermitRequest;
        }

        var result = await _computeQuery.QueryContract<GetAllTokensResponse>(contractAddress, queryMsg, codeHash);
        return result;
    }

    /// <summary>
    /// IsUnwrapped indicates whether the token has been unwrapped.
    /// If sealed metadata is not enabled, all tokens are considered to be unwrapped.
    /// This query is not authenticated..
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="tokenId">The ID of the token whose unwrapped status is being queried.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <returns>SecretQueryContractResult&lt;GetIsUnwrappedResponse&gt;.</returns>
    public async Task<SecretQueryContractResult<GetIsUnwrappedResponse>> GetIsUnwrapped(string contractAddress, string tokenId, string? codeHash = null)
    {
        var request = new GetIsUnwrappedRequest(tokenId);

        var result = await _computeQuery.QueryContract<GetIsUnwrappedResponse>(contractAddress, request, codeHash);
        return result;
    }

    /// <summary>
    /// IsTransferable is a SNIP-722 query that indicates whether the token is transferable.
    /// This query is not authenticated.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="tokenId">The token identifier.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <returns>SecretQueryContractResult&lt;GetIsTransferableResponse&gt;.</returns>
    public async Task<SecretQueryContractResult<GetIsTransferableResponse>> GetIsTransferable(string contractAddress, string tokenId, string? codeHash = null)
    {
        var request = new GetIsTransferableRequest(tokenId);

        var result = await _computeQuery.QueryContract<GetIsTransferableResponse>(contractAddress, request, codeHash);
        return result;
    }

    /// <summary>
    /// OwnerOf returns the owner of the specified token if the querier is the owner or has been granted permission to view the owner.
    /// If the querier is the owner, OwnerOf will also display all the addresses that have been given transfer permission.
    /// The transfer approval list is provided as part of CW-721 compliance; however, the token owner is advised to use NftDossier for a more
    /// complete list that includes view_owner and view_private_metadata approvals (which CW-721 is not capable of keeping private).
    /// If no viewer is provided, OwnerOf will only display the owner if ownership is public for this token.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="tokenId">ID of the token being queried.</param>
    /// <param name="viewerInfo">The address and viewing key performing this query.</param>
    /// <param name="permit">Authenticate with permit.</param>
    /// <param name="includeExpired">True if expired transfer approvals should be included in the response.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <returns>SecretQueryContractResult&lt;GetOwnerOfResponse&gt;.</returns>
    public async Task<SecretQueryContractResult<GetOwnerOfResponse>> GetOwnerOf(string contractAddress, string tokenId, ViewerInfo viewerInfo = null, Permit? permit = null, bool? includeExpired = null, string? codeHash = null)
    {
        var request = new GetOwnerOfRequest(tokenId, viewerInfo, includeExpired);

        object queryMsg = null;
        if (permit == null)
        {
            queryMsg = request;
        }
        else
        {
            request.Payload.ViewerInfo = null; // extracted from permit

            var withPermitRequest = new WithPermitRequest(permit, request);
            queryMsg = withPermitRequest;
        }

        var result = await _computeQuery.QueryContract<GetOwnerOfResponse>(contractAddress, queryMsg, codeHash);
        return result;
    }

    /// <summary>
    /// NftInfo returns the public metadata of a token.
    /// It follows CW-721 specification, which is based on ERC-721 Metadata JSON Schema.
    /// At most, one of the fields token_uri OR extension will be defined.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="tokenId">ID of the token being queried.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <returns>SecretQueryContractResult&lt;GetNftInfoResponse&gt;.</returns>
    public async Task<SecretQueryContractResult<GetNftInfoResponse>> GetNftInfo(string contractAddress, string tokenId, string? codeHash = null)
    {
        var request = new GetNftInfoRequest(tokenId);

        var result = await _computeQuery.QueryContract<GetNftInfoResponse>(contractAddress, request, codeHash);
        return result;
    }

    /// <summary>
    /// AllNftInfo displays the result of both OwnerOf and NftInfo in a single query.
    /// This is provided for CW-721 compliance, but for more complete information about a token, use NftDossier, which will include
    /// private metadata and view_owner and view_private_metadata approvals if the querier is permitted to view this information.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="tokenId">ID of the token being queried.</param>
    /// <param name="viewerInfo">The address and viewing key performing this query.</param>
    /// <param name="permit">Authenticate with permit.</param>
    /// <param name="includeExpired">True if expired transfer approvals should be included in the response.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <returns>SecretQueryContractResult&lt;GetAllNftInfoResponse&gt;.</returns>
    public async Task<SecretQueryContractResult<GetAllNftInfoResponse>> GetAllNftInfo(string contractAddress, string tokenId, ViewerInfo viewerInfo = null, Permit? permit = null, bool? includeExpired = null, string? codeHash = null)
    {
        var request = new GetAllNftInfoRequest(tokenId, viewerInfo, includeExpired);

        object queryMsg = null;
        if (permit == null)
        {
            queryMsg = request;
        }
        else
        {
            request.Payload.ViewerInfo = null; // extracted from permit

            var withPermitRequest = new WithPermitRequest(permit, request);
            queryMsg = withPermitRequest;
        }

        var result = await _computeQuery.QueryContract<GetAllNftInfoResponse>(contractAddress, queryMsg, codeHash);
        return result;
    }

    /// <summary>
    /// PrivateMetadata returns the private metadata of a token if the querier is permitted to view it.
    /// It follows CW-721 metadata specification, which is based on ERC-721 Metadata JSON Schema.
    /// At most, one of the fields token_uri OR extension will be defined.
    /// If the metadata is sealed, no one is permitted to view it until it has been unwrapped with Reveal.
    /// If no viewer is provided, PrivateMetadata will only display the private metadata if the private metadata is public for this token.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="tokenId">ID of the token being queried.</param>
    /// <param name="viewerInfo">The address and viewing key performing this query.</param>
    /// <param name="permit">Authenticate with permit.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <returns>SecretQueryContractResult&lt;GetPrivateMetadataResponse&gt;.</returns>
    public async Task<SecretQueryContractResult<GetPrivateMetadataResponse>> GetPrivateMetadata(string contractAddress, string tokenId, ViewerInfo viewerInfo = null, Permit? permit = null, string? codeHash = null)
    {
        var request = new GetPrivateMetadataRequest(tokenId, viewerInfo);

        object queryMsg = null;
        if (permit == null)
        {
            queryMsg = request;
        }
        else
        {
            request.Payload.ViewerInfo = null; // extracted from permit

            var withPermitRequest = new WithPermitRequest(permit, request);
            queryMsg = withPermitRequest;
        }

        var result = await _computeQuery.QueryContract<GetPrivateMetadataResponse>(contractAddress, queryMsg, codeHash);
        return result;
    }

    /// <summary>
    /// NftDossier returns all the information about a token that the viewer is permitted to view.
    /// If no viewer is provided, NftDossier will only display the information that has been made public.
    /// The response may include the owner, the public metadata, the private metadata, the reason the private metadata is not viewable,
    /// the royalty information, the mint run information, whether the token is transferable, whether ownership is public,
    /// whether the private metadata is public, and (if the querier is the owner,) the approvals for this token as well as the inventory-wide approvals for the owner.
    /// This implementation will only display a token's royalty recipient addresses if the querier has permission to transfer the token.
    /// SNIP-722 adds a transferable field to the NftDossier response.
    /// SNIP-723 (specification to be written) adds an unwrapped field which is false if private metadata for this token is sealed.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="tokenId">The IDs of the token being queried.</param>
    /// <param name="viewerInfo">The address and viewing key performing this query.</param>
    /// <param name="permit">Authenticate with permit.</param>
    /// <param name="includeExpired">True if expired transfer approvals should be included in the response.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <returns>SecretQueryContractResult&lt;GetNftDossierResponse&gt;.</returns>
    public async Task<SecretQueryContractResult<GetNftDossierResponse>> GetNftDossier(string contractAddress, string tokenId, ViewerInfo viewerInfo = null, Permit? permit = null, bool? includeExpired = null, string? codeHash = null)
    {
        var request = new GetNftDossierRequest(tokenId, viewerInfo, includeExpired);

        object queryMsg = null;
        if (permit == null)
        {
            queryMsg = request;
        }
        else
        {
            request.Payload.ViewerInfo = null; // extracted from permit

            var withPermitRequest = new WithPermitRequest(permit, request);
            queryMsg = withPermitRequest;
        }

        var result = await _computeQuery.QueryContract<GetNftDossierResponse>(contractAddress, queryMsg, codeHash);
        return result;
    }

    /// <summary>
    /// Displays all the information about multiple tokens that the viewer has permission to see.
    /// This may include the owner, the public metadata, the private metadata, royalty
    /// information, mint run information, whether the token is unwrapped, whether the token is
    /// transferable, and the token and inventory approvals
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="tokenId">The IDs of the token being queried.</param>
    /// <param name="viewerInfo">The address and viewing key performing this query.</param>
    /// <param name="permit">Authenticate with permit.</param>
    /// <param name="includeExpired">True if expired transfer approvals should be included in the response.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <returns>SecretQueryContractResult&lt;GetBatchNftDossierResponse&gt;.</returns>
    public async Task<SecretQueryContractResult<GetBatchNftDossierResponse>> GetBatchNftDossier(string contractAddress, string[] tokenIds, ViewerInfo viewerInfo = null, Permit? permit = null, bool? includeExpired = null, string? codeHash = null)
    {
        var request = new GetBatchNftDossierRequest(tokenIds, viewerInfo, includeExpired);

        object queryMsg = null;
        if (permit == null)
        {
            queryMsg = request;
        }
        else
        {
            request.Payload.ViewerInfo = null; // extracted from permit

            var withPermitRequest = new WithPermitRequest(permit, request);
            queryMsg = withPermitRequest;
        }

        var result = await _computeQuery.QueryContract<GetBatchNftDossierResponse>(contractAddress, queryMsg, codeHash);
        return result;
    }

    /// <summary>
    /// If a token_id is provided in the request, RoyaltyInfo returns the royalty information for that token.
    /// This implementation will only display a token's royalty recipient addresses if the querier has permission to transfer the token.
    /// If no token_id is requested, RoyaltyInfo displays the default royalty information for the contract.
    /// This implementation will only display the contract's default royalty recipient addresses if the querier is an authorized minter.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="tokenId">ID of the token being queried.</param>
    /// <param name="viewerInfo">The address and viewing key performing this query.</param>
    /// <param name="permit">Authenticate with permit.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <returns>SecretQueryContractResult&lt;GetRoyaltyInfoResponse&gt;.</returns>
    public async Task<SecretQueryContractResult<GetRoyaltyInfoResponse>> GetRoyaltyInfo(string contractAddress, string tokenId, ViewerInfo viewerInfo = null, Permit? permit = null, string? codeHash = null)
    {
        var request = new GetRoyaltyInfoRequest(tokenId, viewerInfo);

        object queryMsg = null;
        if (permit == null)
        {
            queryMsg = request;
        }
        else
        {
            request.Payload.ViewerInfo = null; // extracted from permit

            var withPermitRequest = new WithPermitRequest(permit, request);
            queryMsg = withPermitRequest;
        }

        var result = await _computeQuery.QueryContract<GetRoyaltyInfoResponse>(contractAddress, queryMsg, codeHash);
        return result;
    }

    /// <summary>
    /// TokenApprovals returns whether the owner and private metadata of a token is public, and lists all the approvals specific to this token.
    /// Only the token's owner may perform TokenApprovals.
    /// (This query MUST be authenticated)
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="tokenId">ID of the token being queried.</param>
    /// <param name="viewingKey">The token owner's viewing key.</param>
    /// <param name="permit">Authenticate with permit.</param>
    /// <param name="includeExpired">True if expired transfer approvals should be included in the response.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <returns>SecretQueryContractResult&lt;GetTokenApprovalsResponse&gt;.</returns>
    public async Task<SecretQueryContractResult<GetTokenApprovalsResponse>> GetTokenApprovals(string contractAddress, string tokenId, string viewingKey = null, Permit? permit = null, bool? includeExpired = null, string? codeHash = null)
    {
        var request = new GetTokenApprovalsRequest(tokenId, viewingKey, includeExpired);

        object queryMsg = null;
        if (permit == null)
        {
            queryMsg = request;
        }
        else
        {
            request.Payload.ViewingKey = null;  // not necessary / possible when using permit

            var withPermitRequest = new WithPermitRequest(permit, request);
            queryMsg = withPermitRequest;
        }

        var result = await _computeQuery.QueryContract<GetTokenApprovalsResponse>(contractAddress, queryMsg, codeHash);
        return result;
    }

    /// <summary>
    /// ApprovedForAll displays all the addresses that have approval to transfer all of the specified owner's tokens.
    /// This is provided to comply with CW-721 specification, but because approvals are private on Secret Network, if the owner's viewing key is not provided,
    /// no approvals will be displayed. For a more complete list of inventory-wide approvals,
    /// the owner should use InventoryApprovals which also includes view_owner and view_private_metadata approvals.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="tokenId">ID of the token being queried.</param>
    /// <param name="viewingKey">The token owner's viewing key.</param>
    /// <param name="permit">Authenticate with permit.</param>
    /// <param name="includeExpired">True if expired transfer approvals should be included in the response.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <returns>SecretQueryContractResult&lt;GetApprovedForAllResponse&gt;.</returns>
    public async Task<SecretQueryContractResult<GetApprovedForAllResponse>> GetApprovedForAll(string contractAddress, string tokenId, string viewingKey = null, Permit? permit = null, bool? includeExpired = null, string? codeHash = null)
    {
        var request = new GetApprovedForAllRequest(tokenId, viewingKey, includeExpired);

        object queryMsg = null;
        if (permit == null)
        {
            queryMsg = request;
        }
        else
        {
            request.Payload.ViewingKey = null;  // not necessary / possible when using permit

            var withPermitRequest = new WithPermitRequest(permit, request);
            queryMsg = withPermitRequest;
        }

        var result = await _computeQuery.QueryContract<GetApprovedForAllResponse>(contractAddress, queryMsg, codeHash);
        return result;
    }

    /// <summary>
    /// InventoryApprovals returns whether all the address' tokens have public ownership and/or public display of private metadata,
    /// and lists all the inventory-wide approvals the address has granted. Only the viewing key for this specified address will be accepted.
    /// (This query MUST be authenticated)
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="tokenId">ID of the token being queried.</param>
    /// <param name="viewingKey">The token owner's viewing key.</param>
    /// <param name="permit">Authenticate with permit.</param>
    /// <param name="includeExpired">True if expired transfer approvals should be included in the response.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <returns>SecretQueryContractResult&lt;GetInventoryApprovalsResponse&gt;.</returns>
    public async Task<SecretQueryContractResult<GetInventoryApprovalsResponse>> GetInventoryApprovals(string contractAddress, string tokenId, string viewingKey = null, Permit? permit = null, bool? includeExpired = null, string? codeHash = null)
    {
        var request = new GetInventoryApprovalsRequest(tokenId, viewingKey, includeExpired);

        object queryMsg = null;
        if (permit == null)
        {
            queryMsg = request;
        }
        else
        {
            request.Payload.ViewingKey = null;  // not necessary / possible when using permit

            var withPermitRequest = new WithPermitRequest(permit, request);
            queryMsg = withPermitRequest;
        }

        var result = await _computeQuery.QueryContract<GetInventoryApprovalsResponse>(contractAddress, queryMsg, codeHash);
        return result;
    }

    /// <summary>
    /// Tokens displays an optionally paginated list of all the token IDs that belong to the specified owner.
    /// It will only display the owner's tokens on which the querier has view_owner permission.
    /// If no viewing key is provided, it will only display the owner's tokens that have public ownership.
    /// When paginating, supply the last token ID received in a response as the start_after string of the next query to continue listing where the previous query stopped.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="owner">The address whose inventory is being queried.</param>
    /// <param name="viewer">The querier's address if different from the owner.</param>
    /// <param name="viewingKey">The querier's viewing key.</param>
    /// <param name="permit">Authenticate with permit.</param>
    /// <param name="startAfter">Results will only list token IDs that come after this token ID in the list.</param>
    /// <param name="limit">Number of token IDs to return.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <returns>SecretQueryContractResult&lt;GetTokensResponse&gt;.</returns>
    public async Task<SecretQueryContractResult<GetTokensResponse>> GetTokens(string contractAddress, string owner, string viewer = null, string viewingKey = null, Permit? permit = null, string startAfter = null, int? limit = null, string? codeHash = null)
    {
        var request = new GetTokensRequest(owner, viewer, viewingKey, startAfter, limit);

        object queryMsg = null;
        if (permit == null)
        {
            queryMsg = request;
        }
        else
        {
            request.Payload.Viewer = null;      // extracted from permit
            request.Payload.ViewingKey = null;  // not necessary / possible when using permit

            var withPermitRequest = new WithPermitRequest(permit, request);
            queryMsg = withPermitRequest;
        }

        var result = await _computeQuery.QueryContract<GetTokensResponse>(contractAddress, queryMsg, codeHash);
        return result;
    }

    /// <summary>
    /// Displays the number of tokens that the querier has permission to see the owner and that belong to the specified address.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="owner">The address whose inventory is being queried.</param>
    /// <param name="viewer">The querier's address if different from the owner.</param>
    /// <param name="viewingKey">The querier's viewing key.</param>
    /// <param name="permit">Authenticate with permit.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <returns>SecretQueryContractResult&lt;GetNumTokensOfOwnerResponse&gt;.</returns>
    public async Task<SecretQueryContractResult<GetNumTokensOfOwnerResponse>> GetNumTokensOfOwner(string contractAddress, string owner, string viewer = null, string viewingKey = null, Permit? permit = null, string? codeHash = null)
    {
        var request = new GetNumTokensOfOwnerRequest(owner, viewer, viewingKey);

        object queryMsg = null;
        if (permit == null)
        {
            queryMsg = request;
        }
        else
        {
            request.Payload.Viewer = null;      // extracted from permit
            request.Payload.ViewingKey = null;  // not necessary / possible when using permit

            var withPermitRequest = new WithPermitRequest(permit, request);
            queryMsg = withPermitRequest;
        }

        var result = await _computeQuery.QueryContract<GetNumTokensOfOwnerResponse>(contractAddress, queryMsg, codeHash);
        return result;
    }

    /// <summary>
    /// VerifyTransferApproval will verify that the specified address has approval to transfer the entire provided list of tokens.
    /// As explained above, queries may experience a delay in revealing expired approvals, so it is possible that a transfer attempt will still fail
    /// even after being verified by VerifyTransferApproval. If the address does not have transfer approval on all the tokens,
    /// the response will indicate the first token encountered that can not be transferred by the address.
    /// Because the intent of VerifyTransferApproval is to provide contracts a way to know before-hand whether an attempt to transfer tokens will fail,
    /// this implementation will consider any SNIP-722 non-transferable token as unapproved for transfer.
    /// (This query MUST be authenticated)
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="tokenIds">List of tokens to check for the address' transfer approval.</param>
    /// <param name="address">Address being checked for transfer approval.</param>
    /// <param name="viewingKey">The address' viewing key.</param>
    /// <param name="permit">Authenticate with permit.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <returns>SecretQueryContractResult&lt;GetVerifyTransferApprovalResponse&gt;.</returns>
    public async Task<SecretQueryContractResult<GetVerifyTransferApprovalResponse>> GetVerifyTransferApproval(string contractAddress, string[] tokenIds, string address, string viewingKey = null, Permit? permit = null, string? codeHash = null)
    {
        var request = new GetVerifyTransferApprovalRequest(tokenIds, address, viewingKey);

        object queryMsg = null;
        if (permit == null)
        {
            queryMsg = request;
        }
        else
        {
            request.Payload.Address = null;     // extracted from permit
            request.Payload.ViewingKey = null;  // not necessary / possible when using permit

            var withPermitRequest = new WithPermitRequest(permit, request);
            queryMsg = withPermitRequest;
        }

        var result = await _computeQuery.QueryContract<GetVerifyTransferApprovalResponse>(contractAddress, queryMsg, codeHash);
        return result;
    }

    /// <summary>
    /// ImplementsTokenSubtype is a SNIP-722 query which indicates whether the contract implements the token_subtype Extension field.
    /// Because legacy SNIP-721 contracts do not implement this query and do not implement token subtypes, any use of this query should always check for an error response,
    /// and if the response is an error, it can be considered that the contract does not implement subtypes.
    /// Because message parsing ignores input fields that a contract does not expect, this query should be used before attempting a message that uses the token_subtype Extension field.
    /// If the message is sent to a SNIP-721 contract that does not implement token_subtype, that field will just be ignored and the resulting NFT will still be created/updated,
    /// but without a token_subtype.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <returns>SecretQueryContractResult&lt;GetImplementsTokenSubtypeResponse&gt;.</returns>
    public async Task<SecretQueryContractResult<GetImplementsTokenSubtypeResponse>> GetImplementsTokenSubtype(string contractAddress, string? codeHash = null)
    {
        var request = new GetImplementsTokenSubtypeRequest();

        var result = await _computeQuery.QueryContract<GetImplementsTokenSubtypeResponse>(contractAddress, request, codeHash);
        return result;
    }

    /// <summary>
    /// ImplementsNonTransferableTokens is a SNIP-722 query which indicates whether the contract implements non-transferable tokens.
    /// Because legacy SNIP-721 contracts do not implement this query and do not implement non-transferable tokens, any use of this query should always check for an error response,
    /// and if the response is an error, it can be considered that the contract does not implement non-transferable tokens.
    /// Because message parsing ignores input fields that a contract does not expect, this query should be used before attempting to mint a non-transferable token.
    /// If the message is sent to a SNIP-721 contract that does not implement non-transferable tokens,
    /// the transferable field will just be ignored and the resulting NFT will still be created, but will always be transferable.
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <returns>SecretQueryContractResult&lt;GetImplementsNonTransferableTokensResponse&gt;.</returns>
    public async Task<SecretQueryContractResult<GetImplementsNonTransferableTokensResponse>> GetImplementsNonTransferableTokens(string contractAddress, string? codeHash = null)
    {
        var request = new GetImplementsNonTransferableTokensRequest();

        var result = await _computeQuery.QueryContract<GetImplementsNonTransferableTokensResponse>(contractAddress, request, codeHash);
        return result;
    }

    /// <summary>
    /// TransactionHistory displays an optionally paginated list of transactions (mint, burn, and transfer) in reverse chronological order that involve the specified address.
    /// (This query MUST be authenticated)
    /// </summary>
    /// <param name="contractAddress">The contract address.</param>
    /// <param name="address">The address whose transaction history is being queried.</param>
    /// <param name="viewingKey">The address' viewing key.</param>
    /// <param name="permit">Authenticate with permit.</param>
    /// <param name="page">The page number to display, where the first transaction shown skips the page * page_size most recent transactions.</param>
    /// <param name="pageSize">Number of transactions to return.</param>
    /// <param name="codeHash">CodeHash is (not really) optional and makes a call way faster.</param>
    /// <returns>SecretQueryContractResult&lt;GetTransactionHistoryResponse&gt;.</returns>
    public async Task<SecretQueryContractResult<GetTransactionHistoryResponse>> GetTransactionHistory(string contractAddress, string address, string viewingKey = null, Permit? permit = null, int? page = null, int? pageSize = null, string? codeHash = null)
    {
        var request = new GetTransactionHistoryRequest(address, viewingKey, page, pageSize);

        object queryMsg = null;
        if (permit == null)
        {
            queryMsg = request;
        }
        else
        {
            request.Payload.Address = null;     // extracted from permit
            request.Payload.ViewingKey = null;  // not necessary / possible when using permit

            var withPermitRequest = new WithPermitRequest(permit, request);
            queryMsg = withPermitRequest;
        }

        var result = await _computeQuery.QueryContract<GetTransactionHistoryResponse>(contractAddress, request, codeHash);
        return result;
    }

}
