using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedsGUI
{
    public class CustomPalette
    {
        public enum PaletteSize { P16, P32, P256 };

        public Color[] PatternColors    { get; private set; } = new Color[16];
        public String Name              { get; private set; }
        public bool Animate             { get; private set; }
        public bool Blend               { get; private set; }
        public byte increment           { get; private set; }
        public PaletteSize paletteSize  { get; private set; }


        public CustomPalette( String Name, Color[] PatternColors, bool Animate, bool Blend, byte increment, PaletteSize paletteSize)
        {
            this.Name = Name;
            this.PatternColors = PatternColors;
            this.Animate = Animate;
            this.Blend = Blend;
            this.increment = increment;
            this.paletteSize = paletteSize;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            var item = obj as CustomPalette;

            if (item == null)
                return false;

            return this.Name.Equals(item.Name);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
