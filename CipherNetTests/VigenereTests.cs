using System;
using CipherNet.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CipherNetTests
{
    [TestClass]
    public class VigenereTests
    {
        [TestMethod]
        public void DecryptBasic() {
            Vigenere v = new Vigenere("PALIMPSEST", new CipherNet.Common.Alphabet("KRYPTOS"));
            var plainText = v.Decrypt("EMUFPHZLRFAXYUSDJKZLDKRNSHGNFIVJYQTQUXQBQVYUVLLTREVJYQTMKYRDMFD");
            Assert.AreEqual("BETWEENSUBTLESHADINGANDTHEABSENCEOFLIGHTLIESTHENUANCEOFIQLUSION", plainText);
        }

        [TestMethod]
        public void EncryptBasic() {
            Vigenere v = new Vigenere("PALIMPSEST", new CipherNet.Common.Alphabet("KRYPTOS"));
            var encryptedText = v.Encrypt("BETWEENSUBTLESHADINGANDTHEABSENCEOFLIGHTLIESTHENUANCEOFIQLUSION");
            Assert.AreEqual("EMUFPHZLRFAXYUSDJKZLDKRNSHGNFIVJYQTQUXQBQVYUVLLTREVJYQTMKYRDMFD", encryptedText);
        }
    }
}
