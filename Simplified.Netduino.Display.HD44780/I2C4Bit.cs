using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using System.Text;
using System.Threading;

namespace Simplified.Netduino.Display.HD44780
{
    public class I2C4Bit
    {
        [Flags]
        public enum EntryMode : byte
        {
            Increment = 0x02,
            Decrement = 0x00,
            ShiftDisplay = 0x01
        }

        [Flags]
        public enum DisplayMode : byte
        {
            DisplayOff = 0x00,
            DisplayOn = 0x04,
            CursorOn = 0x02,
            CursorOff = 0x00,
            Blinking = 0x01
        }

        [Flags]
        public enum MoveOptions : byte
        {
            Cursor = 0x00,
            Display = 0x02,
            Left = 0x00,
            Right = 0x01
        }

        [Flags]
        public enum Configuration : byte
        {
            EightBit = 0x10,
            FourBit = 0x00,
            OneLine = 0x00,
            TwiLines = 0x08,
            Use5by7DotMatrix = 0x00,
            Use5by10DotMatrix = 0x01
        }

        public enum Command : byte
        {
            ClearDisplay = 0x01,
            ReturnHome = 0x02,
            SetEntryMode = 0x04,
            DisplayControl = 0x08,
            MoveCursorOrDisplay = 0x10,
            SetUp = 0x20,
            SetCGRAMAddress = 0x40,
            SetDDRAMAddress = 0x80
        }

        I2CDevice _bus;
        byte _enableBit;
        byte _registerBit;
        byte _backlightBit;
        byte _backlight;

        public I2C4Bit(byte address, byte enableBit, byte registerBit,
            byte backlightBit)
        {
            _bus = new I2CDevice(new I2CDevice.Configuration(address, 100));
            _enableBit = enableBit;
            _registerBit = registerBit;
            _backlight = 0x00;
            _backlightBit = backlightBit;
        }

        public void SendCommand(byte data)
        {
            int transfer = (data & 0xF0) | _backlight;
            transfer &= ~_enableBit;
            SendByte((byte)transfer);
            transfer |= _enableBit;
            SendByte((byte)transfer);
            transfer &= ~_enableBit;
            SendByte((byte)transfer);

            transfer = ((data & 0x0F) << 4) | _backlight;
            SendByte((byte)transfer);
            transfer |= _enableBit;
            SendByte((byte)transfer);
            transfer &= ~_enableBit;
            SendByte((byte)transfer);

        }

        public void SendHigh(byte data)
        {
            int transfer = (data & 0xF0) | _backlight;
            transfer &= ~_enableBit;
            SendByte((byte)transfer);
            transfer |= _enableBit;
            SendByte((byte)transfer);
            transfer &= ~_enableBit;
            SendByte((byte)transfer);

        }

        public void SendLow(byte data)
        {
            int transfer = ((data & 0x0F) << 4) | _backlight;
            transfer &= ~_enableBit;
            SendByte((byte)transfer);
            transfer |= _enableBit;
            SendByte((byte)transfer);
            transfer &= ~_enableBit;
            SendByte((byte)transfer);

        }

        public void SendData(byte data)
        {
            int transfer = (data & 0xF0) | _backlight | _registerBit;
            transfer &= ~_enableBit;
            SendByte((byte)transfer);
            transfer |= _enableBit;
            SendByte((byte)transfer);
            transfer &= ~_enableBit;
            SendByte((byte)transfer);

            transfer = ((data & 0x0F) << 4) | _backlight | _registerBit;
            SendByte((byte)transfer);
            transfer |= _enableBit;
            SendByte((byte)transfer);
            transfer &= ~_enableBit;
            SendByte((byte)transfer);
        }


        private void SendByte(byte data)
        {
            I2CDevice.I2CTransaction[] xact = new I2CDevice.I2CTransaction[]
                {
                    
                    I2CDevice.CreateWriteTransaction(new byte[] { data })
                };

            _bus.Execute(xact, 3000);

        }

        public void Write(string text)
        {
            var characters = Encoding.UTF8.GetBytes(text);
            foreach (var character in characters)
            {
                SendData(character);
            }
        }

        public void Write(char character)
        {
            SendData((byte)character);
        }

        public void Initialize(Configuration configuration)
        {
            SendHigh(0x30);
            Thread.Sleep(100);
            SendHigh(0x30);
            Thread.Sleep(100);
            SendHigh(0x30);
            Thread.Sleep(100);
            SendHigh(0x20);

            var command = (byte)((int)Command.SetUp | (int)configuration);
            SendCommand(command);
            Thread.Sleep(100);
        }

        DisplayMode _currentMode;
        public void SetDisplayMode(DisplayMode mode)
        {
            _currentMode = mode;
            var command = (byte)((int)Command.DisplayControl | (int)_currentMode);
            SendCommand(command);
            Thread.Sleep(100);
        }

        public void SetEntryMode(EntryMode mode)
        {
            var command = (byte)((int)Command.SetEntryMode | (int)mode);
            SendCommand(command);
            Thread.Sleep(100);
        }

        public void Clear()
        {
            var command = (byte)Command.ClearDisplay;
            SendCommand(command);
            Thread.Sleep(100);
        }


        public void ReturnHome()
        {
            var command = (byte)Command.ReturnHome;
            SendCommand(command);
            Thread.Sleep(100);
        }

        public void MoveCursorLeft()
        {
            var command = (byte)((int)Command.MoveCursorOrDisplay | (int)
                (MoveOptions.Cursor | MoveOptions.Left));
            SendCommand(command);
            Thread.Sleep(100);
        }

        public void MoveCursorRight()
        {
            var command = (byte)((int)Command.MoveCursorOrDisplay | (int)
                (MoveOptions.Cursor | MoveOptions.Right));
            SendCommand(command);
            Thread.Sleep(100);
        }

        public void MoveDisplayLeft()
        {
            var command = (byte)((int)Command.MoveCursorOrDisplay | (int)
                (MoveOptions.Display | MoveOptions.Left));
            SendCommand(command);
            Thread.Sleep(100);
        }

        public void MoveDisplayRight()
        {
            var command = (byte)((int)Command.MoveCursorOrDisplay | (int)
                (MoveOptions.Display | MoveOptions.Right));
            SendCommand(command);
            Thread.Sleep(100);
        }

        public bool Backlight
        {
            get { return _backlight == _backlightBit; }
            set
            {
                if (value)
                {
                    _backlight = _backlightBit;
                }
                else
                {
                    _backlight = 0x00;
                }
                SetDisplayMode(_currentMode);
            }
        }
    }
}
