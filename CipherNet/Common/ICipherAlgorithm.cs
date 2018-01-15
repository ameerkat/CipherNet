using System;
using System.Collections.Generic;

namespace CipherNet.Common
{
    public interface ICipherAlgorithm
    {
        String Encrypt(String plainText);
        String Decrypt(String encodedText);
    }
}
