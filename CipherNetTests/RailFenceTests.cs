using System;
using CipherNet.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CipherNetTests
{
    [TestClass]
    public class RailFenceTests
    {
        const string BasicText = "DEFENDTHEEASTWALL";

        [TestMethod]
        public void EncryptBasic()
        {
            RailFence rf3 = new RailFence(3);
            var output = rf3.Encrypt(BasicText);
            Assert.AreEqual("DNETLEEDHESWLFTAA", output);
        }

        [TestMethod]
        public void EncryptBasic2() 
        {
            RailFence rf4 = new RailFence(4);
            var output = rf4.Encrypt(BasicText);
            Assert.AreEqual("DTTEDHSWFNEAALEEL", output);
        }

        [TestMethod]
        public void DecryptBasic() 
        {
            RailFence rf4 = new RailFence(4);
            var output = rf4.Decrypt("DTTEDHSWFNEAALEEL");
            Assert.AreEqual(BasicText, output);
        }
    }
}
