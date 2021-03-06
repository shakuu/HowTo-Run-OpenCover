﻿namespace AutomateGenerateCoverage.Tests.BatchFileGenerating
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using NUnit.Framework;

    using AutomateGenerateCoverage.Contracts;
    using AutomateGenerateCoverage.Contracts.BatchFileGenerating;
    using AutomateGenerateCoverage.Contracts.IO;
    using AutomateGenerateCoverage.Models;
    using AutomateGenerateCoverage.Models.BatchFileGenerating;
    using AutomateGenerateCoverage.Models.IO;
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

        [Test]
        public void Constructor_ShouldThrow_IfPassedNullRootPathFinder()
        {
            var fileWriter = new FileWriter();
            IRootPathFinder rootPathFinder = null;
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

        [Test]
        public void Constructor_ShouldThrow_IfPassedNullExecutablePathFinder()
        {
            var fileWriter = new FileWriter();
            var rootPathFinder = new RootPathFinder();
            var executableTypeTranslator = new BasicNugetPackageTypeTranslator();
            IExecutablePathFinder executablePathFinder = null;
            var batchFileParameterTypeTranslator = new BasicBatchFileLineParameterTypeTranslator();
            var batchFileLineGenerator = new BatchFileLineGenerator(batchFileParameterTypeTranslator);

            Assert.Throws<ArgumentNullException>(() =>
                new BatchFileGenerator(
                    fileWriter,
                    rootPathFinder,
                    executablePathFinder,
                    batchFileLineGenerator));
        }

        [Test]
        public void Constructor_ShouldThrow_IfPassedNullBatchFileLineGenerator()
        {
            var fileWriter = new FileWriter();
            var rootPathFinder = new RootPathFinder();
            var executableTypeTranslator = new BasicNugetPackageTypeTranslator();
            var executablePathFinder = new PackageExecutablePathFinder(executableTypeTranslator);
            var batchFileParameterTypeTranslator = new BasicBatchFileLineParameterTypeTranslator();
            IBatchFileLineGenerator batchFileLineGenerator = null;

            Assert.Throws<ArgumentNullException>(() =>
                new BatchFileGenerator(
                    fileWriter,
                    rootPathFinder,
                    executablePathFinder,
                    batchFileLineGenerator));
        }

        [Test]
        public void Constructor_ShouldInitializeCorrectly_IfPassedParametersAreCorrect()
        {
            var fileWriter = new FileWriter();
            var rootPathFinder = new RootPathFinder();
            var executableTypeTranslator = new BasicNugetPackageTypeTranslator();
            var executablePathFinder = new PackageExecutablePathFinder(executableTypeTranslator);
            var batchFileParameterTypeTranslator = new BasicBatchFileLineParameterTypeTranslator();
            var batchFileLineGenerator = new BatchFileLineGenerator(batchFileParameterTypeTranslator);

            Assert.DoesNotThrow(() =>
                new BatchFileGenerator(
                    fileWriter,
                    rootPathFinder,
                    executablePathFinder,
                    batchFileLineGenerator));
        }

        [Test]
        public void GenerateBatchFiles_ShouldThrow_IfPassedInputPathToTestingLibraryIsNull()
        {
            var fileWriter = new FileWriter();
            var rootPathFinder = new RootPathFinder();
            var executableTypeTranslator = new BasicNugetPackageTypeTranslator();
            var executablePathFinder = new PackageExecutablePathFinder(executableTypeTranslator);
            var batchFileParameterTypeTranslator = new BasicBatchFileLineParameterTypeTranslator();
            var batchFileLineGenerator = new BatchFileLineGenerator(batchFileParameterTypeTranslator);

            var generateBatchFile = new BatchFileGenerator(
                fileWriter,
                rootPathFinder,
                executablePathFinder,
                batchFileLineGenerator);

            string targetDirectory = "D:\\Homeworkds";

            string path = null;

            var outputFilenames = new List<string>()
            {
                "some",
                "thing"
            };

            Assert.Throws<ArgumentNullException>(() => generateBatchFile.GenereteBatchFiles(path, targetDirectory, outputFilenames));
        }

        [Test]
        public void GenerateBatchFiles_ShouldThrow_IfPassedInputPathToTestingLibraryIsNotAnExistingFile()
        {
            var fileWriter = new FileWriter();
            var rootPathFinder = new RootPathFinder();
            var executableTypeTranslator = new BasicNugetPackageTypeTranslator();
            var executablePathFinder = new PackageExecutablePathFinder(executableTypeTranslator);
            var batchFileParameterTypeTranslator = new BasicBatchFileLineParameterTypeTranslator();
            var batchFileLineGenerator = new BatchFileLineGenerator(batchFileParameterTypeTranslator);

            var generateBatchFile = new BatchFileGenerator(
                fileWriter,
                rootPathFinder,
                executablePathFinder,
                batchFileLineGenerator);

            string targetDirectory = "D:\\Homeworkds";

            string path = "some\\random\\path";

            var outputFilenames = new List<string>()
            {
                "some",
                "thing"
            };

            Assert.Throws<FileNotFoundException>(() => generateBatchFile.GenereteBatchFiles(path, targetDirectory, outputFilenames));
        }

        [Test]
        public void GenerateBatchFiles_ShouldThrow_IfPassedOutputFilenamesIsNull()
        {
            var fileWriter = new FileWriter();
            var rootPathFinder = new RootPathFinder();
            var executableTypeTranslator = new BasicNugetPackageTypeTranslator();
            var executablePathFinder = new PackageExecutablePathFinder(executableTypeTranslator);
            var batchFileParameterTypeTranslator = new BasicBatchFileLineParameterTypeTranslator();
            var batchFileLineGenerator = new BatchFileLineGenerator(batchFileParameterTypeTranslator);

            var generateBatchFile = new BatchFileGenerator(
                fileWriter,
                rootPathFinder,
                executablePathFinder,
                batchFileLineGenerator);

            string targetDirectory = "D:\\Homeworkds";

            string path = "D:\\Homeworks\\test.txt";

            IList<string> outputFilenames = null;

            Assert.Throws<ArgumentNullException>(() => generateBatchFile.GenereteBatchFiles(path, targetDirectory, outputFilenames));
        }

        [Test]
        public void GenerateBatchFiles_ShouldThrow_IfPassedOutputFilenamesHasNullOrEmptyItems()
        {
            var fileWriter = new FileWriter();
            var rootPathFinder = new RootPathFinder();
            var executableTypeTranslator = new BasicNugetPackageTypeTranslator();
            var executablePathFinder = new PackageExecutablePathFinder(executableTypeTranslator);
            var batchFileParameterTypeTranslator = new BasicBatchFileLineParameterTypeTranslator();
            var batchFileLineGenerator = new BatchFileLineGenerator(batchFileParameterTypeTranslator);

            var generateBatchFile = new BatchFileGenerator(
                fileWriter,
                rootPathFinder,
                executablePathFinder,
                batchFileLineGenerator);

            string targetDirectory = "D:\\Homeworkds";
            string path = "D:\\Homeworks\\test.txt";

            var outputFilenames = new List<string>()
            {
                "some",
                string.Empty
            };

            Assert.Throws<ArgumentNullException>(() => generateBatchFile.GenereteBatchFiles(path, targetDirectory, outputFilenames));
        }

        [Test]
        public void GenerateBatchFiles_ShouldReturnTwoExistingFileNames_IfPassedValidInput()
        {
            var fileWriter = new FileWriter();
            var rootPathFinder = new RootPathFinder();
            var executableTypeTranslator = new BasicNugetPackageTypeTranslator();
            var executablePathFinder = new PackageExecutablePathFinder(executableTypeTranslator);
            var batchFileParameterTypeTranslator = new BasicBatchFileLineParameterTypeTranslator();
            var batchFileLineGenerator = new BatchFileLineGenerator(batchFileParameterTypeTranslator);

            var generateBatchFile = new BatchFileGenerator(
                fileWriter,
                rootPathFinder,
                executablePathFinder,
                batchFileLineGenerator);

            string targetDirectory = @"D:\Homeworks\results";
            string path = @"D:\GitHub\HowTo-Run-OpenCover\AutomateGenerateCoverage\AutomateGenerateCoverage.Tests\bin\Debug\AutomateGenerateCoverage.Tests.dll";

            var outputFilenames = new List<string>()
            {
                @"D:\Homeworks\runtests.bat",
                @"D:\Homeworks\getresults.bat"
            };

            var actualResult = generateBatchFile.GenereteBatchFiles(path, targetDirectory, outputFilenames);

            foreach (var fildePath in actualResult)
            {
                Assert.IsTrue(File.Exists(fildePath.FullName));
            }
        }
    }
}
