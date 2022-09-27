# Secret.NET NFT (SNIP721) / Secret NFT
**Secret.NET NFT** is a layer on top of the [**Secret.NET client**](https://github.com/0xxCodemonkey/SecretNET) which supports all methods of the reference implementation of the SNIP721 contract.

**The [Secret Network blockchain](https://scrt.network/) (L1 / Cosmos), is the first privacy smart contract blockchain that processes and stores data on-chain in encrypted form (via Intel SGX).** 
This allows [unique use cases](https://docs.scrt.network/secret-network-documentation/secret-network-overview/use-cases) like **Secret NFTs** where you can store public and private data e.g., Encryption Keys, passwords or other secrets.

<p align="center">
  <img src="./resources/Secret.NET_banner.png" type="image/png" width="100%" />
</p>

SecretNET.NFT provides typed and documented objects and methods that simplify interaction with a SNIP721 smart contract.

- Implementation => [GitHub - baedrik/snip721-reference-impl](https://github.com/baedrik/snip721-reference-impl) 
- Implementation of the [SNIP-721 specification](https://github.com/SecretFoundation/SNIPs/blob/master/SNIP-721.md) and [SNIP-722 specification](https://github.com/baedrik/snip-722-spec/blob/master/SNIP-722.md).
- See also the [SNIP721 documentation on Secret Network](https://docs.scrt.network/secret-network-documentation/development/snips/snip-721-private-non-fungible-tokens-nfts).

:white_check_mark: **This repository is explicitly intended to serve as a template for custom SNIP721 NFT contracts.**
This makes it easy to create your own customized clients for your own customized contracts.
Of course, the concept can be used for any kind of smart contracts in general.

## Full API-documentation
You can find the **full API-documentation** here => https://0xxcodemonkey.github.io/SecretNET.NFT

# Table of Contents
- [Table of Contents](#table-of-contents)
- [Implementation](#implementation)
  - [Instantiating a SNIP721 Client](#instantiating-a-snip721-client)
  - [Usage](#usage)
- [Implemented methods](#implemented-methods)
  - [Queries](#queries-snip721clientquery)
  - [Transactions](#transactions-snip721clienttx)

# Implementation
The structure of SecretNET.NFT is the same as the SecretNET client and transactions are accessible via `Tx` property and queries via `Query` property.

All transactions can also be simulated via ```Tx.Simulate```.

**All types and methods are documented and eases programming:**

![](resources/VS_IntelliSense.png)
## Instantiating a SNIP721 Client
To instantiate a SecretNET.SNIP20 client you just have to pass it a [SecretNET client instance](https://github.com/0xxCodemonkey/SecretNET#usage-examples):
```  csharp
var snip721Client =  new SecretNET.NFT.Snip721Client(secretNetworkClient);
```

## Usage
All Methods can be easily called with the payload message like this:
```  csharp
var payloadTransferMsg = new SecretNET.NFT.TransferNftRequest(
              recipientAddress,
              tokenId);
              
var transferMsg = new SecretNET.NFT.MsgTransferNft(
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
- [Queries](#queries-snip721clientquery)
  - [GetAllNftInfo](#getallnftinfo)
  - [GetAllTokens](#getalltokens)
  - [GetApprovedForAll](#getapprovedforall)
  - [GetBatchNftDossier](#getbatchnftdossier)
  - [GetContractConfig](#getcontractconfig)
  - [GetImplementsTokenSubtype](#getimplementstokensubtype)
  - [GetInventoryApprovals](#getinventoryapprovals)
  - [GetIsTransferable](#getistransferable)
  - [GetIsUnwrapped](#getisunwrapped)
  - [GetNftDossier](#getnftdossier)
  - [GetNftInfo](#getnftinfo)
  - [GetNumTokens](#getnumtokens)
  - [GetNumTokensOfOwner](#getnumtokensofowner)
  - [GetOwnerOf](#getownerof)
  - [GetPrivateMetadata](#getprivatemetadata)
  - [GetRegisteredCodeHash](#getregisteredcodehash)
  - [GetRoyaltyInfo](#getroyaltyinfo)
  - [GetTokenApprovals](#gettokenapprovals)
  - [GetTokenInfo](#gettokeninfo)
  - [GetTokens](#gettokens)
  - [GetTransactionHistory](#gettransactionhistory)
  - [GetVerifyTransferApproval](#getverifytransferapproval)
- [Transactions](#transactions-snip721clienttx)
  - [AddMinter](#addminter)
  - [Approve](#approve)
  - [ApproveAll](#approveall)
  - [BatchBurnNft](#batchburnnft)
  - [BatchMintNft](#batchmintnft)
  - [BatchSendNft](#batchsendnft)
  - [BatchTransferNft](#batchtransfernft)
  - [BurnNft](#burnnft)
  - [ChangeAdmin](#changeadmin)
  - [CreateViewingKey](#createviewingkey)
  - [Instantiate (new contract)](#instantiate-new-contract)
  - [MakeOwnershipPrivate](#makeownershipprivate)
  - [MintNft](#mintnft)
  - [MintNftClones](#mintnftclones)
  - [RegisterReceiveNft](#registerreceivenft)
  - [RemoveMinters](#removeminters)
  - [Reveal](#reveal)
  - [Revoke](#revoke)
  - [RevokeAll](#revokeall)
  - [RevokePermit](#revokepermit)
  - [SendNft](#sendnft)

## Queries (`Snip721Client.Query`)
### GetAllNftInfo

``` csharp

```
### GetAllTokens

``` csharp

```
### GetApprovedForAll

``` csharp

```
### GetBatchNftDossier

``` csharp

```
### GetContractConfig

``` csharp

```
### GetImplementsTokenSubtype

``` csharp

```
### GetInventoryApprovals

``` csharp

```
### GetIsTransferable

``` csharp

```
### GetIsUnwrapped

``` csharp

```
### GetNftDossier

``` csharp

```
### GetNftInfo

``` csharp

```
### GetNumTokens

``` csharp

```
### GetNumTokensOfOwner

``` csharp

```
### GetOwnerOf

``` csharp

```
### GetPrivateMetadata

``` csharp

```
### GetRegisteredCodeHash

``` csharp

```
### GetRoyaltyInfo

``` csharp

```
### GetTokenApprovals

``` csharp

```
### GetTokenInfo

``` csharp

```
### GetTokens

``` csharp

```
### GetTransactionHistory

``` csharp

```
### GetVerifyTransferApproval

``` csharp

```

## Transactions (`Snip721Client.Tx`)
### AddMinter

``` csharp

```
### Approve

``` csharp

```
### ApproveAll

``` csharp

```
### BatchBurnNft

``` csharp

```
### BatchMintNft

``` csharp

```
### BatchSendNft

``` csharp

```
### BatchTransferNft

``` csharp

```
### BurnNft

``` csharp

```
### ChangeAdmin

``` csharp

```
### CreateViewingKey

``` csharp

```
### Instantiate (new contract)

``` csharp

```
### MakeOwnershipPrivate

``` csharp

```
### MintNft

``` csharp

```
### MintNftClones

``` csharp

```
### RegisterReceiveNft

``` csharp

```
### RemoveMinters

``` csharp

```
### Reveal

``` csharp

```
### Revoke

``` csharp

```
### RevokeAll

``` csharp

```
### RevokePermit

``` csharp

```
### SendNft

``` csharp

```
