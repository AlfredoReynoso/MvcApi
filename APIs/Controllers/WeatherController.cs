using APIs.Models.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace APIs.Controllers
{
    public class WeatherController : Controller
    {

        private static HttpClient client = new HttpClient();
        private string apiKey = "5546c71651754323e17a1a660279a933";

        public ActionResult Index ()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(string Name)
        {
            if (string.IsNullOrEmpty(Name))
            {
                ViewBag.Mensaje = "Por favor ingrese una ciudad";
                return View();
            }

            string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={Name}&appid={apiKey}&units=metric";

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if(response.IsSuccessStatusCode)
            {
                string jsonData = await response.Content.ReadAsStringAsync();
                var weatherData = JsonConvert.DeserializeObject<WeatherModel>(jsonData);
                return View(weatherData);
            }
            else
            {
                ViewBag.Mensaje = "No se encontró la ciudad o ocurrió un error.";
                return View();
            }

        }

    }
}