using System;
using CipherNet.Algorithms;
using CipherNet.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CipherNetTests
{
    [TestClass]
    public class ColumnarTranspositionTests
    {
        const string TextExample = "ATTACKATDAWNCSHARPISBEST";

        [TestMethod]
        public void EncryptBasic()
        {
            ColumnarTranspostition col = new ColumnarTranspostition("ZEBRA");
            var encrypted = col.Encrypt(TextExample);
            Assert.AreEqual("CAHSXTTCPSTANREADSITAKWAB".ToUpper(), encrypted);
        }
    }
}
