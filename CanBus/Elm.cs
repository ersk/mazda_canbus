using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace CanBus
{
    public class Elm
    {
        Form1 form;
        SerialPort sp;

        public Elm(Form1 form)
        {
            this.form = form;

            // bit rate = 500 /250
            sp = new SerialPort()
            {
                BaudRate = 115200,
                NewLine = "/r",
                DataBits = 8,
                Parity = Parity.None,
                PortName = "COM3",
                StopBits = StopBits.One
                //Handshake
                //ReadBufferSize
                //ReadTimeout
            };

            //sp.WriteLine("ATI");
            form.textBox1.Text += "ATI\r\n";
            form.textBox1.Text += "ATSP0\r\n";
            //ReadResponse();
        }

        // ATI or ATZ

        //ATSP0= autmatic protocol ->OK
        //ATMA => stream
        public void ReadResponse()
        {
            while (true)
            {
                if (sp.BytesToRead > 0)
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

        /*
         6 – ISO 15765-4 CAN (11 bit ID, 500 kbaud)
        7 – ISO 15765-4 CAN (29 bit ID, 500 kbaud)
        8 – ISO 15765-4 CAN (11 bit ID, 250 kbaud)
        9 – ISO 15765-4 CAN (29 bit ID, 250 kbaud)
        A – SAE J1939 CAN (29 bit ID, 250 kbaud)
        */

        //public void SendCommand(SerialPort sp, string command)
        //{
        //    byte[] commandBytes = Encoding.ASCII.GetBytes(command);
        //}

        private void ProcessLine(string line)
        {
            byte[] bytes = new byte[10];
            //bytes[0]
        }
    }
}
