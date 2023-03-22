using ezBarcode;
using System;
using System.Collections;
using System.IO;

namespace BarcodeReaderPicker.Adaptor
{
    public class EzBarcodeReader : IBarcodeReaderPlugin
    {
        public string Name => "EzBarcodeReader";

        public string Description => "EzBarcode Reader plugin.";

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

            ScanConfig option = new ScanConfig(RecognitionDirection.RECDIR_VHRVRH); //RecognitionDirection.RECDIR_VH
            option._barcodetype = BarcodeType.BARCODE_1D;
            //option._scanline = 200;

            ArrayList arrList = new ezScanner().ReadBarcodeList(targetFilePath, option);
            string[] result = new string[arrList.Count];

            for (int i = 0; i < arrList.Count; i++)
            {
                string[] arr = (string[])arrList[i];
                result[i] = arr[1];
            }

            return result;
        }
    }
}
