using System;

namespace Nfantom.KeyStore.Crypto
{
    public class DecryptionException : Exception
    {
        internal DecryptionException(string msg) : base(msg)
        {
        }
    }
}