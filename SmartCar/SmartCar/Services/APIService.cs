using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SmartCar.Services
{
    public class APIService<T>
    {
        private static readonly string BASE_URL = "http://localhost:5285/api/";
        static HttpClient client = new HttpClient() { Timeout = TimeSpan.FromSeconds(60) };

        public static async Task PostAsync(string endPoint, T data)
        {
            try
            {
                string url = BASE_URL + endPoint;
                var response = await client.PostAsJsonAsync(url, data);

                if (response.StatusCode != System.Net.HttpStatusCode.Created)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Request failed with status code {response.StatusCode}: {responseContent}");
                }

            }
            catch (Exception ex)
            {
                // Log the exception details (using your logging framework)
                Console.WriteLine($"Error in PostAsync: {ex.Message}");
                throw; // Re-throw the exception
            }
        }

    }
}
