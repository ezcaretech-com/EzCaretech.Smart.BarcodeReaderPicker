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
        Code39 = 1 << 4,
        Code39Extended = 1 << 5,
        Code93 = 1 << 6,
        Code128 = 1 << 7,
        EAN8 = 1 << 8,
        EAN13 = 1 << 9,
        ITF = 1 << 10,
        UPCA = 1 << 11,
        UPCE = 1 << 12,
        MSI = 1 << 13,
        Plessey = 1 << 14,
        Databar = 1 << 15,
        Rss14 = 1 << 16,
        PDF417 = 1 << 17,
        Aztec = 1 << 18,
        DataMatrix = 1 << 19,
        MaxiCode = 1 << 20,
        QRCode = 1 << 21,
        IntelligentMail = 1 << 22,
        PharmaCode = 1 << 23
    }
}
