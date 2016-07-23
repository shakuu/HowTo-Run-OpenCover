namespace AutomateGenerateCoverage.Tests.Utils
{
    using System.Collections.Generic;

    using NUnit.Framework;

    using AutomateGenerateCoverage.Contracts;
    using AutomateGenerateCoverage.Utils;

    [TestFixture]
    public class ValidatorTests
    {
        [Test]
        public void CheckIfObjectIsNull_ShouldReturnTrue_IfPassedArguemntIsNull()
        {
            object obj = null;
            IValidate validator = new Validator();

            var actualResult = validator.CheckIfObjectIsNull(obj);

            Assert.IsTrue(actualResult);
        }

        [Test]
        public void CheckIfObjectIsNUll_ShouldReturnFalse_IfPassedArgumentIsNotNull()
        {
            var obj = new List<string>();
            IValidate validator = new Validator();

            var actualResult = validator.CheckIfObjectIsNull(obj);

            Assert.IsFalse(actualResult);
        }

        [Test]
        public void CheckIfStringIsNullOrEmpty_ShouldReturnTrue_IfPassedStringIsNull()
        {
            string str = null;
            IValidate validator = new Validator();

            var actualResult = validator.CheckIfStringIsNullOrEmpty(str);

            Assert.IsTrue(actualResult);
        }

        [Test]
        public void CheckIfStringIsNullOrEmpty_ShouldReturnTrue_IfPassedStringIsEmpty()
        {
            string str = string.Empty;
            IValidate validator = new Validator();

            var actualResult = validator.CheckIfStringIsNullOrEmpty(str);

            Assert.IsTrue(actualResult);
        }

        [Test]
        public void CheckIfStringIsNullOrEmpty_ShouldReturnFalse_IfPassedStringHasValue()
        {
            string str = "this string has a value";
            IValidate validator = new Validator();

            var actualResult = validator.CheckIfStringIsNullOrEmpty(str);

            Assert.IsFalse(actualResult);
        }

        [Test]
        public void CheckIfFolderExistsAtInputPath_ShouldReturnFalse_IfGivenAnUnexistingPath()
        {
            var inputPath = "randome:\\path\\to\\nothing";
            IValidate validator = new Validator();

            var actualResult = validator.CheckIfFolderExistsAtInputPath(inputPath);

            Assert.IsFalse(actualResult);
        }

        [Test]
        public void CheckIfFolderExistsAtInputPath_ShouldReturnTrue_IfGivenAValidPath()
        {
            var inputPath = @"D:\GitHub\HowTo-Run-OpenCover\AutomateGenerateCoverage\AutomateGenerateCoverage.Tests\bin\Debug";
            IValidate validator = new Validator();

            var actualResult = validator.CheckIfFolderExistsAtInputPath(inputPath);

            Assert.IsTrue(actualResult);
        }

        [Test]
        public void CheckIfFileExistsAtInputPath_ShouldReturnFalse_IfGivenAnUnexistingPath()
        {
            var inputPath = "randome:\\path\\to\\nothing\\name.file";
            IValidate validator = new Validator();

            var actualResult = validator.CheckIfFileExistsAtInputPath(inputPath);

            Assert.IsFalse(actualResult);
        }

        [Test]
        public void CheckIfFileExistsAtInputPath_ShouldReturnTrue_IfGivenAValidPath()
        {
            var inputPath = @"D:\GitHub\HowTo-Run-OpenCover\AutomateGenerateCoverage\AutomateGenerateCoverage.Tests\bin\Debug\AutomateGenerateCoverage.Tests.dll";
            IValidate validator = new Validator();

            var actualResult = validator.CheckIfFileExistsAtInputPath(inputPath);

            Assert.IsTrue(actualResult);
        }
    }
}
