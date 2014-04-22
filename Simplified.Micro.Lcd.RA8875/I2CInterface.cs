using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace Simplified.Micro.Lcd.RA8875
{
    public class I2CInterface : ICommunicationInterface
    {
        internal enum TransferType : int
        {
            Data = 0x3F,
            CommandStatus = 0x40
        }

        private int _timeout;
        private I2CDevice _bus;
        private I2CDevice.Configuration _dataDeviceConfiguration;
        private I2CDevice.Configuration _commandStatusDeviceConfiguration;

        public I2CInterface(ushort address, int clockSpeed, int timeout)
        {
            _timeout = timeout;
            _dataDeviceConfiguration = new I2CDevice.Configuration(
                (ushort)(address & (int)TransferType.Data), clockSpeed);
            _commandStatusDeviceConfiguration = new I2CDevice.Configuration(
                (ushort)(address | (int)TransferType.CommandStatus), clockSpeed);

            _bus = new I2CDevice(_commandStatusDeviceConfiguration);
        }

        public void WriteData(byte data)
        {
            var buffer = new byte[] { data };
            var transactions = new I2CDevice.I2CTransaction[] {
                I2CDevice.CreateWriteTransaction(buffer)
            };
            _bus.Config = _dataDeviceConfiguration;
            _bus.Execute(transactions, _timeout);
        }

        public byte ReadData()
        {
            var buffer = new byte[1];
            var transactions = new I2CDevice.I2CTransaction[] {
                I2CDevice.CreateReadTransaction(buffer)
            };
            _bus.Config = _dataDeviceConfiguration;
            _bus.Execute(transactions, _timeout);
            return buffer[0];
        }

        public void WriteCommand(byte command)
        {
            var buffer = new byte[] { command };
            var transactions = new I2CDevice.I2CTransaction[] {
                I2CDevice.CreateWriteTransaction(buffer)
            };
            _bus.Config = _commandStatusDeviceConfiguration;
            _bus.Execute(transactions, _timeout);
        }

        public byte ReadStatus()
        {
            var buffer = new byte[1];
            var transactions = new I2CDevice.I2CTransaction[] {
                I2CDevice.CreateReadTransaction(buffer)
            };
            _bus.Config = _commandStatusDeviceConfiguration;
            _bus.Execute(transactions, _timeout);
            return buffer[0];
        }
    }
}
