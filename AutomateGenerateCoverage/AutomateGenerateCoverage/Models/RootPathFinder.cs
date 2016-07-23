namespace AutomateGenerateCoverage.Models
{
    using System;
    using System.IO;
    using System.Linq;

    using AutomateGenerateCoverage.Contracts;
    using AutomateGenerateCoverage.Utils;

    public class RootPathFinder : IRootPathFinder
    {
        private const int PathToLibraryFolderDepth = 4;

        private IValidate validator;

        public RootPathFinder()
        {

        }

        public RootPathFinder(IValidate validator)
        {
            this.Validator = validator;
        }

        /// <summary>
        /// Initialize default validator if none is passed.
        /// </summary>
        private IValidate Validator
        {
            get
            {
                if (this.validator == null)
                {
                    this.validator = new Validator();
                }

                return this.validator;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                this.validator = value;
            }
        }

        public string FindProjectRootPath(string pathToTestingLibrary)
        {
            if (this.Validator.CheckIfStringIsNullOrEmpty(pathToTestingLibrary))
            {
                throw new ArgumentNullException(nameof(pathToTestingLibrary));
            }

            if (!this.Validator.CheckIfFileExistsAtInputPath(pathToTestingLibrary))
            {
                throw new FileNotFoundException(nameof(pathToTestingLibrary));
            }

            var pathAsArray = pathToTestingLibrary.Split(new[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
            var outputProjectRootPath = string.Join("\\", pathAsArray.Take(pathAsArray.Length - RootPathFinder.PathToLibraryFolderDepth));

            if (!this.Validator.CheckIfFolderExistsAtInputPath(outputProjectRootPath))
            {
                throw new DirectoryNotFoundException(nameof(outputProjectRootPath));
            }

            return outputProjectRootPath;
        }
    }
}
