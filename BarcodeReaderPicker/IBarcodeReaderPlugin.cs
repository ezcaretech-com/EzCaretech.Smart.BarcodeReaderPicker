namespace BarcodeReaderPicker
{
    public interface IBarcodeReaderPlugin
    {
        string Name { get; }

        string Description { get; }

        string[] Execute(string targetFilePath);
    }
}
