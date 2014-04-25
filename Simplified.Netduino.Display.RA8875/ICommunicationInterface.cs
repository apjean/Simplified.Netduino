using System;
using Microsoft.SPOT;

namespace Simplified.Netduino.Display.RA8875
{
    public interface ICommunicationInterface
    {
       void WriteData(byte data);
       byte ReadData();
       void WriteCommand(byte command);
       byte ReadStatus();
    }
}
    