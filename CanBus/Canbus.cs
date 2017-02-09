using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace CanBus
{
    public class Canbus
    {
        public Canbus()
        {
            // bit rate = 500 /250
            SerialPort sp = new SerialPort()
            {
                BaudRate = 500,
                NewLine = "/r",
                DataBits = 8,
                Parity = Parity.None,
                PortName = "COM3",
                //StopBits
                //Handshake
                //ReadBufferSize
                //ReadTimeout
            };
            
            while(true)
            {
                if(sp.BytesToRead > 0)
                {
                    byte[] buffer = new byte[sp.BytesToRead];
                    sp.Read(buffer, 0, sp.BytesToRead);

                    //var bits = new BitArray(arrayOfBytes);

                    string byteStr = Convert.ToString(buffer[0], 2);
                    string byteStr2 = Convert.ToString(buffer[0], 2);

                    byteStr += byteStr2.Substring(0, 4);

                    string pidBinary = Convert.ToString(Convert.ToInt32("040", 16), 2);



                }
            }
        }
        //0x040
        //0x201

        private void ProcessLine(string line)
        {
            byte[] bytes = new byte[10];
           // bytes[0]
        }
    }
}
