namespace AutomateGenerateCoverage.Tests.Utils
{
    using System;

    using NUnit.Framework;

    using AutomateGenerateCoverage.Utils;
    using AutomateGenerateCoverage.Enums;

    [TestFixture]
    public class BasicBatchFileLineParameterTypeTranslatorTests
    {
        [Test]
        public void GetTranslatedValue_ShouldThrow_IfPassedAnInvalidValue()
        {
            var testParameterTypeValue = -1000;
            var batchLineParameterTypeTranslator = new BasicBatchFileLineParameterTypeTranslator();

            Assert.Throws<ArgumentException>(() => batchLineParameterTypeTranslator.GetTranslatedValue(testParameterTypeValue));
        }

        [Test]
        public void GetTranslatedValue_ShouldThrow_IfPassedNotSetValue()
        {
            var testParameterTypeValue = BatchFileLineParameterType.NotSet;
            var batchLineParameterTypeTranslator = new BasicBatchFileLineParameterTypeTranslator();

            Assert.Throws<ArgumentException>(() => batchLineParameterTypeTranslator.GetTranslatedValue((int)testParameterTypeValue));
        }

        [Test]
        [TestCase(BatchFileLineParameterType.PackageExecutablePath, ExpectedResult = "")]
        [TestCase(BatchFileLineParameterType.TestsLibraryName, ExpectedResult = "")]
        [TestCase(BatchFileLineParameterType.Target, ExpectedResult = "-target:")]
        [TestCase(BatchFileLineParameterType.Register, ExpectedResult = "-register:")]
        [TestCase(BatchFileLineParameterType.Reports, ExpectedResult = "-reports:")]
        [TestCase(BatchFileLineParameterType.TargetDir, ExpectedResult = "-targetdir:")]
        public string GetTranslatedValue_ShouldReturnCorrectOutput_IfPassedAValidParameter(BatchFileLineParameterType parameterType)
        {
            var batchLineParameterTypeTranslator = new BasicBatchFileLineParameterTypeTranslator();

            var actualResult = batchLineParameterTypeTranslator.GetTranslatedValue((int)parameterType);

            return actualResult;
        }
    }
}
