using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace Simplified.Netduino.Display.RA8875
{
    public class SPIInterface : ICommunicationInterface
    {
        internal enum TransferType : byte
        {
            WriteData = 0x00,
            WriteCommand = 0x80,
            ReadData = 0x40,
            ReadStatus = 0xC0
        }

        private SPI _bus;

        public SPIInterface(SPI.Configuration configuration)
        {
            _bus = new SPI(configuration);
        }

        public void WriteData(byte data)
        {
            _bus.Write(new byte[] { (byte)TransferType.WriteData, data });
        }

        public byte ReadData()
        {
            byte[] buffer = new byte[1];
            _bus.WriteRead(new byte[] { (byte)TransferType.ReadData }, buffer);
            return buffer[0];
        }

        public void WriteCommand(byte command)
        {
            _bus.Write(new byte[] { (byte)TransferType.WriteCommand, command });
        }

        public byte ReadStatus()
        {
            byte[] buffer = new byte[1];
            _bus.WriteRead(new byte[] { (byte)TransferType.ReadStatus }, buffer);
            return buffer[0];
        }
    }
}
