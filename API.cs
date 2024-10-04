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
        static string projectUrlKey = "Xzcw3d0MSWMOphlWXMwg0k";
        static string url = "https://api.figma.com/v1/files/" + projectUrlKey;

        static Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "X-Figma-Token", personalAccessKey }
            };

        public static async Task<object> GetFileDataAsync<T>()
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
                    return await response.Content.ReadFromJsonAsync<T>();
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}, {await response.Content.ReadAsStringAsync()}");
                    return default(T); // Return null or default for type T in case of error
                }
            }
        }

        public static async Task<object> GetProjectData<T>()
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
                    return await response.Content.ReadFromJsonAsync<T>();

                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}, {await response.Content.ReadAsStringAsync()}");
                    return default(T); // Return null or default for type T in case of error
                }
            }
        }

        public static void GetStyleGuide()
        { 
            
        }
    }
}
