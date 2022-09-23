# Secret.NET SNIP721 / Secret NFT
**Secret.NET SNIP721** is a layer on top of the [**Secret.NET client**](https://github.com/0xxCodemonkey/SecretNET) which supports all methods of the reference implementation of the SNIP721 contract:
- Implementation => [GitHub - baedrik/snip721-reference-impl](https://github.com/baedrik/snip721-reference-impl) 
- Implementation of the [SNIP-721 specification](https://github.com/SecretFoundation/SNIPs/blob/master/SNIP-721.md) and [SNIP-722 specification](https://github.com/baedrik/snip-722-spec/blob/master/SNIP-722.md).
- See also the [SNIP721 documentation on Secret Network](https://docs.scrt.network/secret-network-documentation/development/snips/snip-721-private-non-fungible-tokens-nfts).

The [Secret Network blockchain](https://scrt.network/) (L1 / Cosmos), is the first privacy smart contract blockchain that processes and stores data on-chain in encrypted form (via Intel SGX). 
This allows [unique use cases](https://docs.scrt.network/secret-network-documentation/secret-network-overview/use-cases) like Secret NFTs where you can store public and private data e.g., Encryption Keys, passwords or other secrets.

:white_check_mark: **This repository is explicitly intended to serve as a template for custom SNIP721 NFT contracts.**
This makes it easy to create your own customized clients for your own customized contracts.
Of course, the concept can be used for any kind of smart contracts in general.

## Full API-documentation
You can find the **full API-documentation** here => https://0xxcodemonkey.github.io/SecretNET.SNIP721

# Table of Contents
- [Table of Contents](#table-of-contents)
- [Implementation](#implementation)
  - [Instantiating a SNIP721 Client](#instantiating-a-snip721-client)
  - [Usage](#usage)
- [Implemented methods](#implemented-methods)
  - [Queries](#queries)
  - [Transactions](#transactions)

# Implementation
The structure of SecretNET.SNIP721 is the same as the SecretNET client and transactions are accessible via ```Tx``` property and queries via ```Query``` property.

All transactions can also be simulated via ```Tx.Simulate```.

**All types and methods are documented and eases programming:**

![](resources/VS_IntelliSense.png)
## Instantiating a SNIP721 Client
To instantiate a SecretNET.SNIP20 client you just have to pass it a SecretNET client instance:
```  csharp
var snip721Client =  new SecretNET.SNIP721.Snip721Client(secretNetworkClient);
```

## Usage
All Methods can be easily called with the payload message like this:
```  csharp
var payloadTransferMsg = new SecretNET.SNIP721.TransferNftRequest(
              recipientAddress,
              tokenId);
              
var transferMsg = new SecretNET.SNIP721.MsgTransferNft(
                payloadTransferMsg, 
                snip721ContractAddress, 
                snip721CodeHash);

var transferResult = await snip721Client.Tx.TransferNft(
                transferMsg, 
                txOptions: txOptionsExecute);
```

Many methods also have an overload to make them even easier to call, like this
```  csharp
var transferResult = await snip721Client.Tx.TransferNft(
                snip721ContractAddress, 
                recipientAddress, 
                tokenId, 
                codeHash: snip721CodeHash, 
                txOptions: txOptionsExecute);
```

# Implemented methods
## Queries
- GetAllNftInfo
- GetAllTokens
- GetApprovedForAll
- GetBatchNftDossier
- GetContractConfig
- GetImplementsTokenSubtype
- GetInventoryApprovals
- GetIsTransferable
- GetIsUnwrapped
- GetNftDossier
- GetNftInfo
- GetNumTokens
- GetNumTokensOfOwner
- GetOwnerOf
- GetPrivateMetadata
- GetRegisteredCodeHash
- GetRoyaltyInfo
- GetTokenApprovals
- GetTokenInfo
- GetTokens
- GetTransactionHistory
- GetVerifyTransferApproval

## Transactions
- AddMinter
- Approve
- ApproveAll
- BatchBurnNft
- BatchMintNft
- BatchSendNft
- BatchTransferNft
- BurnNft
- ChangeAdmin
- CreateViewingKey
- Instantiate (new contract)
- MakeOwnershipPrivate
- MintNft
- MintNftClones
- RegisterReceiveNft
- RemoveMinters
- Reveal
- Revoke
- RevokeAll
- RevokePermit
- SendNft
