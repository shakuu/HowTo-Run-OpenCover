namespace AutomateGenerateCoverage.Tests.BatchFileGenerating
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using AutomateGenerateCoverage.Contracts;
    using AutomateGenerateCoverage.Contracts.BatchFileGenerating;
    using AutomateGenerateCoverage.Models.Abstract;

    public class BatchFileGenerator : ValidatorProvider, IBatchFileGenerator
    {
        IRootPathFinder rootPathFinder;
        IExecutablePathFinder executablePathFinder;
        IBatchFileLineGenerator batchFileLineGenerator;

        public BatchFileGenerator(
            IRootPathFinder rootPathFinder,
            IExecutablePathFinder executablePathFinder,
            IBatchFileLineGenerator batchFileLineGenerator)
        {
        }

        public BatchFileGenerator(
            IRootPathFinder rootPathFinder,
            IExecutablePathFinder executablePathFinder,
            IBatchFileLineGenerator batchFileLineGenerator,
            IValidate validator)
            : base(validator)
        {
        }

        private IRootPathFinder RootPathFinder
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

        public IEnumerable<FileInfo> GenereteBatchFiles(string inputPathToTestingLibrary)
        {
            throw new NotImplementedException();
        }
    }
}
