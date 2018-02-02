using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace LedsGUI
{
    [Serializable]
    sealed class Settings
    {
        //internal Dictionary<string, Color> ForeColors { get; set; }
        internal Dictionary<string, Color> BackColors { get; set; }
        internal Color FixedCustomColor { get; set; }

        internal String SelectedArduinoPort { get; set; }

        internal int True_HSV_Speed     { get; set; }
        internal int Power_HSV_Speed    { get; set; }
        internal int Sine_Speed         { get; set; }
        internal int Flash_Speed        { get; set; }
        internal int Smooth_Speed       { get; set; }
        internal int Breath_Speed       { get; set; }

        internal bool True_HSV_Checked  { get; set; }
        internal bool Power_HSV_Checked { get; set; }
        internal bool Sine_Checked      { get; set; }
        internal bool Flash_Checked     { get; set; }
        internal bool Smooth_Checked    { get; set; }
        internal bool Breath_Checked    { get; set; }

        internal bool AlternateWithFade { get; set; }
        internal bool Breath            { get; set; }

        internal int SelectedTabIndex   { get; set; }

        internal bool StartWithWindows  { get; set; }

        internal Settings()
        {
            //ForeColors = new Dictionary<string, Color>();
            BackColors = new Dictionary<string, Color>();
            FixedCustomColor = new Color();
        }

        internal void Save(string fileName = @"LEDSGUIsettings.ini")
        {
            using (FileStream stream = File.Create(Environment.GetFolderPath(Environment.SpecialFolder
                .LocalApplicationData) + "\\" + fileName))
            {
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(stream, this);
            }
        }

        internal static Settings Load(string fileName = @"LEDSGUIsettings.ini")
        {
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder
                .LocalApplicationData) + "\\" + fileName)) return null;
            using (FileStream stream = File.OpenRead(Environment.GetFolderPath(Environment.SpecialFolder
                .LocalApplicationData) + "\\" + fileName))
            {
                BinaryFormatter serializer = new BinaryFormatter();
                return serializer.Deserialize(stream) as Settings;
            }
        }
    }
}
