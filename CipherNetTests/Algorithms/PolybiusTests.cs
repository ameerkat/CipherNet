using System;
using CipherNet.Algorithms;
using CipherNet.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CipherNetTests
{
    [TestClass]
    public class PolybiusTests
    {
        const string BasicText = "THEQUICKBROWNFOXJUMPEDOVERTHELAZYDOG";
            
        [TestMethod]
        public void EncryptDecryptBasic()
        {
            Alphabet alpha = new Alphabet("PHQGIUMEAYLNOFDXKRCVSTZWB", false);
            Polybius poly = new Polybius(alpha, "ABCDE", (ch) => {
                if (ch == 'J') {
                    return 'I';
                }

                return ch;
            });

            var output = poly.Encrypt(BasicText);
            Assert.AreEqual("EBABBCACBAAEDDDBEEDCCCEDCBCDCCDAAEBABBAABCCECCDEBCDCEBABBCCABDECBECECCAD", output);
            var plainText = poly.Decrypt(output);
            Assert.AreEqual(BasicText.Replace('J', 'I'), plainText);
        }
    }
}
