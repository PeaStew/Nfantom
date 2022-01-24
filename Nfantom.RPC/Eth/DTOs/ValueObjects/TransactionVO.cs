namespace Nfantom.RPC.Eth.DTOs.ValueObjects
{
    public class TransactionVO
    {
        public Transaction Transaction { get; }
        public Block Block { get; }

        public TransactionVO()
        {

        }

        public TransactionVO(
            Transaction transaction,
            Block block
           )
        {
            Transaction = transaction;
            Block = block;
        }
    }
}
