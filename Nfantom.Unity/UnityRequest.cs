using System;


namespace Nfantom.Unity
{
    public class UnityRequest<TResult>
    {
        public TResult Result { get; set; }
        public Exception? Exception { get; set; }
    }
}
