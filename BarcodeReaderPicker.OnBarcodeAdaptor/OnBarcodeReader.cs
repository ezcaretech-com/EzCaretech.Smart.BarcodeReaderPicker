using OnBarcode.Barcode.BarcodeScanner;
using System;
using System.Collections.Generic;
using System.IO;

namespace BarcodeReaderPicker.Adaptor
{
    public class OnBarcodeReader : IPlugin
    {
        public string Name => "OnBarcodeReader";

        public string Description => "IonBarCode for .NET SDK plugin.";

        private readonly Configuration _config;

        public OnBarcodeReader(Configuration config)
        {
            _config = config;
        }

        public string[] Execute(string targetFilePath)
        {
            if (string.IsNullOrEmpty(targetFilePath))
                throw new ArgumentNullException(targetFilePath, nameof(targetFilePath));

            if (!File.Exists(targetFilePath))
                throw new FileNotFoundException(nameof(targetFilePath));

            Dictionary<EncodingFormat, BarcodeType> barcodeTypeMap = new Dictionary<EncodingFormat, BarcodeType>
            {
                { EncodingFormat.All, BarcodeType.All },
                { EncodingFormat.Codabar, BarcodeType.Codabar },
                { EncodingFormat.Code39, BarcodeType.Code39 },
                { EncodingFormat.Code39Extended, BarcodeType.Code39Extension },
                { EncodingFormat.Code93, BarcodeType.Code93 },
                { EncodingFormat.Code128, BarcodeType.Code128 },
                { EncodingFormat.EAN8, BarcodeType.EAN8 },
                { EncodingFormat.EAN13, BarcodeType.EAN13 },
                //{ EncodingFormat.EAN13, BarcodeType.ISBN },
                //{ EncodingFormat.EAN13, BarcodeType.ISSN },
                { EncodingFormat.ITF, BarcodeType.Interleaved2of5 },
                //{ EncodingFormat.ITF14, BarcodeType.ITF14 },
                { EncodingFormat.UPCA, BarcodeType.UPCA },
                { EncodingFormat.UPCE, BarcodeType.UPCE },
                { EncodingFormat.PDF417, BarcodeType.PDF417 },
                { EncodingFormat.DataMatrix, BarcodeType.DataMatrix },
                { EncodingFormat.QRCode, BarcodeType.QRCode },
                { EncodingFormat.IntelligentMail, BarcodeType.IntelligentMail },
            };

            foreach (EncodingFormat type in Enum.GetValues(typeof(EncodingFormat)))
            {
                if (_config.Format.HasFlag(type))
                {
                    if (!barcodeTypeMap.ContainsKey(type))
                    {
                        throw new Exception("Not allowed barcode type.");
                    }

                    return BarcodeScanner.Scan(targetFilePath, barcodeTypeMap[type]);
                }
            }

            throw new Exception("Not allowed barcode type.");
        }
    }
}
