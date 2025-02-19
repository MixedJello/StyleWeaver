using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static StyleWeaver.API;

namespace StyleWeaver
{
    public class Image
    {
        //Goal
        //Needs to get all IDs for all images in the FileData
        //Pass those IDs to the correct endpoint

        public static dynamic imageIDs;

        public static Dictionary<int, string> imageUrl;
        public static dynamic imagesContainer { get; set; }
        public Image()
        {
            //Image.imageIDs = API.FileData.SelectTokens("$..fills[?(@.type == 'IMAGE')]"); //$..[?(@.type == 'IMAGE')]  $..[?(@.fills && @.fills[?(@.type == 'IMAGE')])]
            //Console.WriteLine();
            var count = 0;
            Image.imageUrl = new Dictionary<int, string>();
            foreach (var imageNode in imagesContainer)
            {
                Console.WriteLine(imageNode.First.ToString());
                imageUrl.Add(count, imageNode.First.ToString());
                count++;
            }
            Console.WriteLine();

        }

        public static void DownloadImage()
        {

        }



    }
}
