﻿using Nfantom.BlockchainProcessing.ProgressRepositories;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace Nfantom.BlockchainProcessing.Orchestrator
{
    public interface IBlockchainProcessingOrchestrator
    {
        Task<OrchestrationProgress> ProcessAsync(BigInteger fromNumber, BigInteger toNumber, CancellationToken cancellationToken = default(CancellationToken), IBlockProgressRepository blockProgressRepository = null);  
    }
}