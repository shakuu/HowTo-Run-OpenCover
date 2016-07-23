namespace AutomateGenerateCoverage.Models.BatchFileGenerating
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using AutomateGenerateCoverage.Contracts;
    using AutomateGenerateCoverage.Contracts.BatchFileGenerating;
    using AutomateGenerateCoverage.Contracts.IO;
    using AutomateGenerateCoverage.Models.Abstract;
    using AutomateGenerateCoverage.Enums;

    public class BatchFileGenerator : ValidatorProvider, IBatchFileGenerator
    {
        private const string RegisterValue = "user";
        private const string ReportsValue = "results.xml";

        IRootPathFinder rootPathFinder;
        IExecutablePathFinder executablePathFinder;
        IBatchFileLineGenerator batchFileLineGenerator;
        IFileWriter fileWriter;

        public BatchFileGenerator(
            IFileWriter fileWriter,
            IRootPathFinder rootPathFinder,
            IExecutablePathFinder executablePathFinder,
            IBatchFileLineGenerator batchFileLineGenerator)
        {
            this.FileWriter = fileWriter;
            this.RootPathFinder = rootPathFinder;
            this.ExecutablePathFinder = executablePathFinder;
            this.BatchFileLineGenerator = batchFileLineGenerator;
        }

        public BatchFileGenerator(
            IFileWriter fileWriter,
            IRootPathFinder rootPathFinder,
            IExecutablePathFinder executablePathFinder,
            IBatchFileLineGenerator batchFileLineGenerator,
            IValidate validator)
            : base(validator)
        {
            this.FileWriter = fileWriter;
            this.RootPathFinder = rootPathFinder;
            this.ExecutablePathFinder = executablePathFinder;
            this.BatchFileLineGenerator = batchFileLineGenerator;
        }

        public IFileWriter FileWriter
        {
            get
            {
                return this.fileWriter;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(FileWriter));
                }

                this.fileWriter = value;
            }
        }

        public IRootPathFinder RootPathFinder
        {
            get
            {
                return this.rootPathFinder;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(RootPathFinder));
                }

                this.rootPathFinder = value;
            }
        }

        public IExecutablePathFinder ExecutablePathFinder
        {
            get
            {
                return this.executablePathFinder;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(ExecutablePathFinder));
                }

                this.executablePathFinder = value;
            }
        }

        public IBatchFileLineGenerator BatchFileLineGenerator
        {
            get
            {
                return this.batchFileLineGenerator;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(BatchFileLineGenerator));
                }

                this.batchFileLineGenerator = value;
            }
        }

        public IEnumerable<FileInfo> GenereteBatchFiles(string inputPathToTestingLibrary, string targetDirectory, IList<string> outputFilenames)
        {
            var batchFileLines = new List<string>();

            this.ValidateGenerateBatchFilesInputFilePath(inputPathToTestingLibrary);
            this.ValidateGenerateBatchFilesOutputFilenames(outputFilenames);

            var testingLibraryAsFileInfo = new FileInfo(inputPathToTestingLibrary);
            var projectRootDirectory = this.RootPathFinder.FindProjectRootPath(inputPathToTestingLibrary);
            var nUnitExecutableFilePath = this.executablePathFinder.FindPathToExecutable(NugetPackageType.NUnit, projectRootDirectory);
            var openCoverExecutableFilePath = this.executablePathFinder.FindPathToExecutable(NugetPackageType.OpenCover, projectRootDirectory);
            var reportGeneratorExecutableFilePath = this.executablePathFinder.FindPathToExecutable(NugetPackageType.ReportGenerator, projectRootDirectory);

            batchFileLines.Add(this.GenerateLineFileOneLineOne(nUnitExecutableFilePath, testingLibraryAsFileInfo.FullName));
            batchFileLines.Add(this.GenerateLineFileTwoLineOne(openCoverExecutableFilePath, outputFilenames[0]));
            batchFileLines.Add(this.GenerateLineFileTwoLineTwo(reportGeneratorExecutableFilePath, targetDirectory));

            this.FileWriter.WriteToFile(outputFilenames[0], new List<string>() { batchFileLines[0] });
            this.FileWriter.WriteToFile(outputFilenames[1], new List<string>() { batchFileLines[1], batchFileLines[2] });

            var outputFilesInfo = new List<FileInfo>()
            {
                new FileInfo(outputFilenames[0]),
                new FileInfo(outputFilenames[1])
            };

            return outputFilesInfo;
        }

        private string GenerateLineFileOneLineOne(string nUnitExecutablePath, string testingLibraryFileName)
        {
            var parameters = new List<BatchFileLineParameterType>()
            {
                BatchFileLineParameterType.PackageExecutablePath,
                BatchFileLineParameterType.TestsLibraryName
            };

            var values = new List<string>()
            {
                nUnitExecutablePath,
                testingLibraryFileName
            };

            var fileOneLineOne = this.BatchFileLineGenerator.GenerateBatchFileLine(parameters, values);

            return fileOneLineOne;
        }

        private string GenerateLineFileTwoLineOne(string openCoverExecutablePath, string outputFilenameTests)
        {
            var parameters = new List<BatchFileLineParameterType>()
            {
                BatchFileLineParameterType.PackageExecutablePath,
                BatchFileLineParameterType.Target,
                BatchFileLineParameterType.Register
            };

            var values = new List<string>()
            {
                openCoverExecutablePath,
                outputFilenameTests,
                BatchFileGenerator.RegisterValue
            };

            var fileTwoLineOne = this.BatchFileLineGenerator.GenerateBatchFileLine(parameters, values);

            return fileTwoLineOne;
        }

        private string GenerateLineFileTwoLineTwo(string reportGeneratorExecutablePath, string targetDirectory)
        {
            var parameters = new List<BatchFileLineParameterType>()
            {
                BatchFileLineParameterType.PackageExecutablePath,
                BatchFileLineParameterType.Reports,
                BatchFileLineParameterType.TargetDir
            };

            var values = new List<string>()
            {
                reportGeneratorExecutablePath,
                BatchFileGenerator.ReportsValue,
                targetDirectory
            };

            var fileTwoLineTwo = this.BatchFileLineGenerator.GenerateBatchFileLine(parameters, values);

            return fileTwoLineTwo;
        }

        private void ValidateGenerateBatchFilesInputFilePath(string inputPathToTestingLibrary)
        {
            if (base.Validator.CheckIfStringIsNullOrEmpty(inputPathToTestingLibrary))
            {
                throw new ArgumentNullException(nameof(inputPathToTestingLibrary));
            }

            if (!base.Validator.CheckIfFileExistsAtInputPath(inputPathToTestingLibrary))
            {
                throw new FileNotFoundException(inputPathToTestingLibrary);
            }
        }

        private void ValidateGenerateBatchFilesOutputFilenames(IEnumerable<string> outputFilenames)
        {
            if (base.Validator.CheckIfObjectIsNull(outputFilenames))
            {
                throw new ArgumentNullException(nameof(outputFilenames));
            }

            foreach (var str in outputFilenames)
            {
                if (base.Validator.CheckIfStringIsNullOrEmpty(str))
                {
                    throw new ArgumentNullException(nameof(outputFilenames));
                }
            }
        }
    }
}
