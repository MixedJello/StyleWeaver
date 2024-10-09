using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StyleWeaver.Finder;

namespace StyleWeaver
{
    public class Fonts
    {
        static string[] targetFontKeys = new string[]
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

        static string[] fontStyleKeys = new string[]
        {
            "fontFamily",
            "fontWeight",
            "fontSize",
            "letterSpacing",
            "lineHeightPx",
            "textCase",
            "italic"
        };

        public static Dictionary<string, object> pageData = new Dictionary<string, object>();
        static Fonts()
        {
            Fonts.pageData = Finder.FindDictByKeyValue(API.ProjectData, "name", "Typography");
        }

        public static Dictionary<string, object> GetFonts()
        { 
            Dictionary<string, object> fonts = new Dictionary<string, object>();
            Dictionary<string, object> styles = new Dictionary<string, object>();
            string[] validKeys = { "fontSize", "lineHeightPx", "letterSpacing" };

            foreach (string key in targetFontKeys)
            {
                styles = Fonts.GetFontStyle();

                if (styles.Count() >= 1)
                {
                    foreach (var style in styles)
                    {
                        if (style.Value is float)
                        {
                            if (validKeys.Contains(style.Key))
                                styles[style.Key] = Math.Round((float)style.Value, 2);
                        }
                        styles[style.Key] = style.Value.ToString();
                        fonts[key + " " + style.Key] = styles[style.Key];
                    }
                }
            }

            return fonts;
        }

        public static Dictionary<string, object> GetFontStyle()
        {
            Dictionary<string, object> fontStyle = new Dictionary<string, object>();

            var style = Finder.FindValueByKey(Fonts.pageData, "style");
            if (style is Dictionary<string, object>)
            {
                foreach (var kvp in style)
                {
                    if (Fonts.fontStyleKeys.Contains(kvp.Key))
                    { 
                        fontStyle.Add(kvp.Key, kvp.Value);
                    }
                }
                
            }
            return fontStyle;
        }
    }
}
