using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using static StyleWeaver.Config;



namespace StyleWeaver
{
    public class API
    {
        static string personalAccessKey = Config.personalAccessKey;   //StyleWeaver Key Token
        //Master: vDumLlFAmbWExNHqMBlUxq Project: Xzcw3d0MSWMOphlWXMwg0k
        static string projectUrlKey = "vDumLlFAmbWExNHqMBlUxq";
        static string url = "https://api.figma.com/v1/files/" + projectUrlKey;

        public static Dictionary<string, object> FileData { get; set; }
        public static Dictionary<string, object> ProjectData { get; set; }

        static Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "X-Figma-Token", personalAccessKey }
            };

        public static async Task InitAPI()
        {
            await API.GetProjectData();
            await API.GetFileDataAsync();
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
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    // Deserialize JSON response to the specified type (T)
                    API.FileData = await response.Content.ReadFromJsonAsync<Dictionary<string, object>>();
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}, {await response.Content.ReadAsStringAsync()}");
                    API.FileData = default(Dictionary<string, object>); // Return null or default for type T in case of error
                }
            }
        }

        public static async Task GetProjectData()
        {
            using (HttpClient client = new HttpClient())
            {
                // Add headers
                foreach (var header in headers)
                {
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }

                // Send GET request
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    API.ProjectData = await response.Content.ReadFromJsonAsync<Dictionary<string, object>>();
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}, {await response.Content.ReadAsStringAsync()}");
                    API.ProjectData =  default(Dictionary<string, object>); // Return null or default for type T in case of error
                }
            }
        }

    }
}
