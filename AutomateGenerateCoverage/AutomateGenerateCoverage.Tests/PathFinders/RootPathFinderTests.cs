namespace AutomateGenerateCoverage.Tests.PathFinders
{
    using System;
    using System.IO;

    using NUnit.Framework;

    using AutomateGenerateCoverage.Contracts;
    using AutomateGenerateCoverage.Models;

    [TestFixture]
    public class RootPathFinderTests
    {
        [Test]
        public void FindProjectRootPath_ShouldThrow_IfPassedNullArgument()
        {
            string pathToTestingLibrary = null;
            IRootPathFinder rootPathFinder;

            Assert.Throws<ArgumentNullException>(() => rootPathFinder.FindProjectRootPath(pathToTestingLibrary));
        }
        
        [Test]
        public void FindProjectRootPath_ShouldThrow_IfFileIsNotFoundAtGivePath()
        {
            var pathToTestingLibrary = "some:\\random\\path\\to.tests.dll";
            IRootPathFinder rootPathFinder;

            Assert.Throws<FileNotFoundException>(() => rootPathFinder.FindProjectRootPath(pathToTestingLibrary));
        }
    }
}
