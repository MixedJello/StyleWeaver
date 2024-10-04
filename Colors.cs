using static StyleWeaver.Finder;
using static StyleWeaver.API;
using Microsoft.VisualBasic;
using System;

namespace StyleWeaver
{
    public class Colors
    {
        static Colors()
        {
            string key = "name";
            string value = "Colors";
            var pageData = Finder.FindDictByKeyValue(API.GetProjectData<object>(), key, value);

        }

        string[] targetLTColorKeys = new string[]
        {
            "--primary",
            "--secondary",
            "--text",
            "--link",
            "--main-bg",
            "--inner-bg",
            "--accent",
            "--buttons"
        };

        string[] targetDKColorKeys = new string[]
        {
            "--primary-alt",
            "--secondary-alt",
            "--text-alt",
            "--link-alt",
            "--main-bg-alt",
            "--inner-bg-alt",
            "--accent-alt"
        };

        public static string ConvertRGBtoHex(string r, string g, string b)
        { 
            var red = Double.Parse(r) * 255;
            var green= Double.Parse(g) * 255;
            var blue= Double.Parse(b) * 255;

            return $"#{red:X2}{green:X2}{blue:X2}";
        }
    }
}
