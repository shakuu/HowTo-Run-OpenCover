namespace AutomateGenerateCoverage.Tests.PathFinders
{
    using System;
    using System.IO;

    using NUnit.Framework;

    using AutomateGenerateCoverage.Contracts;
    using AutomateGenerateCoverage.Models;
    using AutomateGenerateCoverage.Utils;

    // TODO: How to test relative paths ?

    [TestFixture]
    public class RootPathFinderTests
    {
        [Test]
        public void ConstructorWithParameter_ShouldThrow_IfPassedANullObjectAsParameter()
        {
            IValidate validator = null;

            Assert.Throws<ArgumentNullException>(() => new RootPathFinder(validator));
        }

        [Test]
        public void ConstructorWithParameter_ShouldNotThrow_IfPassedAValidIValidateObjectAsParameter()
        {
            IValidate validator = new Validator();

            Assert.DoesNotThrow(() => new RootPathFinder(validator));
        }

        [Test]
        public void FindProjectRootPath_ShouldThrow_IfPassedNullArgument()
        {
            string pathToTestingLibrary = null;
            IRootPathFinder rootPathFinder = new RootPathFinder();

            Assert.Throws<ArgumentNullException>(() => rootPathFinder.FindProjectRootPath(pathToTestingLibrary));
        }

        [Test]
        public void FindProjectRootPath_ShouldThrow_IfFileIsNotFoundAtGivePath()
        {
            var pathToTestingLibrary = "some:\\random\\path\\very\\deep\\debug\\bin\\to.tests.dll";
            IRootPathFinder rootPathFinder = new RootPathFinder();

            Assert.Throws<FileNotFoundException>(() => rootPathFinder.FindProjectRootPath(pathToTestingLibrary));
        }

        [Test]
        public void FindProjectRootPath_ShouldThrow_IfNewlyGenerateFolderDoesNotExist()
        {
            var pathToTestingLibrary = @"D:\SamplePeople.csv";
            IRootPathFinder rootPathFinder = new RootPathFinder();

            Assert.Throws<DirectoryNotFoundException>(() => rootPathFinder.FindProjectRootPath(pathToTestingLibrary));
        }

        [Test]
        [TestCase(@"D:\GitHub\HowTo-Run-OpenCover\AutomateGenerateCoverage\AutomateGenerateCoverage.Tests\bin\Debug\AutomateGenerateCoverage.Tests.dll", ExpectedResult = @"D:\GitHub\HowTo-Run-OpenCover\AutomateGenerateCoverage")]
        public string FindProjectRoot_ShouldFindCorrectProjectPath_IfInputParameterIsACorrectProjectPathWithDefaultProjectStructure(string pathToTestingLibrary)
        {
            IRootPathFinder rootPathFinder = new RootPathFinder();

            var actualResult = rootPathFinder.FindProjectRootPath(pathToTestingLibrary);

            return actualResult;
        }
    }
}
