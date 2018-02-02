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

namespace LedsGUI
{
    class FirmataModule
    {
        byte[] lights = new byte[360] {       0,   0,   0,   0,   0,   1,   1,   2,
                                              2,   3,   4,   5,   6,   7,   8,   9,
                                             11,  12,  13,  15,  17,  18,  20,  22,
                                             24,  26,  28,  30,  32,  35,  37,  39,
                                             42,  44,  47,  49,  52,  55,  58,  60,
                                             63,  66,  69,  72,  75,  78,  81,  85,
                                             88,  91,  94,  97, 101, 104, 107, 111,
                                            114, 117, 121, 124, 127, 131, 134, 137,
                                            141, 144, 147, 150, 154, 157, 160, 163,
                                            167, 170, 173, 176, 179, 182, 185, 188,
                                            191, 194, 197, 200, 202, 205, 208, 210,
                                            213, 215, 217, 220, 222, 224, 226, 229,
                                            231, 232, 234, 236, 238, 239, 241, 242,
                                            244, 245, 246, 248, 249, 250, 251, 251,
                                            252, 253, 253, 254, 254, 255, 255, 255,
                                            255, 255, 255, 255, 254, 254, 253, 253,
                                            252, 251, 251, 250, 249, 248, 246, 245,
                                            244, 242, 241, 239, 238, 236, 234, 232,
                                            231, 229, 226, 224, 222, 220, 217, 215,
                                            213, 210, 208, 205, 202, 200, 197, 194,
                                            191, 188, 185, 182, 179, 176, 173, 170,
                                            167, 163, 160, 157, 154, 150, 147, 144,
                                            141, 137, 134, 131, 127, 124, 121, 117,
                                            114, 111, 107, 104, 101,  97,  94,  91,
                                             88,  85,  81,  78,  75,  72,  69,  66,
                                             63,  60,  58,  55,  52,  49,  47,  44,
                                             42,  39,  37,  35,  32,  30,  28,  26,
                                             24,  22,  20,  18,  17,  15,  13,  12,
                                             11,   9,   8,   7,   6,   5,   4,   3,
                                              2,   2,   1,   1,   0,   0,   0,   0,
                                              0,   0,   0,   0,   0,   0,   0,   0,
                                              0,   0,   0,   0,   0,   0,   0,   0,
                                              0,   0,   0,   0,   0,   0,   0,   0,
                                              0,   0,   0,   0,   0,   0,   0,   0,
                                              0,   0,   0,   0,   0,   0,   0,   0,
                                              0,   0,   0,   0,   0,   0,   0,   0,
                                              0,   0,   0,   0,   0,   0,   0,   0,
                                              0,   0,   0,   0,   0,   0,   0,   0,
                                              0,   0,   0,   0,   0,   0,   0,   0,
                                              0,   0,   0,   0,   0,   0,   0,   0,
                                              0,   0,   0,   0,   0,   0,   0,   0,
                                              0,   0,   0,   0,   0,   0,   0,   0,
                                              0,   0,   0,   0,   0,   0,   0,   0,
                                              0,   0,   0,   0,   0,   0,   0,   0,
                                              0,   0,   0,   0,   0,   0,   0,   0};

        byte[] HSVlights = new byte[61] {     0,   4,   8,  13,  17,  21,  25,  30,  34,  38,  42,  47,  51,  55,  59,  64,
                                             68,  72,  76,  81,  85,  89,  93,  98, 102, 106, 110, 115, 119, 123, 127, 132,
                                            136, 140, 144, 149, 153, 157, 161, 166, 170, 174, 178, 183, 187, 191, 195, 200,
                                            204, 208, 212, 217, 221, 225, 229, 234, 238, 242, 246, 251, 255 };

