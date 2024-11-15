using System;
using static StyleWeaver.API;
using static StyleWeaver.ColorsSW;
using static StyleWeaver.Fonts;
using static StyleWeaver.FileManagement;
using System.Threading;
using System.Drawing;
using System.Threading.Tasks;
using System.Diagnostics;

namespace StyleWeaver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch total = Stopwatch.StartNew();
            total.Start();

            API apiContainer = new API();

            var apiTask = Task.Run(async () => await API.InitAPI());
            apiTask.Wait();

            ColorsSW colorsSW = new ColorsSW();

            Fonts fonts = new Fonts();

            FileManagement fileManagement = new FileManagement();


            total.Stop();
            TimeSpan totalTS = total.Elapsed;

            string totalElapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            totalTS.Hours, totalTS.Minutes, totalTS.Seconds,
            totalTS.Milliseconds / 10);
            Console.WriteLine("Total Time: " + totalElapsedTime);


            //Image image = new Image();
        }



    }
}
