using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LedsGUI
{
    class XMLCustomPalettes
    {
        private string xmlPath;
        private string FolderPath;

        XElement xml;

        public XMLCustomPalettes()
        {
            
            FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\LEDsGUI\\";
            xmlPath = FolderPath + "SavedCustomPalettes.xml";

            bool exists = System.IO.Directory.Exists(FolderPath);

            if (!exists)
                System.IO.Directory.CreateDirectory(FolderPath);

            if (File.Exists(xmlPath))
            {
                xml = XElement.Load(xmlPath);
            }
            else
            {
                xml = new XElement(new XElement("SavedPalettes"));
                xml.Save(xmlPath);
            }
        }

        public void AddPalette(CustomPalette cp)
        {
            XElement palette = new XElement("Palette");
            palette.Add(new XAttribute("name", cp.Name));
            palette.Add(new XAttribute("animated", cp.Animate));
            palette.Add(new XAttribute("blend", cp.Blend));
            palette.Add(new XAttribute("incr", cp.increment));
            palette.Add(new XAttribute("palettesize", cp.paletteSize));
            for(int i = 0; i < 16; i++)
            {
                palette.Add(new XAttribute(("color" + i), cp.PatternColors[i].ToArgb()));
            }
           
            xml.Add(palette);

            xml.Save(xmlPath);
        }

        public void RemovePalette(String name)
        {
            XElement x = xml.Elements().Where(p => p.Attribute("name").Value.Equals(name.ToString())).First();
            if (x != null)
            {
                x.Remove();
            }
            xml.Save(xmlPath);
        }

        public bool CheckExistance(string name)
        {
            XElement x = xml.Elements().Where(p => p.Attribute("name").Value.Equals(name.ToString())).First();
            if (x != null)
                return true;
            else
                return false;
        }

        public void ModifySavedPalette(CustomPalette paletteToModify)
        {
            XElement x = xml.Elements().Where(p => p.Attribute("name").Value.Equals(paletteToModify.Name.ToString())).First();
            if (x == null)
                return;
            else
            {
                x.Attribute("name").SetValue(paletteToModify.Name);
                x.Attribute("animated").SetValue(paletteToModify.Animate);
                x.Attribute("blend").SetValue(paletteToModify.Blend);
                x.Attribute("incr").SetValue(paletteToModify.increment);
                x.Attribute("palettesize").SetValue(paletteToModify.paletteSize);

                for(int i = 0; i < 16; i++)
                {
                    x.Attribute("color" + i).SetValue(paletteToModify.PatternColors[i].ToArgb());
                }

                xml.Save(xmlPath);
            }
        }

        public List<CustomPalette> LoadSavedPalettes()
        {
            List<CustomPalette> LoadedPalettes = new List<CustomPalette>();

            foreach (XElement x in xml.Elements())
            {
                Color[] LoadedPaletteColors = new Color[16];
                for(int i = 0; i < 16; i++)
                {
                    LoadedPaletteColors[i] = Color.FromArgb( Convert.ToInt32( x.Attribute("color" + i).Value));
                }

                CustomPalette.PaletteSize savedSize;
                if (x.Attribute("palettesize").Value == "P16")
                    savedSize = CustomPalette.PaletteSize.P16;
                else if (x.Attribute("palettesize").Value == "P32")
                    savedSize = CustomPalette.PaletteSize.P32;
                else
                    savedSize = CustomPalette.PaletteSize.P256;

                CustomPalette loadedPalette = new CustomPalette(x.Attribute("name").Value,
                                                                 LoadedPaletteColors,
                                                                 Convert.ToBoolean( x.Attribute("animated").Value),
                                                                 Convert.ToBoolean( x.Attribute("blend").Value),
                                                                 Convert.ToByte(x.Attribute("incr").Value),
                                                                 savedSize
                                                                );
                LoadedPalettes.Add(loadedPalette);
            }
            return LoadedPalettes;
        }
    }
}
