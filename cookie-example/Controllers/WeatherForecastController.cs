using cookie_example.Constants;
using cookie_example.Models;
using cookie_example.Services;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace cookie_example.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly ICookieService _cookieService;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ICookieService cookieService, ILogger<WeatherForecastController> logger)
        {
            _cookieService = cookieService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var oldData = _cookieService.GetCookie<WeatherForecast[]>(AuthConstants.AuthCookie);
            if (oldData != null)
            {
                var x = oldData.Length;
            }
            var data = GetData();
            _cookieService.SetCookie(AuthConstants.AuthCookie, data);
            return data;
        }

        private static WeatherForecast[] GetData()
        {
            var rng = new Random();
            var data = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
            return data;
        }

        
    }
}