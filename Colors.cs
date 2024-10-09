using static StyleWeaver.Finder;
using static StyleWeaver.API;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;

namespace StyleWeaver
{
    public class ColorsSW
    {
        public ColorsSW()
        {
            string key = "name";
            string value = "Colors";
            Dictionary<string, object> pageData = Finder.FindDictByKeyValue(API.ProjectData, key, value);

        }

        public static Dictionary<string, object> pageData = new Dictionary<string, object>();

        public static Dictionary<string, object> LTColors { get; set; }
        public static Dictionary<string, object> DKColors { get; set; }
        public static Dictionary<string, object> allColors { get; set; }
        

        static string[] targetLTColorKeys = new string[]
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

        static string[] targetDKColorKeys = new string[]
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

        public static string GetColorStyles(Dictionary<string, object> pageDate)
        {
            var style = Finder.FindValueByKey(pageDate, "color");
            var hexValue = ConvertRGBtoHex(style["r"].ToString(), style["g"].ToString(), style["b"].ToString());
            return hexValue;
        }

        public static void GetLTColor()
        {
            Dictionary<string, object> ltColor = new Dictionary<string, object>();
            var ltDict = Finder.FindGrandparentContainer(ColorsSW.pageData, "characters", "Light Colors");

            foreach (var item in ColorsSW.targetLTColorKeys)
            {
                var style = ColorsSW.GetColorStyles(Finder.FindDictByKeyValue(ltDict, "name", item));
                ltColor[item] = style;
            }
            ColorsSW.LTColors = ltColor;
        }

        public static void GetDKColor()
        {
            Dictionary<string, object> dkColor = new Dictionary<string, object>();
            var dkDict = Finder.FindGrandparentContainer(ColorsSW.pageData, "characters", "Dark Colors");

            foreach (var item in ColorsSW.targetLTColorKeys)
            {
                var formatString = item.Replace("-alt", "");
                var style = ColorsSW.GetColorStyles(Finder.FindDictByKeyValue(dkDict, "name", formatString));
                dkColor[item] = style;
            }
             ColorsSW.DKColors = dkColor;
        }

        public static void GetColors(Dictionary<string, object> ltDict, Dictionary<string, object> dkDict)
        {
            foreach (var item in dkDict)
            {
                ltDict[item.Key] = item.Value;
            }
            ColorsSW.allColors = ltDict;
        }
    }
}
