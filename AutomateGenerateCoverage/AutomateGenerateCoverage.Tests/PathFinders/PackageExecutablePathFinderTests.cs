namespace AutomateGenerateCoverage.Tests.PathFinders
{
    using System;
    using System.IO;

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
            this.package = NugetPackageType.NUnit;
            this.projectRootDirectory = null;

            //this.packageExecutablePathFinder;

            Assert.Throws<ArgumentNullException>(() => packageExecutablePathFinder.FindPathToExecutable(package, projectRootDirectory));
        }

        [Test]
        public void FindPathToExecutable_ShouldThrow_IfPackageIsNotSet()
        {
            this.package = NugetPackageType.NotSet;
            this.projectRootDirectory = "some\\directory";

            //this.packageExecutablePathFinder;

            Assert.Throws<ArgumentException>(() => packageExecutablePathFinder.FindPathToExecutable(package, projectRootDirectory));
        }

        [Test]
        public void FindPathToExecutable_ShouldThrow_IfDirectoryCannotBeFound()
        {
            this.package = NugetPackageType.NUnit;
            this.projectRootDirectory = "some\\directory";

            //this.packageExecutablePathFinder =

            Assert.Throws<DirectoryNotFoundException>(() => this.packageExecutablePathFinder.FindPathToExecutable(this.package, this.projectRootDirectory));
        }
    }
}
