using System;
using Microsoft.SPOT;

namespace Simplified.Netduino.Display.RA8875
{
    internal enum Registers : byte
    {
        PowerAndDisplayControl = 0x01, // PWRR
        MemoryReadWrite = 0x02, //MRWC
        PixelClockSetting = 0x04, // PCSR
        SerialFlashConfiguration = 0x05, // SROC
        SerialFlashClockConfiguration = 0x06, // SFCLR
        SystemConfiguration = 0x10, // SYSR
        GeneralPurposeInput = 0x12, // GPI
        GeneralPurposeOutput = 0x13, // GPO
        HorizontalDisplayWidth = 0x14, // HDWR
        DisplayConfiguration = 0x20, // DPCR
        FontControl0 = 0x21, // FNCR0
        FontControl1 = 0x22,// FNCR1
        CGRAMSelect = 0x23, // CGSR
        HorizontalScrollOffset0 = 0x24, // HOFS0
        HorizontalScrollOffset1 = 0x25, // HOFS1
        VerticalScrollOffset0 = 0x26, // VOFS0
        VerticalScrollOffset1 = 0x27, // VOFS1
        FontLineDistanceSetting = 0x28, // FLDR
        FontWriteCursorHorizontalPosition0 = 0x2A, // FCUR_XL
        FontWriteCursonHorizontalPosition1 = 0x2B, // FCUR_XH
        FontWriteCursonVerticalPosition0 = 0x2C, // F_CURYL
        FontWriteCursonVerticalPosition1 = 0x2D, // F_CURYH
        FontWriteTypeSetting = 0x2E, 
        FontSerialROMSetting = 0x2F,
        ActiveWindowHorizontalStartPoint0 = 0x30, // HSAW0
        ActiveWindowHorizontalStartPoint1 = 0x31, // HSAW1
        ActiveWindowVerticalStartPoint0 = 0x32, // VSAW0
        ActiveWindowVerticalStartPoint1  = 0x33, // VSAW1
        ActiveWindowHorizontalEndPoint0 = 0x34, // HEAW0
        ActiveWindowHorizontalEndPoint1 = 0x35, // HEAW1
        ActiveWindowVerticalEndPoint0 = 0x36, // VEAW0
        ActiveWindowVerticalEndPoint1 = 0x37, // VEAW1
        ScrollWindowHorizontalStartPoint0 = 0x38, // HSSW0
        ScrollWindowHorizontalStartPoint1 = 0x39, // HSSW1
        ScrollWindowVerticalStartPoint0 = 0x3A, // VSSW0
        ScrollWindowVerticalStartPoint1 = 0x3B, // VSSW1
        ScrollWindowHorizontalEndPoint0 = 0x3C, // HESW0
        ScrollWindowHorizontalEndPoint1 = 0x3D, // HESW1
        ScrollWindowVerticalEndPoint0 = 0x3E, // VESW0
        ScrollWindowVerticalEndPoint1 = 0x3F, // VESW1
        MemoryWriteControl0 = 0x40, //MWCR0
        MemoryWriteControl1 = 0x41, // MWCR1
        BlinkTimeControl = 0x44, // BTCR
        MemoryReadCursorDirection = 0x45, // MRCD
        MemoryWriteCursorHorizontalPosition0 = 0x46, // CURH0
        MemoryWriteCursorHorizontalPosition1 = 0x47, // CURH1
        MemoryWriteCursorVerticalPosition0 = 0x48, // CURV0
        MemoryWriteCursorVerticalPosition1 = 0x49, // CURV1
        MemoryReadCursorHorizontalPosition0 = 0x4A, // RCURH0
        MemoryReadCursorHorizontalPosition1 = 0x4B, // RCURH1
        MemoryReadCursorVerticalPosition0 = 0x4C, // RCURV0
        MemoryReadCursorVerticalPosition1 = 0x4D, // RCURV1
        FontAndCursorHorizontalSize = 0x4E, // CURHS
        FontAndCursonVerticalSize = 0x4F, // CURVS
        BTEFunctionControl0 = 0x50, // BECR0
        BTEFunctionControl1 = 0x51, // BECR1
        LayerTransparency0 = 0x52, // LTPR0
        LayerTransparency1 = 0x53, // LTPR1
        BTESourceHorizontalPoint0 = 0x54, // HSBE0
        BTESourceHorizontalPoint1 = 0x55, // HSBE1
        BTESourceVerticalPoint0 = 0x56, // VSBE0
        BTESourceVerticalPoint1 = 0x57, // VSBE1
        BTEDestinationHorizontalPoint0 = 0x58, // HDBE0
        BTEDestinationHorizontalPoint1 = 0x59, // HDBE1
        BTEDestinationVerticalPoint0 = 0x5A, // VDBE0
        BTEDestinationVerticalPoint1 = 0x5B, // VDBE1
        BTEWidth0 = 0x5C, // BEWR0
        BTEWidth1 = 0x5D, // BEWR1
        BTEHeight0 = 0x5E, // BEHR0
        BTEHeight1 = 0x5F, // BEHR1
        BackgroundColorRed = 0x60, // BGCR0
        BackgroundColorGreen = 0x61, // BGCR1
        BackgroundColorBlue = 0x62, // BGCR2
        ForegroundColorRed = 0x63, // FGCR0
        ForegroundColorGreen = 0x64, // FGCR1
        ForegroundColorBlue = 0x65, // FGCR2
        PatternSet = 0x66, // PTNO
        TransparentColorRed = 0x67, // BGTR0
        TransparentColorGreen = 0x68, // BGTR1
        TransparentColorBlue = 0x69, // BGTR2,
        TouchPanelControl0 = 0x70, // TPCR0
        TouchPanelControl1 = 0x71, // TPCR1
        TouchPanelXCoordinate = 0x72, // TPXH
        TouchPanelYCoordinate = 0x73, // TPYH
        TouchPanleXYStatus = 0x74, // TPXYL
        GraphicCursorHorizontalPosition0 = 0x80, // GCHP0
        GraphicCursorHorizontalPosition1 = 0x81, // GCHP1
        GraphicCursorVerticalPosition0 = 0x82, // GCVP0
        GraphicCursorVerticalPosition1 = 0x83, // GCVP1
        GraphicCursorColor0 = 0x84, // GCC0
        GraphicCursorColor1 = 0x85, // GCC1,
        PLLControl1 = 0x88, // PLLC1
        PLLControl2 = 0x89, // PLLC2
        PWM1Control = 0x8A, // P1CR
        PWMDutyCycle = 0x8B, // P1DCR
        PWM2Control = 0x8C, // P2CR
        PWM2DutyCycle = 0x8D, // P2DCR
        MemoryClearContorl = 0x8E, // MCLR
        DrawLineCircleSquareControl = 0x90, // DCR
        DrawLineSquareHorizontalStartPosition0 = 0x91, // DLHSR0
        DrawLineSquareHorizontalStartPosition1 = 0x92, // DLHSR1
        DrawLineSquareVerticalStartPosition0 = 0x93, // DLVSR0
        DrawLineSquareVerticalStartPosition1 = 0x94, // DLVSR1
        DrawLineSquareHorizontalEndPosition0 = 0x95, // DLHER0
        DrawLineSquareHorizontalEndPosition1 = 0x96, // DLHER1
        DrawLineSquareVerticalEndPosition0 = 0x97, // DLVER0
        DrawLineSquareVerticalEndPosition1 = 0x98, // DLVER1
        DrawCircleHorizontalPosition0 = 0x99, // DCHR0
        DrawCircleHorizontalPosition1 = 0x9A, // DCHR1
        DrawCircleVerticalPosition0 = 0x9B, // DCVR0
        DrawCircleVerticalPosition1 = 0x9C, // DCVR1
        DrawCircleRadius = 0x9D, // DCRR
        DrawElipseCurveCircleSquare = 0xA0,
        ElipseLongAxis0 = 0xA1, // ELL_A0
        ElipseLongAxis1 = 0xA2, // ELL_A1
        ElipseSHortAxis0 = 0xA3, // ELL_B0
        ElipseShortAxis1 = 0xA4, // ELL_B1
        DrawElipseHorizontalPosition0 = 0xA5, // DCHR0
        DrawElipseHorizontalPosition1 = 0xA6, // DCHR1
        DrawElipseVerticalPosition0 = 0xA7, // DCVR0
        DrawElipseVerticalPosition1 = 0xA8, // DCVR1
        DrawTriangleHorizontalPosition0 = 0xA9, // DCHR0
        DrawTriangleHorizontalPosition1 = 0xAA, // DCHR1
        DrawTriangleVerticalPosition0 = 0xAB, // DCVR0
        DrawTriangleVerticalPosition1 = 0xAC, // DCVR1
        DMASourceAddress0 = 0xB0,
        DMASourceAddress1 = 0xB1,
        DMASourceAddress2 = 0xB2,
        DMATransferNo0BlockWidth0 = 0xB4,
        DMABlockWidth1 = 0xB5,
        DMATransferNo1BlockHeight1 = 0xB6,
        DMABlockHeight1 = 0xB7,
        DMATransferNo3SourcePictureWidth0 = 0xB8,
        DMASourcePictureWidth1 = 0xB9,
        DMAConfiguration = 0xBF,
        KeyScanControl1 = 0xC0,
        KeyScanControl2 = 0xC1,
        KeyScanData0 = 0xC2,
        KeyScanData1 = 0xC3,
        KeyScanData2 = 0xC4,
        ExtraGPIO = 0xC7,
        FloatingWindowSourceHorizontalPosition0 = 0xD0,
        FloatingWindowSourceHorizontalPosition1 = 0xD1,
        FloatingWindowSourceVerticalPosition0 = 0xD2,
        FloatingWindowSourceVerticalPosition1 = 0xD3,
        FloatingWindowWidth0 = 0xD4,
        FloatingWindowWidth1 = 0xD5,
        FloatingWindowHeight0 = 0xD6,
        FloatingWindowHeight1 = 0xD7,
        FloatingWindowDisplayHorizontalPosition0 = 0xD8,
        FloatingWindowDisplayHorizontalPosition1 = 0xD9,
        FloatingWindowDisplayVerticalPosition0 = 0xDA,
        FloatingWindowDisplayVerticalPosition1 = 0xDB,
        InterruptControl1 = 0xF0,
        InterruptControl2 = 0xF1
    }
}