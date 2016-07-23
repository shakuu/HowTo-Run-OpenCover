namespace AutomateGenerateCoverage.Models
{
    using System;
    using System.IO;
    using System.Linq;

    using AutomateGenerateCoverage.Contracts;

    public class RootPathFinder : IRootPathFinder
    {
        private const int BinFolderDepth = 3;

        private IValidate validator;

        public string FindProjectRootPath(string pathToTestingLibrary)
        {
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

            return outputProjectRootPath;
        }
    }
}
