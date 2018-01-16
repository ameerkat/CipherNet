using System;
using CipherNet.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CipherNetTests
{
    [TestClass]
    public class AutokeyTests
    {
        [TestMethod]
        public void EncryptBasic() {
            Autokey ak = new Autokey("FORTIFICATION");
            var output = ak.Encrypt("DEFENDTHEEASTWALLOFTHECASTLE");
            Assert.AreEqual("ISWXVIBJEXIGGZEQPBIMOIGAKMHE", output);
        }

        [TestMethod]
        public void DecryptBasic() {
            Autokey ak = new Autokey("FORTIFICATION");
            var plainText = ak.Decrypt("ISWXVIBJEXIGGZEQPBIMOIGAKMHE");
            Assert.AreEqual("DEFENDTHEEASTWALLOFTHECASTLE", plainText);
        }
    }
}
