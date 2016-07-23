namespace AutomateGenerateCoverage.Models
{
    using System;
    using System.IO;
    using System.Linq;

    using AutomateGenerateCoverage.Contracts;
    using AutomateGenerateCoverage.Utils;

    public class RootPathFinder : IRootPathFinder
    {
        private const int BinFolderDepth = 4;

        private IValidate validator;

        public string FindProjectRootPath(string pathToTestingLibrary)
        {
            this.InitializeValidator(new Validator());

            if (this.validator.CheckIfStringIsNullOrEmpty(pathToTestingLibrary))
            {
                throw new ArgumentNullException(nameof(pathToTestingLibrary));
            }

            if (!this.validator.CheckIfFileExistsAtInputPath(pathToTestingLibrary))
            {
                throw new FileNotFoundException(nameof(pathToTestingLibrary));
            }

            var pathAsArray = pathToTestingLibrary
                .Split(new[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
            var outputProjectRootPath = string.Join("\\", pathAsArray.Take(pathAsArray.Length - RootPathFinder.BinFolderDepth));

            if (!this.validator.CheckIfFolderExistsAtInputPath(outputProjectRootPath))
            {
                throw new DirectoryNotFoundException(nameof(outputProjectRootPath));
            }

            this.DestroyValidator();
            return outputProjectRootPath;
        }

        private void InitializeValidator(IValidate validator)
        {
            this.validator = validator;
        }

        private void DestroyValidator()
        {
            this.validator = null;
        }
    }
}
