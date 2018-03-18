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
        internal Dictionary<string, Color> AnalogBackColors { get; set; }
        internal Color AnalogFixedCustomColor { get; set; }

        internal Dictionary<string, Color> DigitalBackColors { get; set; }
        internal Color DigitalFixedCustomColor { get; set; }

        internal String SelectedArduinoPort { get; set; }

        internal List<FirmataMode> AnalogModesAvailable { get; set; }
        internal List<FirmataMode> DigitalModesAvailable { get; set; }

        internal int AnalogSelectedModeIndex   { get; set; }
        internal int DigitalSelectedModeIndex { get; set; }

        internal CustomPalette LastActivatedPalette { get; set; }

        internal Settings()
        {
            AnalogBackColors = new Dictionary<string, Color>();
            AnalogFixedCustomColor = new Color();

            DigitalBackColors = new Dictionary<string, Color>();
            AnalogFixedCustomColor = new Color();

            AnalogModesAvailable = new List<FirmataMode>();
            DigitalModesAvailable = new List<FirmataMode>();
    }

        internal void Save(string fileName = @"LEDSGUIsettings.ini")
        {
            string FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\LEDsGUI\\";

            if (!System.IO.Directory.Exists(FolderPath))
                System.IO.Directory.CreateDirectory(FolderPath);

            using (FileStream stream = File.Create(FolderPath + fileName))
            {
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(stream, this);
            }
        }

        internal static Settings Load(string fileName = @"LEDSGUIsettings.ini")
        {
            string FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\LEDsGUI\\";

            if (!System.IO.Directory.Exists(FolderPath))
                System.IO.Directory.CreateDirectory(FolderPath);

            if (!File.Exists(FolderPath + fileName))
                return null;
            using (FileStream stream = File.OpenRead(FolderPath + fileName))
            {
                BinaryFormatter serializer = new BinaryFormatter();
                return serializer.Deserialize(stream) as Settings;
            }
        }
    }
}
