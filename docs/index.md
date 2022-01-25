
Nfantom is a modified fork of the [Nethereum](https://github.com/Nethereum/Nethereum) project (fork started at Nethereum v4.1.1.0), while Nethereum offers .NET support for the Ethereum blockchain, Nfantom offers similar .NET support for the [Fantom blockchain](https://fantom.foundation/).

Enormous praise and thanks goes to the hard working team at Nethereum, this project will be forever in their debt. 

Due to changes made to the RPC calls (eth_ -> ftm_, plus new Fantom specific calls) for the Fantom node software ([Opera](https://github.com/Fantom-foundation/go-opera) which is based originally on geth) and upcoming changes to the EVM towards a new implementation called the FVM, this new fork has been created and will be continuously updated to support .NET development on the Fantom blockchain.

Nfantom will diverge from Nethereum significantly and that change has already started with the first commits due to a desire to not support all possible versions of .NET but move forward with .NET standard and .NET 5/6 and onwards. This was the main reason for the decision to fork, there is a lot of complexity in the Nethereum code in order to support obsolete versions of .NET which I suspect has increasingly diminishing use cases.




