namespace AutomateGenerateCoverage.Tests.PathFinders
{
    using System;

    using NUnit.Framework;

    using AutomateGenerateCoverage.Contracts;
    using AutomateGenerateCoverage.Enums;

    [TestFixture]
    public class PackageExecutablePathFinderTests
    {
        private NugetPackageType package;
        private string projectRootDirectory;
        private IPathFinder packageExecutablePathFinder;

        [Test]
        public void FindPathToExecutable_ShouldThrow_IfProjectRootDirectoryParameterIsNull()
        {
            package = NugetPackageType.NUnit;
            projectRootDirectory = null;

            //this.packageExecutablePathFinder;

            Assert.Throws<ArgumentNullException>(() => packageExecutablePathFiner.FindPathToExecutable(package, projectRootDirectory));
        }

        [Test]
        public void FindPathToExecutable_ShouldThrow_IfPackageIsNotSet()
        {
            package = NugetPackageType.NotSet;
            projectRootDirectory = "some\\directory";

            //this.packageExecutablePathFinder;

            Assert.Throws<ArgumentException>(() => this.packageExecutablePathFinder.FindPathToExecutable(package, projectRootDirectory));
        }
    }
}
