namespace BarcodeReaderPicker
{
    public interface IPlugin
    {
        string Name { get; }

        string Description { get; }

        string[] Execute(string targetFilePath);
    }
}
