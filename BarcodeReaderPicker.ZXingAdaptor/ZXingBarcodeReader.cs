using System;
using System.Drawing;
using System.IO;
using System.Linq;
using ZXing;

namespace BarcodeReaderPicker.Adaptor
{
    /// <summary>
    /// https://github.com/micjahn/ZXing.Net/
    /// </summary>
    public class ZXingBarcodeReader : IPlugin
    {
        public string Name => "ZXingBarcodeReader";

        public string Description => "IonBarCode for .NET SDK plugin.";

        private readonly Configuration _config;

        public ZXingBarcodeReader(Configuration config)
        {
            _config = config;
        }

        public string[] Execute(string targetFilePath)
        {
            if (string.IsNullOrEmpty(targetFilePath))
                throw new ArgumentNullException(targetFilePath, nameof(targetFilePath));

            if (!File.Exists(targetFilePath))
                throw new FileNotFoundException(nameof(targetFilePath));

            // create a barcode reader instance
            IBarcodeReader reader = new BarcodeReader();
            // load a bitmap
            var barcodeBitmap = (Bitmap)Image.FromFile(targetFilePath);
            // detect and decode the barcode inside the bitmap
            var result = reader.DecodeMultiple(barcodeBitmap);
            // do something with the result
            return result is null ? (new string[] { }) : result.Select(x => x.Text).ToArray();
        }
    }
}
