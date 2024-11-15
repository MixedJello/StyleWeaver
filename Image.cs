using System;
using System.Collections.Generic;
using System.Linq;
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
        public Image()
        {
            Image.imageIDs = API.FileData.SelectTokens("$.children..fills[?(@.type == 'IMAGE')]");
        }


        
    }
}
