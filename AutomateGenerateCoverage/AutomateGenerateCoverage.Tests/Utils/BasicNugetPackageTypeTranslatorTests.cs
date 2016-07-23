namespace AutomateGenerateCoverage.Tests.Utils
{
    using System;

    using NUnit.Framework;

    using AutomateGenerateCoverage.Contracts;
    using AutomateGenerateCoverage.Enums;
    using AutomateGenerateCoverage.Utils;

    [TestFixture]
    public class BasicNugetPackageTypeTranslatorTests
    {
        private ITypeTranslator typeTranslator;

        [Test]
        public void GetTranslatedValue_ShouldThrow_IfPassedValueIsNotSet()
        {
            this.typeTranslator = new BasicNugetPackageTypeTranslator();
            var typeValue = NugetPackageType.NotSet;

            Assert.Throws<ArgumentException>(() => typeTranslator.GetTranslatedValue((int)typeValue));
        }

        [Test]
        [TestCase(NugetPackageType.NUnit, ExpectedResult = "nunit3-console.exe")]
        [TestCase(NugetPackageType.OpenCover, ExpectedResult = "OpenCover.Console.exe")]
        [TestCase(NugetPackageType.ReportGenerator, ExpectedResult = "ReportGenerator.exe")]
        public string GetTranslatedValue_ShouldReturnTheCorrectString(NugetPackageType packageType)
        {
            this.typeTranslator = new BasicNugetPackageTypeTranslator();

            var actualResult = typeTranslator.GetTranslatedValue((int)packageType);

            return actualResult;
        }
    }
}
