using System;
using Microsoft.SPOT;

namespace Simplified.Micro.Lcd.RA8875
{
    class Display
    {
        private ICommunicationInterface _interface;

        public Display(ICommunicationInterface communicationInterface)
        {
            _interface = communicationInterface;
        }



        protected void WriteRegister(Registers register, byte value)
        {
            _interface.WriteCommand((byte)register);
            _interface.WriteData(value);
        }

        protected byte ReadRegister(Registers register)
        {
            _interface.WriteCommand((byte)register);
            return _interface.ReadData();
        }

      
    }
}
