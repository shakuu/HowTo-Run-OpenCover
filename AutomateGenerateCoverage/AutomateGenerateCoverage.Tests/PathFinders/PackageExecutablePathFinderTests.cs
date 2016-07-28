namespace AutomateGenerateCoverage.Tests.PathFinders
{
    using System;
    using System.IO;

    using Moq;
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
            this.projectRootDirectory = @"D:\GitHub\SantaseGameEngine\Source\packages\ReportGenerator.2.4.5.0\tools";
            this.nugetPackageTranslator = new BasicNugetPackageTypeTranslator();

            this.packageExecutablePathFinder = new PackageExecutablePathFinder(nugetPackageTranslator);

            Assert.Throws<FileNotFoundException>(() => this.packageExecutablePathFinder.FindPathToExecutable(this.package, this.projectRootDirectory));
        }

        [Test]
        [TestCase(NugetPackageType.NUnit, ExpectedResult = @"D:\GitHub\SantaseGameEngine\Source\packages\NUnit.ConsoleRunner.3.4.1\tools\nunit3-console.exe")]
        [TestCase(NugetPackageType.OpenCover, ExpectedResult = @"D:\GitHub\SantaseGameEngine\Source\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe")]
        [TestCase(NugetPackageType.ReportGenerator, ExpectedResult = @"D:\GitHub\SantaseGameEngine\Source\packages\ReportGenerator.2.4.5.0\tools\ReportGenerator.exe")]
        public string FindPathToExecutable_ShouldFindTheCorrectPath_IfParametersPassedAreValid(NugetPackageType pacakgeType)
        {
            this.nugetPackageTranslator = new BasicNugetPackageTypeTranslator();
            this.packageExecutablePathFinder = new PackageExecutablePathFinder(nugetPackageTranslator);

            var directory = @"D:\GitHub\SantaseGameEngine\Source\Santase.Logic.Tests\bin\Debug\Santase.Logic.Tests.dll";
            var rootDirectoryParser = new RootPathFinder();
            var rootDirectory = rootDirectoryParser.FindProjectRootPath(directory);

            var actualResult = this.packageExecutablePathFinder.FindPathToExecutable(pacakgeType, rootDirectory);

            return actualResult;
        }
    }
}
