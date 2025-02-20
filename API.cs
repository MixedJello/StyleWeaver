using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static StyleWeaver.Config;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;


namespace StyleWeaver
{
    public class API
    {
        static string personalAccessKey = Config.personalAccessKey;   //StyleWeaver Key Token
        static string projectUrlKey = Config.projectUrlKey;
        static string url = "https://api.figma.com/v1/files/" + projectUrlKey;
        
        static string urlIDs = url + "/nodes?ids=2009:1582,4197:1402"; 

        static string imageAPIPath = "/images";

        public static dynamic FileData { get; set; }
        public static dynamic ProjectData { get; set; }

        static Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "X-Figma-Token", personalAccessKey }
            };

        public static async Task InitAPI()
        {
            await API.GetFileDataAsync();

        }

        public static async Task InitImageAPI()
        {
            await API.GetImageDataAsync();

        }
        public static async Task GetImageDataAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                // Add headers
                foreach (var header in headers)
                {
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }

                // Send GET request
                HttpResponseMessage response = await client.GetAsync(url + imageAPIPath);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    /*//Save jsonString as a txt file
                    string fileName = "fileDataImage.txt";
                    string projectDirectory = Directory.GetCurrentDirectory();
                    string filePath = Path.Combine(projectDirectory, fileName);
                    File.WriteAllText(filePath, jsonResponse);*/

                    dynamic output = JObject.Parse(jsonResponse);
                    Console.WriteLine();
                    Image.imagesContainer = output["meta"]["images"];
                    Console.WriteLine();


                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}, {await response.Content.ReadAsStringAsync()}");
                    API.FileData = default(Dictionary<string, object>); // Return null or default for type T in case of error
                }
            }


        }
        public static async Task GetFileDataAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                // Add headers
                foreach (var header in headers)
                {
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }

                // Send GET request
                HttpResponseMessage response = await client.GetAsync(urlIDs);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    /*//Save jsonString as a txt file
                    string fileName = "fileDataImage.txt";
                    string projectDirectory = Directory.GetCurrentDirectory();
                    string filePath = Path.Combine(projectDirectory, fileName);
                    File.WriteAllText(filePath, jsonResponse);*/

                    dynamic output = JObject.Parse(jsonResponse);

                    API.FileData = output["nodes"]["2009:1582"];

                    API.ProjectData = output["nodes"]["4197:1402"];

                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}, {await response.Content.ReadAsStringAsync()}");
                    API.FileData = default(Dictionary<string, object>); // Return null or default for type T in case of error
                }
            }


        }

    }

}
