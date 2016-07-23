namespace AutomateGenerateCoverage.Tests.PathFinders
{
    using System;
    using System.IO;

    using NUnit.Framework;

    using AutomateGenerateCoverage.Contracts;
    using AutomateGenerateCoverage.Models;
    using AutomateGenerateCoverage.Enums;
    using AutomateGenerateCoverage.Utils;

    [TestFixture]
    public class PackageExecutablePathFinderTests
    {
        private NugetPackageType package;
        private string projectRootDirectory;
        private IExecutablePathFinder packageExecutablePathFinder;
        private ITypeTranslator nugetPackageTranslator;

        [Test]
        public void FindPathToExecutable_ShouldThrow_IfProjectRootDirectoryParameterIsNull()
        {
            this.package = NugetPackageType.NUnit;
            this.projectRootDirectory = null;
            this.nugetPackageTranslator = new BasicNugetPackageTypeTranslator();

            this.packageExecutablePathFinder = new PackageExecutablePathFinder(nugetPackageTranslator);

            Assert.Throws<ArgumentNullException>(() => packageExecutablePathFinder.FindPathToExecutable(package, projectRootDirectory));
        }

        [Test]
        public void FindPathToExecutable_ShouldThrow_IfPackageIsNotSet()
        {
            this.package = NugetPackageType.NotSet;
            this.projectRootDirectory = "D:\\Github";
            this.nugetPackageTranslator = new BasicNugetPackageTypeTranslator();

            this.packageExecutablePathFinder = new PackageExecutablePathFinder(nugetPackageTranslator);

            Assert.Throws<ArgumentException>(() => packageExecutablePathFinder.FindPathToExecutable(package, projectRootDirectory));
        }

        [Test]
        public void FindPathToExecutable_ShouldThrow_IfDirectoryCannotBeFound()
        {
            this.package = NugetPackageType.NUnit;
            this.projectRootDirectory = "some\\directory";
            this.nugetPackageTranslator = new BasicNugetPackageTypeTranslator();

            this.packageExecutablePathFinder = new PackageExecutablePathFinder(nugetPackageTranslator);

            Assert.Throws<DirectoryNotFoundException>(() => this.packageExecutablePathFinder.FindPathToExecutable(this.package, this.projectRootDirectory));
        }

        [Test]
        public void FindPathToExecutable_ShouldThrow_IfPacakgeExecutableCannotBeFound()
        {
            this.package = NugetPackageType.NUnit;
            this.projectRootDirectory = "D:\\Github";
            this.nugetPackageTranslator = new BasicNugetPackageTypeTranslator();

            this.packageExecutablePathFinder = new PackageExecutablePathFinder(nugetPackageTranslator);

            Assert.Throws<FileNotFoundException>(() => this.packageExecutablePathFinder.FindPathToExecutable(this.package, this.projectRootDirectory));
        }

    }
}