        byte[] HSVpower = new byte[121] {     0,   2,   4,   6,   8,  11,  13,  15,  17,  19,  21,  23,  25,  28,  30,
                                             32,  34,  36,  38,  40,  42,  45,  47,  49,  51,  53,  55,  57,  59,  62,
                                             64,  66,  68,  70,  72,  74,  76,  79,  81,  83,  85,  87,  89,  91,  93,
                                             96,  98, 100, 102, 104, 106, 108, 110, 113, 115, 117, 119, 121, 123, 125,
                                            127, 130, 132, 134, 136, 138, 140, 142, 144, 147, 149, 151, 153, 155, 157,
                                            159, 161, 164, 166, 168, 170, 172, 174, 176, 178, 181, 183, 185, 187, 189,
                                            191, 193, 195, 198, 200, 202, 204, 206, 208, 210, 212, 215, 217, 219, 221,
                                            223, 225, 227, 229, 232, 234, 236, 238, 240, 242, 244, 246, 249, 251, 253,
                                            255 };

        byte[] Breath = new byte[101] {  255, 252, 249, 247, 244, 242, 239, 237, 234, 232, 229, 226, 224, 221, 219, 216,
                                         214, 211, 209, 206, 204, 201, 198, 196, 193, 191, 188, 186, 183, 181, 178, 175,
                                         173, 170, 168, 165, 163, 160, 158, 155, 153, 150, 147, 145, 142, 140, 137, 135,
                                         132, 130, 127, 124, 122, 119, 117, 114, 112, 109, 107, 104, 102,  99,  96,  94,
                                          91,  89,  86,  84,  81,  79,  76,  73,  71,  68,  66,  63,  61,  58,  56,  53,
                                          51,  48,  45,  43,  40,  38,  35,  33,  30,  28,  25,  22,  20,  17,  15,  12,
                                          10,   7,   5,   2,   0 };
         
        List<Color> Colors = new List<Color>(7);
        List<Color> ColorsSmooth = new List<Color>(3);
        
        public static class Pinos
        {
            public const int red = 11;
            public const int green = 10;
            public const int blue = 9;
        }

        private ArduinoSession arduino;

        private Random random = new Random();

        byte redValue, greenValue, blueValue;

        public static Color SoundSpectrumColor = new Color();
        
        //random
        int a0, a1, a2;
        int[] color = new int[3];
        int randomCount = 0;

        Color LastColor;
        Random rnd = new Random();

        public void FirmataSetup(String porta)
        {
            if (arduino != null)
            {
                arduino.Clear();
                arduino.Dispose();
            }

            try
            {
                arduino = new ArduinoSession(new EnhancedSerialConnection(porta, SerialBaudRate.Bps_57600));
                arduino.SetDigitalPinMode(Pinos.red, PinMode.PwmOutput);
                arduino.SetDigitalPinMode(Pinos.green, PinMode.PwmOutput);
                arduino.SetDigitalPinMode(Pinos.blue, PinMode.PwmOutput);
            }
            catch (Exception)
            {

                throw;
            }

            Colors.Add(Color.Red);
            Colors.Add(Color.Orange);
            Colors.Add(Color.Yellow);
            Colors.Add(Color.Green);
            Colors.Add(Color.Cyan);
            Colors.Add(Color.Blue);
            Colors.Add(Color.FromArgb(255, 0, 255)); //pink

            ColorsSmooth.Add(Color.Red);
            ColorsSmooth.Add(Color.Green);
            ColorsSmooth.Add(Color.Blue);
        }

        public void Stop()
        {
            Desactivated();
            arduino.Dispose();
        }

        public void Desactivated()
        {
            arduino.SetDigitalPin(Pinos.red, 0);
            arduino.SetDigitalPin(Pinos.green, 0);
            arduino.SetDigitalPin(Pinos.blue, 0);
        }

        public void StaticSingleColor(byte red, byte green, byte blue)
        {
            arduino.SetDigitalPin(Pinos.red, red);
            arduino.SetDigitalPin(Pinos.green, green);
            arduino.SetDigitalPin(Pinos.blue, blue);
        }

        public void StaticSingleColor(Color Color)
        {
            arduino.SetDigitalPin(Pinos.red, Color.R);
            arduino.SetDigitalPin(Pinos.green, Color.G);
            arduino.SetDigitalPin(Pinos.blue, Color.B);
        }

