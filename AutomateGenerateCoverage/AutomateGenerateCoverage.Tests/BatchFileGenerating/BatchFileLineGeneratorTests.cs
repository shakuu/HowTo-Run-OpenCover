﻿namespace AutomateGenerateCoverage.Tests.BatchFileGenerating
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    using AutomateGenerateCoverage.Contracts;
    using AutomateGenerateCoverage.Contracts.BatchFileGenerating;
    using AutomateGenerateCoverage.Models.BatchFileGenerating;
    using AutomateGenerateCoverage.Enums;
    using AutomateGenerateCoverage.Utils;

    using AutomateGenerateCoverage.Tests.Data;

    [TestFixture]
    public class BatchFileLineGeneratorTests
    {
        [Test]
        public void Constructor_ShouldThrow_IfPassedANullITypeTranslator()
        {
            ITypeTranslator batchFileParameterTranslator = null;

            Assert.Throws<ArgumentNullException>(() => new BatchFileLineGenerator(batchFileParameterTranslator));
        }

        [Test]
        public void GenerateBatchFileLine_ShouldThrow_IfParametersIsNull()
        {
            IList<BatchFileLineParameterType> parameters = null;
            IList<string> values = new List<string>();
            var batchFileParameterTranslator = new BasicBatchFileLineParameterTypeTranslator();

            IBatchFileLineGenerator lineGenerator = new BatchFileLineGenerator(batchFileParameterTranslator);

            Assert.Throws<ArgumentNullException>(() => lineGenerator.GenerateBatchFileLine(parameters, values));
        }

        [Test]
        public void GenerateBatchFileLine_ShouldThrow_IfValuesIsNull()
        {
            IList<BatchFileLineParameterType> parameters = new List<BatchFileLineParameterType>();
            IList<string> values = null;
            var batchFileParameterTranslator = new BasicBatchFileLineParameterTypeTranslator();

            IBatchFileLineGenerator lineGenerator = new BatchFileLineGenerator(batchFileParameterTranslator);

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

            var batchFileParameterTranslator = new BasicBatchFileLineParameterTypeTranslator();

            IBatchFileLineGenerator lineGenerator = new BatchFileLineGenerator(batchFileParameterTranslator);

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

            var batchFileParameterTranslator = new BasicBatchFileLineParameterTypeTranslator();

            IBatchFileLineGenerator lineGenerator = new BatchFileLineGenerator(batchFileParameterTranslator);

            Assert.Throws<ArgumentException>(() => lineGenerator.GenerateBatchFileLine(parameters, values));
        }

        [Test]
        [TestCaseSource(typeof(BatchFileLineGeneratorTestsData), "GenerateBatchFileLineTestCases")]
        public string GenerateBatchFileLine_ShouldReturnACorrectString_IfPassedCorrectParameters(IList<BatchFileLineParameterType> parameters, IList<string> values)
        {
            var batchFileParameterTranslator = new BasicBatchFileLineParameterTypeTranslator();

            IBatchFileLineGenerator lineGenerator = new BatchFileLineGenerator(batchFileParameterTranslator);

            var actualResult = lineGenerator.GenerateBatchFileLine(parameters, values);

            return actualResult;
        }
    }
}
