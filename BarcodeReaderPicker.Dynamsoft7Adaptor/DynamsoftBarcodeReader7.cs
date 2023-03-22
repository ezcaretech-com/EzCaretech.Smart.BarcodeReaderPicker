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
    public class DynamsoftBarcodeReader7 : IBarcodeReaderPlugin
    {
        public string Name => "DynamsoftBarcodeReader7";

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

            string[] licenseStrArr = license.Split(';');

            if (licenseStrArr.Length != 2)
                throw new ArgumentException(license, nameof(license));

            BarcodeReader barcodeReader = new BarcodeReader();
            string licenseContent = licenseStrArr[0];
            string licenseString = string.Empty;

            using (StreamReader sr = new StreamReader(licenseStrArr[1]))
            {
                licenseString = sr.ReadLine();
            }

            //Desktop Runtime License(Never expired)
            _ = barcodeReader.InitLicenseFromLicenseContent(licenseContent, licenseString);

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
