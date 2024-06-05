using ezBarcode;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace BarcodeReaderPicker.Adaptor
{
    public class EzBarcodeReader : IBarcodeReaderPlugin
    {
        public string Name => "EzBarcodeReader";

        public string Description => "EzBarcode Reader plugin.";

        private readonly BarcodeReaderConfig _config;

        public EzBarcodeReader(BarcodeReaderConfig config)
        {
            _config = config;
        }

        public string[] Execute(string targetFilePath)
        {
            if (string.IsNullOrEmpty(targetFilePath))
                throw new ArgumentNullException(targetFilePath, nameof(targetFilePath));

            if (!File.Exists(targetFilePath))
                throw new FileNotFoundException(nameof(targetFilePath));

            Dictionary<EncodingFormat, BarcodeType> barcodeTypeMap = new Dictionary<EncodingFormat, ezBarcode.BarcodeType>
            {
                { EncodingFormat.All, BarcodeType.BARCODE_ALL },
                { EncodingFormat.AllOneDimensional, BarcodeType.BARCODE_1D },
                { EncodingFormat.AllTwoDimensional, BarcodeType.BARCODE_2D },
            };

            foreach (EncodingFormat type in Enum.GetValues(typeof(EncodingFormat)))
            {
                if (_config.Format.HasFlag(type))
                {
                    if (!barcodeTypeMap.ContainsKey(type))
                    {
                        throw new Exception("Not allowed barcode type.");
                    }

                    ScanConfig option = new ScanConfig(RecognitionDirection.RECDIR_VHRVRH) //RecognitionDirection.RECDIR_VH
                    {
                        _barcodetype = barcodeTypeMap[type],
                        //_scanline = 200,
                    };

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

            throw new Exception("Not allowed barcode type.");
        }
    }
}
