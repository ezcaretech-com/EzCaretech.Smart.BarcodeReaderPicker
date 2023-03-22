using Dynamsoft.Barcode;
using System;
using System.Drawing;
using System.IO;

namespace BarcodeReaderPicker.Adaptor
{
    using BarcodeReader = Dynamsoft.Barcode.BarcodeReader;

    /// <summary>
    /// https://www.dynamsoft.com/barcode-reader/overview/
    /// </summary>
    public class DynamsoftBarcodeReader5 : IBarcodeReaderPlugin
    {
        public string Name => "DynamsoftBarcodeReader5";

        public string Description => "Dynamsoft Barcode Reader SDK plugin.";

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

            BarcodeReader barcodeReader = new BarcodeReader
            {
                LicenseKeys = license
            };

            Bitmap bitmap = new Bitmap(targetFilePath);
            BarcodeResult[] array = barcodeReader.DecodeBitmap(bitmap);
            string[] result = new string[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                result[i] = array[i].BarcodeText;
            }

            return result;
        }
    }
}
