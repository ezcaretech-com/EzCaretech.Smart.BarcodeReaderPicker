using System;

namespace BarcodeReaderPicker
{
    public interface IBarcodeReaderPlugin
    {
        string Name { get; }

        string Description { get; }

        void SetLicense(string license);

        string[] Execute(string targetFilePath);
    }
}
