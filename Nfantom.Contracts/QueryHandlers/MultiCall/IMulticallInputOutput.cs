namespace Nfantom.Contracts.QueryHandlers.MultiCall
{
    public interface IMulticallInputOutput
    {
        string Target { get; set; }
        byte[] GetCallData();
        void Decode(byte[] output);
    }
}