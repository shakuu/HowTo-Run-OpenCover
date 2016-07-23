namespace AutomateGenerateCoverage.Contracts
{
    using AutomateGenerateCoverage.Enums;

    public interface IPathFinder
    {
        string FindPathToExecutable(NugetPackageType package, string projectRootDirectory);
    }
}
