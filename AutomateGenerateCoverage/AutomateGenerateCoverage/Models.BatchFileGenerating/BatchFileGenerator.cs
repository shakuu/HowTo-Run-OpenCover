namespace AutomateGenerateCoverage.Models.BatchFileGenerating
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using AutomateGenerateCoverage.Contracts;
    using AutomateGenerateCoverage.Contracts.BatchFileGenerating;
    using AutomateGenerateCoverage.Contracts.IO;
    using AutomateGenerateCoverage.Models.Abstract;

    public class BatchFileGenerator : ValidatorProvider, IBatchFileGenerator
    {
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

        public IEnumerable<FileInfo> GenereteBatchFiles(string inputPathToTestingLibrary, IEnumerable<string> outputFilenames)
        {
            this.ValidateGenerateBatchFilesInputFilePath(inputPathToTestingLibrary);
            this.ValidateGenerateBatchFilesOutputFilenames(outputFilenames);
            
            throw new NotImplementedException();
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
