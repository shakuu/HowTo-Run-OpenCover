namespace AutomateGenerateCoverage.Tests.BatchFileGenerating
{
    using System;

    using NUnit.Framework;

    using AutomateGenerateCoverage.Contracts.IO;
    using AutomateGenerateCoverage.Models;
    using AutomateGenerateCoverage.Models.BatchFileGenerating;
    using AutomateGenerateCoverage.Utils;

    [TestFixture]
    public class BatchFileGeneratorTests
    {
        [Test]
        public void Constructor_ShouldThrow_IfPassedNullFileWriter()
        {
            IFileWriter fileWriter = null;
            var rootPathFinder = new RootPathFinder();
            var executableTypeTranslator = new BasicNugetPackageTypeTranslator();
            var executablePathFinder = new PackageExecutablePathFinder(executableTypeTranslator);
            var batchFileParameterTypeTranslator = new BasicBatchFileLineParameterTypeTranslator();
            var batchFileLineGenerator = new BatchFileLineGenerator(batchFileParameterTypeTranslator);

            Assert.Throws<ArgumentNullException>(() =>
                new BatchFileGenerator(
                    fileWriter,
                    rootPathFinder,
                    executablePathFinder,
                    batchFileLineGenerator));
        }
    }
}
