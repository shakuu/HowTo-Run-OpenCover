namespace AutomateGenerateCoverage.Tests.BatchFileGenerating
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    using AutomateGenerateCoverage.Contracts.BatchFileGenerating;
    using AutomateGenerateCoverage.Models;
    using AutomateGenerateCoverage.Enums;

    [TestFixture]
    public class BatchFileLineGeneratorTests
    {
        [Test]
        public void GenerateBatchFileLine_ShouldThrow_IfParametersIsNull()
        {
            IEnumerable<BatchFileLineParameterType> parameters = null;
            IEnumerable<string> values = new List<string>();

            IBatchFileLineGenerator lineGenerator;

            Assert.Throws<ArgumentNullException>(() => lineGenerator.GenerateBatchFileLine(parameters, values));
        }

        [Test]
        public void GenerateBatchFileLine_ShouldThrow_IfValuesIsNull()
        {
            IEnumerable<BatchFileLineParameterType> parameters = new List<BatchFileLineParameterType>();
            IEnumerable<string> values = null;

            IBatchFileLineGenerator lineGenerator;

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

            IBatchFileLineGenerator lineGenerator;

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

            IBatchFileLineGenerator lineGenerator;

            Assert.Throws<ArgumentNullException>(() => lineGenerator.GenerateBatchFileLine(parameters, values));
        }

    }
}
