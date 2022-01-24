namespace Nfantom.Geth.QueryHandlers.MultiCall
{
    public interface IMulticallInputOutput
    {
        string Target { get; set; }
        byte[] GetCallData();
        void Decode(byte[] output);
    }
}