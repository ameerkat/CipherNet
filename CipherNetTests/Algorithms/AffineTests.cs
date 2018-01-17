using System;
using CipherNet.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CipherNetTests
{
    [TestClass]
    public class AffineTests
    {
        const string BasicText = "THEQUICKBROWNFOXJUMPEDOVERTHELAZYDOG";
            
        [TestMethod]
        public void EncryptDecryptBasic()
        {
            Affine affine = new Affine(9, 5);
            var output = affine.Encrypt(BasicText);
            Assert.AreEqual("UQPTDZXROCBVSYBEIDJKPGBMPCUQPAFWNGBH", output);
            var plainText = affine.Decrypt(output);
            Assert.AreEqual(BasicText, plainText);
        }
    }
}
