using System;
using Microsoft.SPOT;

namespace Simplified.Netduino.Display.RA8875
{
    public enum CursorDirection : byte
    {
        LeftRightTopBottom = 0x00,
        RightLeftTopBottom = 0x01,
        TopBottomLeftRight = 0x10,
        DownTopLeftRight = 0x11
    }
}
