using System;
using System.Collections.Generic;

namespace CipherNet.Common
{
    public class AlgorithmComposition<T1, T2> : ICipherAlgorithm 
        where T1 : ICipherAlgorithm
        where T2 : ICipherAlgorithm
     {
        public AlgorithmComposition(IDictionary<string, string> Keys)
        {
            
        }

        public string Decrypt(string encodedText)
        {
            throw new NotImplementedException();
        }

        public string Encrypt(string plainText)
        {
            throw new NotImplementedException();
        }
    }
}
