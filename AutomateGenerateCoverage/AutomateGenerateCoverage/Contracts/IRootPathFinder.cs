namespace AutomateGenerateCoverage.Contracts
{
   public interface IRootPathFinder
    {
        string FindProjectRootPath(string pathToTestingLibrary);
    }
}
