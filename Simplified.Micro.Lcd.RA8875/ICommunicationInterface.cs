using System;
using Microsoft.SPOT;

namespace Simplified.Micro.Lcd.RA8875
{
    public interface ICommunicationInterface
    {
       void WriteData(byte data);
       byte ReadData();
       void WriteCommand(byte command);
       byte ReadStatus();
    }
}
    