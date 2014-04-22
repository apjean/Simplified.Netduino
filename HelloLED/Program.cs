using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace HelloLED
{
    public class Program
    {
        public static void Main()
        {
            var ledPort = new OutputPort(Pins.ONBOARD_LED, false);
            var buttonPort = new InputPort(Pins.ONBOARD_BTN, true, Port.ResistorMode.Disabled);
            while (true)
            {
                var value = buttonPort.Read();
                Debug.Print(value.ToString());
                ledPort.Write(true);
                Thread.Sleep(400);
                ledPort.Write(false);
                Thread.Sleep(200);
                ledPort.Write(true);
                Thread.Sleep(400);
                ledPort.Write(false);
                Thread.Sleep(1000);
                if (value) return;
               
            }
        }

    }
}
