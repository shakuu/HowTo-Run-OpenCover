namespace AutomateGenerateCoverage.Contracts.IO
{
    using System.Collections;

    public interface IFileWriter
    {
        bool WriteToFile(string fullFileNameWithPath, IEnumerable dataToWrite);
    }
}
