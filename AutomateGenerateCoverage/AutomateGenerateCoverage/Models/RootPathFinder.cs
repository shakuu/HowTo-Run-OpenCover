namespace AutomateGenerateCoverage.Models
{
    using System;
    using System.IO;
    using System.Linq;

    using AutomateGenerateCoverage.Contracts;
    using AutomateGenerateCoverage.Models.Abstract;

    public class RootPathFinder : PathFinder, IRootPathFinder
    {
        private const int PathToLibraryFolderDepth = 4;

        public RootPathFinder()
        {

        }

        public RootPathFinder(IValidate validator)
            : base(validator)
        {
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
