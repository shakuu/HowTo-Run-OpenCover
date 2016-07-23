namespace AutomateGenerateCoverage.Tests.Utils
{
    using System.Collections.Generic;

    using NUnit.Framework;

    using AutomateGenerateCoverage.Contracts;
    using AutomateGenerateCoverage.Models;

    [TestFixture]
    public class ValidatorTests
    {
        [Test]
        public void CheckIfObjectIsNull_ShouldReturnTrue_IfPassedArguemntIsNull()
        {
            object obj = null;
            IValidate validator;

            var actualResult = validator.CheckIfObjectIsNull(obj);

            Assert.IsTrue(actualResult);
        }

        [Test]
        public void CheckIfObjectIsNUll_ShouldReturnFalse_IfPassedArgumentIsNotNull()
        {
            var obj = new List<string>();
            IValidate validator;

            var actualResult = validator.CheckIfObjectIsNull(obj);

            Assert.IsFalse(actualResult);
        }

        [Test]
        public void CheckIfStringIsNullOrEmpty_ShouldReturnTrue_IfPassedStringIsNull()
        {
            string str = null;
            IValidate validator;

            var actualResult = validator.CheckIfStringIsNullOrEmpty(str);

            Assert.IsTrue(actualResult);
        }

        [Test]
        public void CheckIfStringIsNullOrEmpty_ShouldReturnTrue_IfPassedStringIsEmpty()
        {
            string str = string.Empty;
            IValidate validator;

            var actualResult = validator.CheckIfStringIsNullOrEmpty(str);

            Assert.IsTrue(actualResult);
        }

        [Test]
        public void CheckIfStringIsNullOrEmpty_ShouldReturnFalse_IfPassedStringHasValue()
        {
            string str = "this string has a value";
            IValidate validator;

            var actualResult = validator.CheckIfStringIsNullOrEmpty(str);

            Assert.IsFalse(actualResult);
        }
    }
}
