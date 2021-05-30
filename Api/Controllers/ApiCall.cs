using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TakeApi.Models;

namespace TakeApi.Controllers
{
    public class APICall
    {

        private static HttpClient GetHttpClient(string url)
        {
            var client = new HttpClient { BaseAddress = new Uri(url) };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            return client;
        }

        private static async Task<List<RepositoryModel>> GetAsync<RepositoryModel>(string url, string urlParameters)
        {
            try
            {
                using (var client = GetHttpClient(url))
                {
                    HttpResponseMessage response = await client.GetAsync(urlParameters);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<List<RepositoryModel>>(json);
                        return result;
                    }

                    return default(List<RepositoryModel>);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default(List<RepositoryModel>);
            }
        }

        public static async Task<List<RepositoryModel>> RunAsync<RepositoryModel>(string url, string urlParameters)
        {
            return await GetAsync<RepositoryModel>(url, urlParameters);
        }
    }
}
