using System;

namespace BarcodeReaderPicker
{
    [Flags]
    public enum EncodingFormat
    {
        All = 1 << 0,
        AllOneDimensional = 1 << 1,
        AllTwoDimensional = 1 << 2,
        Codabar = 1 << 3,
        Code25Interleaved = 1 << 4,
        Code39 = 1 << 5,
        Code39Extended = 1 << 6,
        Code93 = 1 << 7,
        Code128 = 1 << 8,
        EAN8 = 1 << 9,
        EAN13 = 1 << 10,
        ITF = 1 << 11,
        UPCA = 1 << 12,
        UPCE = 1 << 13,
        MSI = 1 << 14,
        Plessey = 1 << 15,
        Databar = 1 << 16,
        Rss14 = 1 << 17,
        PDF417 = 1 << 18,
        Aztec = 1 << 19,
        DataMatrix = 1 << 20,
        MaxiCode = 1 << 21,
        QRCode = 1 << 22,
        IntelligentMail = 1 << 23,
        PharmaCode = 1 << 24
    }
}
