using System;
using Microsoft.SPOT;

namespace Simplified.Netduino.Display.RA8875
{
    [Flags]
    public enum Status
    {
        MemoryReadWriteBusy = 1 << 7,
        BTEBusy = 1 << 6,
        TouchDetected = 1 << 5,
        SleepModeActive = 1 << 4,
        SerialFlashBusy = 1
    }
}
