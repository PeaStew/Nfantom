using System.Threading.Tasks;

namespace Nfantom.Util
{
    public interface IWaitStrategy
    {
        Task ApplyAsync(uint retryCount);
    }
}