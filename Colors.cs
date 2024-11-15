using static StyleWeaver.Finder;
using static StyleWeaver.API;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace StyleWeaver
{
    public class ColorsSW
    {
        public static dynamic pageData;
        public static Dictionary<string, object> LTColors { get; set; }
        public static Dictionary<string, object> DKColors { get; set; }
        public static Dictionary<string, string> allColors { get; set; }
        public static JObject ltUSCSwatch { get; set; }
        public static JObject dkUSCSwatch { get; set; }

        public ColorsSW()
        {
            ColorsSW.pageData = API.ProjectData.SelectToken($"..children[?(@.name == 'Colors')]");

            GetAllColors();

        }


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

        public static void GetAllColors() 
        {
            GetUSCSwatches(); //Grabs the USC Swatches used in Figma and adds both light and dark
            GetLTColor(); //Grabs the light colors
            GetDKColor(); //Grabs the dark colors

            ColorsSW.allColors = new Dictionary<string, string>();

            foreach (var kvp in ColorsSW.LTColors)
            {
                ColorsSW.allColors.Add(kvp.Key, kvp.Value.ToString());
            }

            foreach (var kvp in ColorsSW.DKColors)
            {
                ColorsSW.allColors.Add(kvp.Key, kvp.Value.ToString());
            }
        }

        public static void GetUSCSwatches() 
        {
            var USCSwatches = ColorsSW.pageData.SelectTokens($"..children[?(@.name == 'USC Swatches')]");


            int index = 0;
            foreach (var u in USCSwatches)
            {
                if (index == 0)
                {
                    ltUSCSwatch = u;
                    index++;
                    continue;
                }
                dkUSCSwatch = u;
            }
        }

        public static string ConvertRGBtoHex(string r, string g, string b)
        {

            var red = Convert.ToUInt32(Double.Parse(r) * 255);  //var red = Convert.ToUInt32(Math.Round(Double.Parse(r), 2) * 255);
            var green= Convert.ToUInt32(Double.Parse(g) * 255); //var green= Convert.ToUInt32(Math.Round(Double.Parse(g), 2) * 255);
            var blue= Convert.ToUInt32(Double.Parse(b) * 255); //var blue= Convert.ToUInt32(Math.Round(Double.Parse(b), 2) * 255);

            return $"#{red:X2}{blue:X2}{green:X2}";
        }

        public static void GetLTColor()
        {
            Dictionary<string, object> ltColor = new Dictionary<string, object>();
            foreach (var color in ColorsSW.targetLTColorKeys)
            {
                var colorObject = ColorsSW.ltUSCSwatch.SelectToken($"..children[?(@.name == '{color}')]");

                var colorStyle = colorObject.SelectTokens("..[?(@.color)]");
                string rgb = null;
                foreach (var value in colorStyle)
                {
                    
                    if (value.SelectToken("color.r") != null)
                    {

                        var r = value["color"]["r"].ToString();
                        var b = value["color"]["b"].ToString();
                        var g = value["color"]["g"].ToString();

                        rgb = ConvertRGBtoHex(r, b, g);
                    }
                    ltColor[color] = rgb;
                }
                
            }
            ColorsSW.LTColors = ltColor;
        }

        public static void GetDKColor()
        {
            Dictionary<string, object> dkColor = new Dictionary<string, object>();
            foreach (var color in ColorsSW.targetDKColorKeys)
            {
                var removedAltColor = color.Substring(0, (color.Count() - 4) );
                var colorObject = ColorsSW.dkUSCSwatch.SelectToken($"..children[?(@.name == '{removedAltColor}')]");

                var colorStyle = colorObject.SelectTokens("..[?(@.color)]");
                Console.WriteLine();
                string rgb = null;
                foreach (var value in colorStyle)
                {

                    if (value.SelectToken("color.r") != null)
                    {

                        var r = value["color"]["r"].ToString();
                        var b = value["color"]["b"].ToString();
                        var g = value["color"]["g"].ToString();

                        rgb = ConvertRGBtoHex(r, b, g);
                    }
                    dkColor[color] = rgb;
                }

            }
            ColorsSW.DKColors = dkColor;
        }
    }
}
