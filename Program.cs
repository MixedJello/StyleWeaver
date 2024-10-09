using System;
using static StyleWeaver.API;
using static StyleWeaver.ColorsSW;
using static StyleWeaver.Fonts;
using static StyleWeaver.FileManagement;
using System.Threading;
using System.Drawing;

namespace StyleWeaver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Thread cThread = new Thread(Colors);*/
            API apiContainer = new API();

            API.GetProjectData();
            var data = API.ProjectData;


            var fontStyle = Fonts.GetFonts();

            var ltColorStyle = ColorsSW.GetLTColor();
            var dkColorStyle = ColorsSW.GetDKColor();

            var colors = ColorsSW.GetColors(ltColorStyle, dkColorStyle);

            var fm = FileManagement.CleanData(fontStyle);
            FileManagement.ApplyReplacements(colors, "colors.txt");

            Console.ReadLine(); 
        }

        /*static void Colors()
        { 
            ColorsSW color = new ColorsSW();
            //Keeping these colors seperate for now. Will optimize once working
            color.LTColors = color.GetLTColor();
            color.DKColors = color.GetDKColor();

            color.allColors = color.GetColors(color.LTColors, color.DKColors);
        }*/

    }
}
