using System;
using static StyleWeaver.API;
using static StyleWeaver.ColorsSW;
using static StyleWeaver.Fonts;
using static StyleWeaver.FileManagement;
using System.Threading;
using System.Drawing;
using System.Threading.Tasks;

namespace StyleWeaver
{
    internal class Program
    {
        static void Main(string[] args)
        {
        
            API apiContainer = new API();

            var apiTask = Task.Run(async () => await API.InitAPI());
            apiTask.Wait();

            ColorsSW colorsSW = new ColorsSW();
            Fonts fonts = new Fonts();

            

            var fontStyle = Fonts.GetFonts();

            var fm = FileManagement.CleanData(fontStyle);
            FileManagement.ApplyReplacements(ColorsSW.allColors, "colors.txt");

            Console.ReadLine(); 
        }



    }
}
