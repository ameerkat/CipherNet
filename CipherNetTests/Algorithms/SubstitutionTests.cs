using System;
using CipherNet.Algorithms;
using CipherNet.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CipherNetTests
{
    [TestClass]
    public class SubstitutionTests
    {
        const string TextExample = "DEFENDTHEEASTWALL";

        [TestMethod]
        public void EncryptDecryptBasic() {
            Substitution sub = new Substitution(new Alphabet("PHQGIUMEAYLNOFDXJKRCVSTZWB"));
            var encrypted = sub.Encrypt(TextExample);
            Assert.AreEqual("GIUIFGCEIIPRCTPNN", encrypted);
            var decrypted = sub.Decrypt(encrypted);
            Assert.AreEqual(TextExample, decrypted);
        }
    }
}
