using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spinutech.Exercise.Lib;

namespace Spinutech.Exercise.Tests
{
    [TestClass]
    public class PalindromeServiceTests
    {
        private PalindromeService _palindromeService;

        [TestInitialize]
        public void Setup()
        {
            _palindromeService = new PalindromeService();
        }

        [DataTestMethod]
        [DataRow(121, true)]
        [DataRow(123, false)]
        [DataRow(0, false)]
        [DataRow(1221, true)]
        [DataRow(12321, true)]
        [DataRow(10, false)]
        [DataRow(-121, false)] 
        [DataRow(5, false)] 
        public void IsPalindrome_ReturnsExpectedResult(int number, bool expectedResult)
        {
            // Act
            var result = _palindromeService.IsPalindrome(number);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
