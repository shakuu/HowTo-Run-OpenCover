namespace AutomateGenerateCoverage.Tests.BatchFileGenerating
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    using AutomateGenerateCoverage.Contracts.BatchFileGenerating;
    using AutomateGenerateCoverage.Models.BatchFileGenerating;
    using AutomateGenerateCoverage.Enums;

    [TestFixture]
    public class BatchFileLineGeneratorTests
    {
        [Test]
        public void GenerateBatchFileLine_ShouldThrow_IfParametersIsNull()
        {
            ICollection<BatchFileLineParameterType> parameters = null;
            ICollection<string> values = new List<string>();

            IBatchFileLineGenerator lineGenerator = new BatchFileLineGenerator();

            Assert.Throws<ArgumentNullException>(() => lineGenerator.GenerateBatchFileLine(parameters, values));
        }

        [Test]
        public void GenerateBatchFileLine_ShouldThrow_IfValuesIsNull()
        {
            ICollection<BatchFileLineParameterType> parameters = new List<BatchFileLineParameterType>();
            ICollection<string> values = null;

            IBatchFileLineGenerator lineGenerator = new BatchFileLineGenerator();

            Assert.Throws<ArgumentNullException>(() => lineGenerator.GenerateBatchFileLine(parameters, values));
        }

        [Test]
        public void GenerateBatchFileLine_ShouldThrow_IfAnyOfTheStringsInValuesAreNullOrEmpty()
        {
            var parameters = new List<BatchFileLineParameterType>()
            {
                BatchFileLineParameterType.PackageExecutablePath,
                BatchFileLineParameterType.TestsLibraryName
            };

            var values = new List<string>()
            {
                "testing",
                string.Empty
            };

            IBatchFileLineGenerator lineGenerator = new BatchFileLineGenerator();

            Assert.Throws<ArgumentNullException>(() => lineGenerator.GenerateBatchFileLine(parameters, values));
        }

        [Test]
        public void GenerateBatchFileLine_ShouldThrow_IfTheNumberOfParametersIsNotEqulToTheNumberOfValues()
        {
            var parameters = new List<BatchFileLineParameterType>()
            {
                BatchFileLineParameterType.PackageExecutablePath,
                BatchFileLineParameterType.TestsLibraryName
            };

            var values = new List<string>()
            {
                "testing",
                "value",
                "more than"
            };

            IBatchFileLineGenerator lineGenerator = new BatchFileLineGenerator();

            Assert.Throws<ArgumentException>(() => lineGenerator.GenerateBatchFileLine(parameters, values));
        }

    }
}
