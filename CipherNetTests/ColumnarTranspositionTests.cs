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

        [TestMethod]
        public void DecryptBasic() {
            ColumnarTranspostition col = new ColumnarTranspostition("ZEBRA");
            var encrypted = "CAHSXTTCPSTANREADSITAKWAB";
            var plainText = col.Decrypt(encrypted);
            // Starts with as text could be padded
            Assert.IsTrue(plainText.StartsWith(TextExample, StringComparison.Ordinal));
        }
    }
}
