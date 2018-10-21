using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LedsGUI
{


    public class MessageModule : IDisposable
    {
        public bool Ready { get; private set; } = false;

        System.Timers.Timer messageSender = new System.Timers.Timer();

        SerialPort serialPort = new SerialPort();
        const int BAUDRATE = 921600;
        public static Queue<byte[]> messageQueue = new Queue<byte[]>();

        const byte ACK                               = 0x06;
        const byte NCK                               = 0x15;

        const byte STRIP_DATA                        = 0x0F;

        const byte DIGITAL_CHANGEMODE                = 0x01;
        const byte DIGITAL_CHANGEBRIGHT              = 0x02;
        const byte DIGITAL_CHANGEINTERVAL            = 0x03;
        const byte DIGITAL_CHANGECOLOR               = 0x04;
        const byte DIGITAL_MUSICAL_PATTERN           = 0x05;
        const byte DIGITAL_CUSTOM_PALETTE            = 0x06;
        const byte DIGITAL_CUSTOM_PALETTE_PROPERTIES = 0x07;

        const byte ANALOG_CHANGEMODE                 = 0x08;
        const byte ANALOG_CHANGEBRIGHT               = 0x09;
        const byte ANALOG_CHANGEINTERVAL             = 0x0A;
        const byte ANALOG_CHANGECOLOR                = 0x0B;
        const byte ANALOG_MUSICAL_PATTERN            = 0x0C;

        public List<StripMode> AnalogModesAvailable = new List<StripMode>();
        public List<StripMode> DigitalModesAvailable = new List<StripMode>();

        private LedController _ledController;

        private ToolStripStatusLabel _COMStatusLabel;
        private ToolStripStatusLabel _MessageLabel;
        private ToolStripStatusLabel _QueueSizeLabel;

        private Random random = new Random();

        public static Color SoundSpectrumColor = new Color();
        public static Color DigitalSpectrumColor = new Color();

        readonly byte[] ExponentialCurve = {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01,
                                            0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02,
                                            0x02, 0x02, 0x03, 0x03, 0x03, 0x03, 0x03, 0x03, 0x04, 0x04, 0x04, 0x04, 0x04, 0x05, 0x05, 0x05,
                                            0x05, 0x06, 0x06, 0x06, 0x07, 0x07, 0x07, 0x08, 0x08, 0x08, 0x09, 0x09, 0x0A, 0x0A, 0x0B, 0x0B,
                                            0x0C, 0x0C, 0x0D, 0x0D, 0x0E, 0x0F, 0x0F, 0x10, 0x11, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17,
                                            0x18, 0x19, 0x1A, 0x1B, 0x1C, 0x1D, 0x1F, 0x20, 0x21, 0x23, 0x24, 0x26, 0x27, 0x29, 0x2B, 0x2C,
                                            0x2E, 0x30, 0x32, 0x34, 0x36, 0x38, 0x3A, 0x3C, 0x3E, 0x40, 0x43, 0x45, 0x47, 0x4A, 0x4C, 0x4F,
                                            0x51, 0x54, 0x57, 0x59, 0x5C, 0x5F, 0x62, 0x64, 0x67, 0x6A, 0x6D, 0x70, 0x73, 0x76, 0x79, 0x7C,
                                            0x7F, 0x82, 0x85, 0x88, 0x8B, 0x8E, 0x91, 0x94, 0x97, 0x9A, 0x9C, 0x9F, 0xA2, 0xA5, 0xA7, 0xAA,
                                            0xAD, 0xAF, 0xB2, 0xB4, 0xB7, 0xB9, 0xBB, 0xBE, 0xC0, 0xC2, 0xC4, 0xC6, 0xC8, 0xCA, 0xCC, 0xCE,
                                            0xD0, 0xD2, 0xD3, 0xD5, 0xD7, 0xD8, 0xDA, 0xDB, 0xDD, 0xDE, 0xDF, 0xE1, 0xE2, 0xE3, 0xE4, 0xE5,
                                            0xE6, 0xE7, 0xE8, 0xE9, 0xEA, 0xEB, 0xEC, 0xED, 0xED, 0xEE, 0xEF, 0xEF, 0xF0, 0xF1, 0xF1, 0xF2,
                                            0xF2, 0xF3, 0xF3, 0xF4, 0xF4, 0xF5, 0xF5, 0xF6, 0xF6, 0xF6, 0xF7, 0xF7, 0xF7, 0xF8, 0xF8, 0xF8,
                                            0xF9, 0xF9, 0xF9, 0xF9, 0xFA, 0xFA, 0xFA, 0xFA, 0xFA, 0xFB, 0xFB, 0xFB, 0xFB, 0xFB, 0xFB, 0xFC,
                                            0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0xFD, 0xFD, 0xFD, 0xFD, 0xFD, 0xFD, 0xFD, 0xFD,
                                            0xFD, 0xFD, 0xFD, 0xFD, 0xFD, 0xFD, 0xFD, 0xFE, 0xFE, 0xFE, 0xFE, 0xFE, 0xFE, 0xFE, 0xFF, 0xFF};

        //Mutex mutex = new Mutex();

        //random
        int[] color = new int[3];
        Random rnd = new Random();

        public MessageModule(LedController mainForm)
        {
            _ledController = mainForm;

            serialPort.BaudRate = BAUDRATE;
            serialPort.DataReceived += SerialPort_DataReceived;

            messageSender.Elapsed += MessageSender_Tick;
            messageSender.Interval = 1;
            messageSender.AutoReset = true;
            messageSender.Enabled = false;

            AnalogModesAvailable.Add(new StripMode("Real HSV Rainbow", 0, false, true, true));
            AnalogModesAvailable.Add(new StripMode("Power Conscious Rainbow", 1, false, true, true));
            AnalogModesAvailable.Add(new StripMode("Sine Wave Rainbow", 2, false, true, true));
            AnalogModesAvailable.Add(new StripMode("Static Color", 3, true, false, true));
            AnalogModesAvailable.Add(new StripMode("Breathing", 4, true, true, false));
            AnalogModesAvailable.Add(new StripMode("Musical", 5, false, false, false, StripMode.MoreMode.analogMusical));
            AnalogModesAvailable.Add(new StripMode("Random Color", 6, false, true, true));
            AnalogModesAvailable.Add(new StripMode("Deactivated", 7, false, false, false));

            DigitalModesAvailable.Add(new StripMode("Snake Rainbow", 0, false, true, true));
            DigitalModesAvailable.Add(new StripMode("Real HSV Rainbow (Analog)", 1, false, true, true));
            DigitalModesAvailable.Add(new StripMode("Power Conscious Rainbow (Analog)", 2, false, true, true));
            DigitalModesAvailable.Add(new StripMode("Sine Wave Rainbow (Analog)", 3, false, true, true));
            DigitalModesAvailable.Add(new StripMode("Static Color", 4, true, false, true));
            DigitalModesAvailable.Add(new StripMode("Breathing", 5, true, true, false));
            DigitalModesAvailable.Add(new StripMode("Musical", 6, false, false, false, StripMode.MoreMode.digitalMusical));
            DigitalModesAvailable.Add(new StripMode("Deactivated", 7, false, false, false));
            DigitalModesAvailable.Add(new StripMode("HSV Rainbow", 8, false, true, true));
            DigitalModesAvailable.Add(new StripMode("HSV Rainbow Stripes", 9, false, true, true));
            DigitalModesAvailable.Add(new StripMode("Cloud", 10, false, true, true));
            DigitalModesAvailable.Add(new StripMode("Lava", 11, false, true, true));
            DigitalModesAvailable.Add(new StripMode("Ocean", 12, false, true, true));
            DigitalModesAvailable.Add(new StripMode("Forest", 13, false, true, true));
            DigitalModesAvailable.Add(new StripMode("Party", 14, false, true, true));
            DigitalModesAvailable.Add(new StripMode("Heat", 15, false, true, true));
            DigitalModesAvailable.Add(new StripMode("Custom Pallete", 16, false, true, true, StripMode.MoreMode.digitalCustomPattern));
            //implement cobrinha like pacman sugestao da neechan
        }

        bool ACK_received = true;
        bool NCK_received = false;

        int LastQueueCount = 0;
        float delta_queue = 0;
        
        private void MessageSender_Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                

                if (messageQueue.Count == 0) return;
                if (ACK_received)
                {
                    ACK_received = false;
                    byte[] messageToSend = messageQueue.Dequeue();
                    
                    serialPort.Write(messageToSend, 0, messageToSend.Length);

                }
                if (NCK_received)
                {
                    NCK_received = false;
                    byte[] messageToSend = messageQueue.Peek();
                    serialPort.Write(messageToSend, 0, messageToSend.Length);
                }

                int count = messageQueue.Count;
                _QueueSizeLabel.Text = count.ToString();

                delta_queue = count - LastQueueCount;


                if (delta_queue > 2)
                {
                    _ledController.Invoke(new Action(() =>
                    {
                        _ledController.changeSoundSpectrumInterval(1);
                    }));

                    //Console.WriteLine("AUMENTANDOOOO");
                }
                else if( delta_queue < -2)
                {
                    _ledController.Invoke(new Action(() =>
                    {
                        _ledController.changeSoundSpectrumInterval(-1);
                    }));
                }
                else if (count > 10 && delta_queue > -2 && delta_queue < 2)
                {
                    _ledController.Invoke(new Action(() =>
                    {
                        _ledController.changeSoundSpectrumInterval(1);
                    }));
                }
                else if (count < 2 && delta_queue > -2 && delta_queue < 2)
                {
                    _ledController.Invoke(new Action(() =>
                    {
                        _ledController.changeSoundSpectrumInterval(-1);
                    }));
                }

                else if (count < 5 && delta_queue > -2 && delta_queue < 2)
                {
                    //DO NOTHING, IT IS JUST FINE
                }
                else if( count < 10 && delta_queue > -2 && delta_queue < 2)
                {
                    _ledController.Invoke(new Action(() =>
                    {
                        _ledController.changeSoundSpectrumInterval(-1);
                    }));
                }

                LastQueueCount = count;
            }
            catch (Exception)
            {
                
            }
            
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte input = (byte)serialPort.ReadByte();
            switch (input)
            {
                case ACK:
                    ACK_received = true;
                    break;
                case NCK:
                    NCK_received = true;
                    break;
            }

            //Console.WriteLine("{0:X}",input);
        }

        public void SetStatusLabel(ToolStripStatusLabel COM, 
                                   ToolStripStatusLabel Message, 
                                   ToolStripStatusLabel QueueSize)
        {
            this._COMStatusLabel = COM;
            this._MessageLabel = Message;
            this._QueueSizeLabel = QueueSize;
        }

        public void CommunicationSetup(String porta)
        {
            try
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                    serialPort.PortName = porta;
                    serialPort.Open();
                    messageQueue.Clear();
                    ACK_received = true;
                    messageSender.Enabled = true;
                }
                else
                {
                    serialPort.PortName = porta;
                    serialPort.Open();
                    messageQueue.Clear();
                    ACK_received = true;
                    messageSender.Enabled = true;
                }     

                _COMStatusLabel.Text = porta;
                _MessageLabel.Text = "Connected.";

                Ready = true;
            }
            catch (Exception e)
            {
                messageSender.Enabled = false;
                _COMStatusLabel.Text = porta;
                _MessageLabel.Text = e.Message;

                Ready = false;
            }
        }

        private void SerialWrite(byte[] messageToSend)
        {
            try
            {
                //connection.Write(buffer, 0, count);
                messageQueue.Enqueue(messageToSend);
            }
            catch (Exception e)
            {
                _MessageLabel.Text = e.Message;
            }
        }

        public void Stop()
        {
            Ready = false;
            if (serialPort.IsOpen) serialPort.Close();
            _MessageLabel.Text = "Not Connected";
            _COMStatusLabel.Text = "COM#";
        }

        public void SendDigitalCustomPalette(CustomPalette customPalette)
        {
            if (customPalette == null || !Ready) return;          
            
            //it will send 16 short messages for each color
            //then it will send a message with the properties
            byte[] command = new byte[11];
            command[0] = 0xF0;
            command[1] = STRIP_DATA;
            command[2] = DIGITAL_CUSTOM_PALETTE;
            //payload bytes on for loop below
            command[10] = 0xF7;

            for (int i = 0; i < 16; i++)
            {
                command[3] = (byte) i;
                command[4] = (byte) (customPalette.PatternColors[i].R & 0x7F);
                command[5] = (byte)((customPalette.PatternColors[i].R >> 7) & 0x7F);
                command[6] = (byte) (customPalette.PatternColors[i].G & 0x7F);
                command[7] = (byte)((customPalette.PatternColors[i].G >> 7) & 0x7F);
                command[8] = (byte) (customPalette.PatternColors[i].B & 0x7F);
                command[9] = (byte)((customPalette.PatternColors[i].B >> 7) & 0x7F);

                SerialWrite(command);
            }

            command = new byte[8];

            command[0] = 0xF0;
            command[1] = STRIP_DATA;
            command[2] = DIGITAL_CUSTOM_PALETTE_PROPERTIES;
            command[3] = (customPalette.Blend) ? (byte)0x01 : (byte)0x00;
            command[4] = (customPalette.Animate) ? (byte)0x01 : (byte)0x00;
            command[5] = customPalette.increment;
            command[6] = (byte) customPalette.paletteSize;

            command[7] = 0xF7;
            SerialWrite(command);
        }

        public void SoundSpectrumTick()
        {
            if (SoundSpectrumColor == null || !Ready ) return;

            byte Bass = ExponentialCurve[SoundSpectrumColor.R];
            byte Medio = ExponentialCurve[SoundSpectrumColor.G];
            byte Treble = ExponentialCurve[SoundSpectrumColor.B];

            byte[] command = new byte[10];
            command[0] = 0xF0;
            command[1] = STRIP_DATA;
            command[2] = ANALOG_MUSICAL_PATTERN;

            command[3] = (byte)(Bass & 0x7F);
            command[4] = (byte)((Bass >> 7) & 0x7F);
            command[5] = (byte)(Medio & 0x7F);
            command[6] = (byte)((Medio >> 7) & 0x7F);
            command[7] = (byte)(Treble & 0x7F);
            command[8] = (byte)((Treble >> 7) & 0x7F);

            command[9] = 0xF7;

            SerialWrite(command);
        }

        public void DigitalSoundSpectrumTick()
        {
            if (DigitalSpectrumColor == null || !Ready) return;

            byte Bass = ExponentialCurve[DigitalSpectrumColor.R];
            byte Medio = ExponentialCurve[DigitalSpectrumColor.G];
            byte Treble = ExponentialCurve[DigitalSpectrumColor.B];

            byte[] command = new byte[10];
            command[0] = 0xF0;
            command[1] = STRIP_DATA;
            command[2] = DIGITAL_MUSICAL_PATTERN;

            command[3] = (byte)(Bass & 0x7F);
            command[4] = (byte)((Bass >> 7) & 0x7F);

            command[5] = (byte)(Medio & 0x7F);
            command[6] = (byte)((Medio >> 7) & 0x7F);

            command[7] = (byte)(Treble & 0x7F);
            command[8] = (byte)((Treble >> 7) & 0x7F);

            command[9] = 0xF7;

            SerialWrite(command);
        }

        public byte MapValue(double SourceValue, double FromSource, double ToSource, double FromTarget, double ToTarget)
        {
            return Convert.ToByte(FromTarget + (ToTarget - FromTarget) * ((SourceValue - FromSource) / (ToSource - FromSource)));
        }

        public void SendDigitalMode(byte mode)
        {
            if (!Ready) return;
            

            byte[] command = new byte[5];
            command[0] = 0xF0;
            command[1] = STRIP_DATA;
            command[2] = DIGITAL_CHANGEMODE;
            command[3] = mode;
            command[4] = 0xF7;

            SerialWrite(command);
            
        }

        public void SendDigitalSpeed(byte speed)
        {
            if (!Ready) return;
            
            byte[] command = new byte[5];
            command[0] = 0xF0;
            command[1] = STRIP_DATA;
            command[2] = DIGITAL_CHANGEINTERVAL;
            command[3] = speed;
            command[4] = 0xF7;

            SerialWrite(command);
            
        }

        public void SendDigitalBright(byte bright)
        {
            if (!Ready) return;
            
            byte[] command = new byte[6];
            command[0] = 0xF0;
            command[1] = STRIP_DATA;
            command[2] = DIGITAL_CHANGEBRIGHT;
            command[3] = (byte)(bright & 0x7F);
            command[4] = (byte)(bright >> 7);
            command[5] = 0xF7;

            SerialWrite(command);
            
        }

        public void SendDigitalColor(Color color)
        {
            if (!Ready) return;
            
            byte[] command = new byte[10];
            command[0] = 0xF0;
            command[1] = STRIP_DATA;
            command[2] = DIGITAL_CHANGECOLOR;
            command[3] = (byte)(color.R & 0x7F);
            command[4] = (byte)(color.R >> 7);
            command[5] = (byte)(color.G & 0x7F);
            command[6] = (byte)(color.G >> 7);
            command[7] = (byte)(color.B & 0x7F);
            command[8] = (byte)(color.B >> 7);
            command[9] = 0xF7;

            SerialWrite(command);
            
        }

        public void SendAnalogMode(byte mode)
        {
            if (!Ready) return;
            

            byte[] command = new byte[5];
            command[0] = 0xF0;
            command[1] = STRIP_DATA;
            command[2] = ANALOG_CHANGEMODE;
            command[3] = mode;
            command[4] = 0xF7;

            SerialWrite(command);
            
        }

        public void SendAnalogSpeed(byte speed)
        {
            if (!Ready) return;
            

            byte[] command = new byte[5];
            command[0] = 0xF0;
            command[1] = STRIP_DATA;
            command[2] = ANALOG_CHANGEINTERVAL;
            command[3] = speed;
            command[4] = 0xF7;

            SerialWrite(command);
            
        }

        public void SendAnalogBright(byte bright)
        {
            if (!Ready) return;
            

            byte[] command = new byte[6];
            command[0] = 0xF0;
            command[1] = STRIP_DATA;
            command[2] = ANALOG_CHANGEBRIGHT;
            command[3] = (byte)(bright & 0x7F);
            command[4] = (byte)(bright >> 7);
            command[5] = 0xF7;

            SerialWrite(command);
            
        }

        public void SendAnalogColor(Color color)
        {
            if (!Ready) return;
            

            byte[] command = new byte[10];
            command[0] = 0xF0;
            command[1] = STRIP_DATA;
            command[2] = ANALOG_CHANGECOLOR;
            command[3] = (byte)(color.R & 0x7F);
            command[4] = (byte)(color.R >> 7);
            command[5] = (byte)(color.G & 0x7F);
            command[6] = (byte)(color.G >> 7);
            command[7] = (byte)(color.B & 0x7F);
            command[8] = (byte)(color.B >> 7);
            command[9] = 0xF7;

            SerialWrite(command);
            
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);           
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
                if(serialPort != null)
                {
                    serialPort.Dispose();
                    serialPort = null;
                }
            }
        }
    }
}
