namespace BarcodeReaderPicker.Adaptor
{
    using System.IO;
    using System;
    using BarcodeReader = BarcodeLib.BarcodeReader.BarcodeReader;

    /// <summary>
    /// http://www.barcodelib.com/net_barcode_reader/main.html
    /// </summary>
    public class BarcodeLibReader : IBarcodeReaderPlugin
    {
        public string Name => "BarcodeLibReader";

        public string Description => ".NET Barcode Reader SDK plugin.";

        private string license = string.Empty;

        public void SetLicense(string license)
        {
            this.license = license;
        }

        public string[] Execute(string targetFilePath)
        {
            if (string.IsNullOrEmpty(targetFilePath))
                throw new ArgumentNullException(targetFilePath, nameof(targetFilePath));

            if (!File.Exists(targetFilePath))
                throw new FileNotFoundException(nameof(targetFilePath));

            return BarcodeReader.read(targetFilePath, BarcodeReader.PDF417);
        }
    }
}
