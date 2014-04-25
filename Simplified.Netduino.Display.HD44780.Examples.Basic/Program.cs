using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace Simplified.Netduino.Display.HD44780.Examples.Basic
{
    public class Program
    {
        public static void Main()
        {
            byte e = 0x04;
            byte rs = 0x01;
            byte backlight = 0x08;


            var lcd = new I2C4Bit(0x27, e, rs, backlight);
            lcd.Initialize(I2C4Bit.Configuration.FourBit | I2C4Bit.Configuration.TwiLines
                | I2C4Bit.Configuration.Use5by7DotMatrix);
            lcd.SetDisplayMode(I2C4Bit.DisplayMode.Blinking | I2C4Bit.DisplayMode.CursorOn
                 | I2C4Bit.DisplayMode.DisplayOn);
            lcd.Clear();
            lcd.Backlight = true;
            lcd.SetEntryMode(I2C4Bit.EntryMode.Increment);

            lcd.Write("hello, world! .NET Micro");


        }

    }
}
