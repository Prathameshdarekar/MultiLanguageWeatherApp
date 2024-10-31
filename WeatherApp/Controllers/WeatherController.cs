using System.Threading.Tasks;
using System.Web.Mvc;
using WeatherApp.Services;
using WeatherApp.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web;
using System;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        private readonly WeatherService _weatherService;

        public WeatherController()
        {
            _weatherService = new WeatherService();
        }

        public ActionResult Index()
        {
            // Pass the current culture to the view
            ViewBag.CurrentCulture = Thread.CurrentThread.CurrentCulture.Name;
            return View();
        }

        public List<string> SearchHistory { get; set; } = new List<string>();

        [HttpPost]
        public async Task<ActionResult> GetWeather(string city)
        {
            if (!SearchHistory.Contains(city))
            {
                SearchHistory.Add(city);
            }
            var weatherData = await _weatherService.GetWeatherAsync(city);
            return View("WeatherResult", weatherData);
        }

        [HttpGet]
        public ActionResult SetLanguage(string lang)
        {
            if (!string.IsNullOrEmpty(lang))
            {
                // Set language preference in a cookie
                HttpCookie languageCookie = new HttpCookie("language", lang)
                {
                    Expires = DateTime.Now.AddYears(1) // Set expiration for 1 year
                };
                Response.Cookies.Add(languageCookie);
                // Set current culture based on the selected language
                Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            }

            // Redirect to the previous page or the homepage
            return Redirect(Request.UrlReferrer?.ToString() ?? Url.Action("Index", "Weather"));
        }
    }
}
