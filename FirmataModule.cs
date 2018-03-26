using Solid.Arduino;
using Solid.Arduino.Firmata;
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


    public class FirmataModule : IDisposable
    {
        public bool Ready { get; private set; } = false;
        private bool isSendingCustomPalette = false;

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

        public List<FirmataMode> AnalogModesAvailable = new List<FirmataMode>();
        public List<FirmataMode> DigitalModesAvailable = new List<FirmataMode>();

        
        private EnhancedSerialConnection connection;
        private ArduinoSession arduino;

        private ToolStripStatusLabel _COMStatusLabel;
        private ToolStripStatusLabel _MessageLabel;

        private Random random = new Random();

        public static Color SoundSpectrumColor = new Color();
        public static Color[] DigitalSpectrumPattern = new Color[8];

        //random
        int[] color = new int[3];
        Random rnd = new Random();

        public FirmataModule()
        {
            AnalogModesAvailable.Add(new FirmataMode("Real HSV Rainbow", 0, false, true, true));
            AnalogModesAvailable.Add(new FirmataMode("Power Conscious Rainbow", 1, false, true, true));
            AnalogModesAvailable.Add(new FirmataMode("Sine Wave Rainbow", 2, false, true, true));
            AnalogModesAvailable.Add(new FirmataMode("Static Color", 3, true, false, true));
            AnalogModesAvailable.Add(new FirmataMode("Breathing", 4, true, true, false));
            AnalogModesAvailable.Add(new FirmataMode("Musical", 5, false, false, false, FirmataMode.MoreMode.analogMusical));
            AnalogModesAvailable.Add(new FirmataMode("Random Color", 6, false, true, true));
            AnalogModesAvailable.Add(new FirmataMode("Deactivated", 7, false, false, false));

            DigitalModesAvailable.Add(new FirmataMode("Snake Rainbow", 0, false, true, true));
            DigitalModesAvailable.Add(new FirmataMode("Real HSV Rainbow (Analog)", 1, false, true, true));
            DigitalModesAvailable.Add(new FirmataMode("Power Conscious Rainbow (Analog)", 2, false, true, true));
            DigitalModesAvailable.Add(new FirmataMode("Sine Wave Rainbow (Analog)", 3, false, true, true));
            DigitalModesAvailable.Add(new FirmataMode("Static Color", 4, true, false, true));
            DigitalModesAvailable.Add(new FirmataMode("Breathing", 5, true, true, false));
            DigitalModesAvailable.Add(new FirmataMode("Musical", 6, false, false, false, FirmataMode.MoreMode.digitalMusical));
            DigitalModesAvailable.Add(new FirmataMode("Deactivated", 7, false, false, false));
            DigitalModesAvailable.Add(new FirmataMode("HSV Rainbow", 8, false, true, true));
            DigitalModesAvailable.Add(new FirmataMode("HSV Rainbow Stripes", 9, false, true, true));
            DigitalModesAvailable.Add(new FirmataMode("Cloud", 10, false, true, true));
            DigitalModesAvailable.Add(new FirmataMode("Lava", 11, false, true, true));
            DigitalModesAvailable.Add(new FirmataMode("Ocean", 12, false, true, true));
            DigitalModesAvailable.Add(new FirmataMode("Forest", 13, false, true, true));
            DigitalModesAvailable.Add(new FirmataMode("Party", 14, false, true, true));
            DigitalModesAvailable.Add(new FirmataMode("Heat", 15, false, true, true));
            DigitalModesAvailable.Add(new FirmataMode("Custom Pallete", 16, false, true, true, FirmataMode.MoreMode.digitalCustomPattern));
            //implement cobrinha like pacman sugestao da neechan
        }

        public void SetStatusLabel(ToolStripStatusLabel COM, ToolStripStatusLabel Message)
        {
            this._COMStatusLabel = COM;
            this._MessageLabel = Message;
        }

        public void FirmataSetup(String porta)
        {
            try
            {
                if (arduino != null)
                {
                arduino.Clear();
                arduino.Dispose();
                }

                connection = new EnhancedSerialConnection(porta, SerialBaudRate.Bps_9600);
                arduino = new ArduinoSession(connection);

                _COMStatusLabel.Text = porta;
                _MessageLabel.Text = "Connected.";

                Ready = true;
            }
            catch (Exception e)
            {
                _COMStatusLabel.Text = porta;
                _MessageLabel.Text = e.Message;

                Ready = false;
            }
        }

        private void FirmataSerialWrite(byte[] buffer, int count)
        {
            try
            {
                connection.Write(buffer, 0, count);
            }
            catch (Exception e)
            {
                _MessageLabel.Text = e.Message;
            }
        }

        public void Stop()
        {
            Ready = false;
            if(arduino != null) arduino.Dispose();
            _MessageLabel.Text = "Not Connected";
            _COMStatusLabel.Text = "COM#";
        }

        public void SendDigitalCustomPalette(CustomPalette customPalette)
        {
            if (customPalette == null || !Ready) return;
            //ensure that the cummunication channel is clear as possible
            //if analog musicalmode is active, it will not send any updates to analog strip
            //while a custom digital palette is being sent
            isSendingCustomPalette = true;
            
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

                FirmataSerialWrite(command, command.Length);
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
            FirmataSerialWrite(command, command.Length);


            isSendingCustomPalette = false;

        }

        public void SoundSpectrumTick()
        {
            if (SoundSpectrumColor == null || !Ready || isSendingCustomPalette) return;

            byte[] command = new byte[10];
            command[0] = 0xF0;
            command[1] = STRIP_DATA;
            command[2] = ANALOG_MUSICAL_PATTERN;

            command[3] = (byte)(SoundSpectrumColor.R & 0x7F);
            command[4] = (byte)((SoundSpectrumColor.R >> 7) & 0x7F);
            command[5] = (byte)(SoundSpectrumColor.G & 0x7F);
            command[6] = (byte)((SoundSpectrumColor.G >> 7) & 0x7F);
            command[7] = (byte)(SoundSpectrumColor.B & 0x7F);
            command[8] = (byte)((SoundSpectrumColor.B >> 7) & 0x7F);

            command[9] = 0xF7;

            FirmataSerialWrite(command, command.Length);

        }

        public void DigitalSoundSpectrumTick()
        {
            if (DigitalSpectrumPattern == null || !Ready) return;

            byte[] command = new byte[16];
            command[0] = 0xF0;
            command[1] = STRIP_DATA;
            command[2] = DIGITAL_MUSICAL_PATTERN;

            command[3] = (byte)(DigitalSpectrumPattern[0].R & 0x7F);
            command[4] = (byte)((DigitalSpectrumPattern[0].R >> 7) & 0x7F);

            command[5] = (byte)(DigitalSpectrumPattern[1].G & 0x7F);
            command[6] = (byte)((DigitalSpectrumPattern[1].G >> 7) & 0x7F);

            command[7] = (byte)(DigitalSpectrumPattern[2].B & 0x7F);
            command[8] = (byte)((DigitalSpectrumPattern[2].B >> 7) & 0x7F);

            command[9] = 0xF7;

            FirmataSerialWrite(command, command.Length);
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

            FirmataSerialWrite(command, command.Length);
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

            FirmataSerialWrite(command, command.Length);
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

            FirmataSerialWrite(command, command.Length);
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

            FirmataSerialWrite(command, command.Length);
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

            FirmataSerialWrite(command, command.Length);
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

            FirmataSerialWrite(command, command.Length);
        }

        public void SendAnalogBright(byte bright)
        {
            if (!Ready) return;

            byte[] command = new byte[5];
            command[0] = 0xF0;
            command[1] = ANALOG_CHANGEBRIGHT;
            command[2] = (byte)(bright & 0x7F);
            command[3] = (byte)(bright >> 7);
            command[4] = 0xF7;

            FirmataSerialWrite(command, command.Length);
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

            FirmataSerialWrite(command, command.Length);
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
                if (connection != null)
                {
                    connection.Dispose();
                    connection = null;
                }

                if (arduino != null)
                {
                    arduino.Dispose();
                    arduino = null;
                }
            }
        }
    }
}
