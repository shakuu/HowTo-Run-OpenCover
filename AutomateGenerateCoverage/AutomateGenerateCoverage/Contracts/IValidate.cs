namespace AutomateGenerateCoverage.Contracts
{
    public interface IValidate
    {
        bool CheckIfObjectIsNull(object obj);

        bool CheckIfStringIsNullOrEmpty(string str);

        bool CheckIfFolderExistsAtInputPath(string inputPath);
    }
}
