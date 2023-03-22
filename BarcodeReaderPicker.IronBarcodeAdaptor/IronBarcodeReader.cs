using IronBarCode;
using System;
using System.IO;

namespace BarcodeReaderPicker.Adaptor
{
    using BarcodeReader = IronBarCode.BarcodeReader;

    /// <summary>
    /// https://ironsoftware.com/csharp/barcode/
    /// </summary>
    public class IronBarcodeReader : IBarcodeReaderPlugin
    {
        public string Name => "IronBarcodeReader";

        public string Description => "IonBarCode for .NET SDK plugin.";

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

            License.LicenseKey = license;

            BarcodeResult result = BarcodeReader.QuicklyReadOneBarcode(targetFilePath, BarcodeEncoding.All, true);

            return new string[] { result?.Text };
        }
    }
}
