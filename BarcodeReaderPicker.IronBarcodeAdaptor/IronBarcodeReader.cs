using IronBarCode;
using System;
using System.Collections.Generic;
using System.IO;

namespace BarcodeReaderPicker.Adaptor
{
    using BarcodeReader = IronBarCode.BarcodeReader;

    /// <summary>
    /// https://ironsoftware.com/csharp/barcode/
    /// </summary>
    public class IronBarcodeReader : IPlugin
    {
        public string Name => "IronBarcodeReader";

        public string Description => "IonBarCode for .NET SDK plugin.";

        private readonly Configuration _config;

        public IronBarcodeReader(Configuration config)
        {
            _config = config;
        }

        public string[] Execute(string targetFilePath)
        {
            if (string.IsNullOrEmpty(targetFilePath))
                throw new ArgumentNullException(targetFilePath, nameof(targetFilePath));

            if (!File.Exists(targetFilePath))
                throw new FileNotFoundException(nameof(targetFilePath));
            License.LicenseKey = _config.License;

            Dictionary<EncodingFormat, BarcodeEncoding> barcodeTypeMap = new Dictionary<EncodingFormat, BarcodeEncoding>
            {
                { EncodingFormat.All, BarcodeEncoding.All },
                { EncodingFormat.AllOneDimensional, BarcodeEncoding.AllOneDimensional },
                { EncodingFormat.AllTwoDimensional, BarcodeEncoding.AllTwoDimensional },
                { EncodingFormat.Codabar, BarcodeEncoding.Codabar },
                { EncodingFormat.Code39, BarcodeEncoding.Code39 },
                { EncodingFormat.Code93, BarcodeEncoding.Code93 },
                { EncodingFormat.Code128, BarcodeEncoding.Code128 },
                { EncodingFormat.EAN8, BarcodeEncoding.EAN8 },
                { EncodingFormat.EAN13, BarcodeEncoding.EAN13 },
                { EncodingFormat.ITF, BarcodeEncoding.ITF },
                { EncodingFormat.UPCA, BarcodeEncoding.UPCA },
                { EncodingFormat.UPCE, BarcodeEncoding.UPCE },
                { EncodingFormat.MSI, BarcodeEncoding.MSI },
                { EncodingFormat.Plessey, BarcodeEncoding.Plessey },
                { EncodingFormat.Databar, BarcodeEncoding.Databar },
                { EncodingFormat.Rss14, BarcodeEncoding.Rss14 },
                { EncodingFormat.PDF417, BarcodeEncoding.PDF417 },
                { EncodingFormat.Aztec, BarcodeEncoding.Aztec },
                { EncodingFormat.DataMatrix, BarcodeEncoding.DataMatrix },
                { EncodingFormat.MaxiCode, BarcodeEncoding.MaxiCode },
                { EncodingFormat.QRCode, BarcodeEncoding.QRCode },
                { EncodingFormat.IntelligentMail, BarcodeEncoding.IntelligentMail },
                { EncodingFormat.PharmaCode, BarcodeEncoding.PharmaCode }
            };

            BarcodeEncoding barcodeEncoding = new BarcodeEncoding();

            foreach (EncodingFormat type in Enum.GetValues(typeof(EncodingFormat)))
            {
                if (_config.Format.HasFlag(type))
                {
                    if (!barcodeTypeMap.ContainsKey(type))
                    {
                        throw new Exception("Not allowed barcode type.");
                    }

                    barcodeEncoding |= barcodeTypeMap[type];
                }
            }

            BarcodeResults result = BarcodeReader.Read(targetFilePath);

            return result.Values();
        }
    }
}
