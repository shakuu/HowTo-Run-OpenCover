namespace AutomateGenerateCoverage.Contracts
{
    using AutomateGenerateCoverage.Enums;

    public interface IExecutablePathFinder
    {
        string FindPathToExecutable(NugetPackageType package, string projectRootDirectory);
    }
}
