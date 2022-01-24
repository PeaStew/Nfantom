using Nfantom.RPC.Eth.Compilation;

namespace Nfantom.RPC.Eth.Services
{
    public interface IEthApiCompilerService
    {
        IEthCompileLLL CompileLLL { get; }
        IEthCompileSerpent CompileSerpent { get; }
        IEthCompileSolidity CompileSolidity { get; }
        IEthGetCompilers GetCompilers { get; }
    }
}