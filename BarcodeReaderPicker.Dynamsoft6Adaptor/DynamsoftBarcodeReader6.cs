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
    public class DynamsoftBarcodeReader6 : IBarcodeReaderPlugin
    {
        public string Name => "DynamsoftBarcodeReader6";

        public string Description => "Dynamsoft Barcode Reader SDK plugin.";

        private readonly BarcodeReaderConfig _config;

        public DynamsoftBarcodeReader6(BarcodeReaderConfig config)
        {
            _config = config;
        }

        public string[] Execute(string targetFilePath)
        {
            if (string.IsNullOrEmpty(targetFilePath))
                throw new ArgumentNullException(targetFilePath, nameof(targetFilePath));

            if (!File.Exists(targetFilePath))
                throw new FileNotFoundException(nameof(targetFilePath));

            BarcodeReader barcodeReader = new BarcodeReader
            {
                LicenseKeys = _config.License
            };

            Bitmap bitmap = new Bitmap(targetFilePath);
            TextResult[] array = barcodeReader.DecodeBitmap(bitmap, "");
            string[] result = new string[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                result[i] = array[i].BarcodeText;
            }

            return result;
        }
    }
}
