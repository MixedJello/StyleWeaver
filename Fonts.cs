using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StyleWeaver
{
    public class Fonts
    {

        public static dynamic pageData;

        public static string[] targetFontKeys;

        public static string[] fontStyleKeys;

        public static Dictionary<string, string> fontStyles = new Dictionary<string, string>();

        public Fonts()
        {
            Fonts.pageData = API.ProjectData.SelectToken($"..children[?(@.name == 'Typography')]");
            InitializeVariables();
            GetFonts();
            Console.WriteLine();
        }
        public static void InitializeVariables()
        {
            Fonts.targetFontKeys = new string[]
            {
                "Title Big",
                "Callout",
                "Title 1",
                "Title 2",
                "Title 3",
                "Title 4",
                "Title 5",
                "Title 6",
                "Paragraph",
                "Large Paragraph",
                "Primary Nav Link",
                "Secondary Nav",
                "Button text",
                "Quote",
                "Item",
                "Note",
                "Form Label",
                "Kicker",
                "Phone Number",
                "Tag",
                "Author Name"
            };

            Fonts.fontStyleKeys = new string[]
            {
                "fontFamily",
                "fontWeight",
                "fontSize",
                "letterSpacing",
                "lineHeightPx",
                "textCase",
                "italic"
            };
        }

        public static void GetFonts()
        {
            string[] intKeys = { "fontSize", "lineHeightPx", "letterSpacing" };
            Dictionary<string, string> fonts = new Dictionary<string, string>();

            foreach (var fontKey in Fonts.targetFontKeys)
            {
                var fontObject = Fonts.pageData.SelectToken($"..children[?(@.name == '{fontKey}')]");

                foreach (var fontStyle in Fonts.fontStyleKeys)
                {
                    var style = fontObject.SelectToken($"style.{fontStyle}");
                    if (style == null)
                    {
                        Console.WriteLine(fontStyle + " in " + fontKey + " - Doesn't Exist. Creating an empty value");
                        fonts[fontKey + " " + fontStyle] = "";
                        continue;
                    }
                    //Need to find a way to round this.
                    if (Array.Exists(intKeys, key => key == fontStyle) && style.Type == JTokenType.Float && style.Value % 1 != 0)// && Array.Exists(intKeys, key => key == fontStyle)
                    {
                        style = Math.Round(style.Value, 2);
                    }
                    fonts[fontKey + " " + fontStyle] = style.ToString();
                }
            }

            Fonts.fontStyles = fonts;
        }

    }
}
