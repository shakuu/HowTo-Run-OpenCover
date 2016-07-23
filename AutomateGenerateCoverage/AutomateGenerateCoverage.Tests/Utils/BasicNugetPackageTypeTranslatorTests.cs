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
    }
}
