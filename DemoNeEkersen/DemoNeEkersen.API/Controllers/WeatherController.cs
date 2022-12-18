using DemoNeEkersen.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace DemoNeEkersen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {

        [HttpGet]
        public Task<string> GetWeatherDataAsync([FromQuery] string city)
        {
            var url = "https://api.collectapi.com/weather/getWeather?data.lang=tr&data.city=" + city;
            var cred = "1hMTsyxsmafiqLe2kesFUB:3rPMG8j4nzuyapKaIlIXeO";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("apikey", cred);
            // List data response.
            HttpResponseMessage response = client.GetAsync(url).Result;

            ResponseWeatherData result = new ResponseWeatherData();

            if (response.IsSuccessStatusCode)
            {
                string dataObjects = response.Content.ReadAsStringAsync().Result;
                return Task.FromResult(dataObjects);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            // Dispose once all HttpClient calls are complete.
            client.Dispose();

            return Task.FromResult("");
        }

    }
}