        public void BreathTick(Color color, float percent)
        {
            arduino.SetDigitalPin(Pinos.red,   (int) (color.R * percent) );
            arduino.SetDigitalPin(Pinos.green, (int) (color.G * percent) );
            arduino.SetDigitalPin(Pinos.blue,  (int) (color.B * percent) );
        }

        public void RealHSVTick(int angle)
        {
            if (angle < 60)
            {
                redValue = 255;
                greenValue = HSVlights[angle];
                blueValue = 0;
            }
            else if (angle < 120)
            {
                redValue = HSVlights[120 - angle];
                greenValue = 255;
                blueValue = 0;
            }
            else if (angle < 180)
            {
                redValue = 0;
                greenValue = 255;
                blueValue = HSVlights[angle - 120];
            }
            else if (angle < 240)
            {
                redValue = 0;
                greenValue = HSVlights[240 - angle];
                blueValue = 255;
            }
            else if (angle < 300)
            {
                redValue = HSVlights[angle - 240];
                greenValue = 0;
                blueValue = 255;
            }
            else
            {
                redValue = 255;
                greenValue = 0;
                blueValue = HSVlights[360 - angle];
            }

            arduino.SetDigitalPin(Pinos.blue, blueValue);
            arduino.SetDigitalPin(Pinos.green, greenValue);
            arduino.SetDigitalPin(Pinos.red, redValue);
        }

        public void PowerHSVTick(int angle)
        {
            if (angle < 120)
            {
                redValue = HSVpower[120 - angle];
                greenValue = HSVpower[angle];
                blueValue = 0;
            }
            else if (angle < 240)
            {
                redValue = 0;
                greenValue = HSVpower[240 - angle];
                blueValue = HSVpower[angle - 120];
            }
            else
            {
                redValue = HSVpower[angle - 240];
                greenValue = 0;
                blueValue = HSVpower[360 - angle];
            }

            arduino.SetDigitalPin(Pinos.blue, blueValue);
            arduino.SetDigitalPin(Pinos.green, greenValue);
            arduino.SetDigitalPin(Pinos.red, redValue);
        }

        public void SineWaveTick(int angle)
        {
            redValue = lights[(angle + 120) % 360];
            greenValue = lights[angle];
            blueValue = lights[(angle + 240) % 360];

            arduino.SetDigitalPin(Pinos.red, redValue);
            arduino.SetDigitalPin(Pinos.green, greenValue);
            arduino.SetDigitalPin(Pinos.blue, blueValue);
        }

        [Obsolete] public void OldFlashTimerTick()
        {
            a0 = random.Next(240);
            color[randomCount] = lights[a0];
            a1 = random.Next(1);
            a2 = ((~ a1) + randomCount + 1) % 3;
            a1 = (randomCount + a1 + 1) % 3;
            color[a1] = lights[(a0 + 100) % 240];
            color[a2] = 0;

            arduino.SetDigitalPin(Pinos.red, color[0]);
            arduino.SetDigitalPin(Pinos.green, color[1]);
            arduino.SetDigitalPin(Pinos.blue, color[2]);

            randomCount = (randomCount + 1) % 3;
        }

        public void FlashTimerTick()
        {
            List<Color> CoresDisponiveis = new List<Color>();
            Colors.ForEach((item) => { CoresDisponiveis.Add(item); });

            if (LastColor != null)
                CoresDisponiveis.Remove(LastColor);

            Color SortedColor = CoresDisponiveis[rnd.Next(100) % 6];
            LastColor = SortedColor;

            StaticSingleColor(SortedColor.R, SortedColor.G, SortedColor.B);
        }

        public void SmoothRandomTick()
        {
            List<Color> CoresDisponiveis = new List<Color>();
            ColorsSmooth.ForEach((item) => { CoresDisponiveis.Add(item); });

            if (LastColor != null)
                CoresDisponiveis.Remove(LastColor);

            Color SortedColor = CoresDisponiveis[rnd.Next(100) % 2];
            LastColor = SortedColor;

            StaticSingleColor(SortedColor.R, SortedColor.G, SortedColor.B);
        }

        public void SoundSpectrumTick()
        {
            if(SoundSpectrumColor != null)
                StaticSingleColor(SoundSpectrumColor);
        }
    }
}
