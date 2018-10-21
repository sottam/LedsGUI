using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace LedsGUI
{
    [Serializable]
    [SettingsSerializeAs(SettingsSerializeAs.Binary)]
    public class StripMode
    {
        public enum MoreMode { none, analogMusical, digitalMusical, digitalCustomPattern }
        //interface
        public string Name { get; private set; } = ""; 
        public int ModeNumber { get; private set; } = -1;
        public bool UseColor { get; private set; } = false;
        public bool UseSpeed { get; private set; } = false;
        public bool UseBright { get; private set; } = false;
        public MoreMode moreMode { get; private set; } = MoreMode.none;
        //values
        public byte Speed { get; set; } = 20;
        public byte Bright { get; set; } = 255;


        public StripMode(string Name, int ModeNumber, bool UseColor, bool UseSpeed, bool UseBright, MoreMode moreMode)
        {
            this.Name = Name;
            this.ModeNumber = ModeNumber;
            this.UseColor = UseColor;
            this.UseSpeed = UseSpeed;
            this.UseBright = UseBright;
            this.moreMode = moreMode;
        }

        public StripMode(string Name, int ModeNumber, bool UseColor, bool UseSpeed, bool UseBright)
        {
            this.Name = Name;
            this.ModeNumber = ModeNumber;
            this.UseColor = UseColor;
            this.UseSpeed = UseSpeed;
            this.UseBright = UseBright;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
