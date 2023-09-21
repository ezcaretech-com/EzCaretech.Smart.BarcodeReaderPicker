namespace BarcodeReaderPicker.Adaptor
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using BarcodeReader = BarcodeLib.BarcodeReader.BarcodeReader;

    /// <summary>
    /// http://www.barcodelib.com/net_barcode_reader/main.html
    /// </summary>
    public class BarcodeLibReader : IPlugin
    {
        public string Name => "BarcodeLibReader";

        public string Description => ".NET Barcode Reader SDK plugin.";

        private readonly Configuration _config;

        public BarcodeLibReader(Configuration config)
        {
            _config = config;
        }

        public string[] Execute(string targetFilePath)
        {
            if (string.IsNullOrEmpty(targetFilePath))
                throw new ArgumentNullException(targetFilePath, nameof(targetFilePath));

            if (!File.Exists(targetFilePath))
                throw new FileNotFoundException(nameof(targetFilePath));

            Dictionary<EncodingFormat, int> barcodeTypeMap = new Dictionary<EncodingFormat, int>
            {
                { EncodingFormat.Codabar, BarcodeReader.CODABAR },
                { EncodingFormat.Code25Interleaved, BarcodeReader.INTERLEAVED25 },
                { EncodingFormat.Code39, BarcodeReader.CODE39 },
                { EncodingFormat.Code39Extended, BarcodeReader.CODE39EX },
                { EncodingFormat.Code128, BarcodeReader.CODE128 },
                { EncodingFormat.EAN8, BarcodeReader.EAN8 },
                { EncodingFormat.EAN13, BarcodeReader.EAN13 },
                { EncodingFormat.UPCA, BarcodeReader.UPCA },
                { EncodingFormat.UPCE, BarcodeReader.UPCE },
                { EncodingFormat.PDF417, BarcodeReader.PDF417 },
                { EncodingFormat.DataMatrix, BarcodeReader.DATAMATRIX },
                { EncodingFormat.QRCode, BarcodeReader.QRCODE },
            };

            foreach (EncodingFormat type in Enum.GetValues(typeof(EncodingFormat)))
            {
                if (_config.Format.HasFlag(type))
                {
                    if (!barcodeTypeMap.ContainsKey(type))
                    {
                        throw new Exception("Not allowed barcode type.");
                    }

                    return BarcodeReader.read(targetFilePath, barcodeTypeMap[type]);
                }
            }

            throw new Exception("Not allowed barcode type.");
        }
    }
}
