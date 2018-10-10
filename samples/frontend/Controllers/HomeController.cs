using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using frontend.Models;

namespace frontend.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> About()
        {
            ViewData["Message"] = "Hello from Frontend";

            using (var client = new System.Net.Http.HttpClient())
                {
                    // Call *mywebapi*, and display its response in the page
                    var request = new System.Net.Http.HttpRequestMessage();
                    request.RequestUri = new Uri("http://webapi/api/values");
                    if (this.Request.Headers.ContainsKey("azds-route-as"))
                    {
                        // Propagate the dev space routing header
                        request.Headers.Add("azds-route-as", this.Request.Headers["azds-route-as"] as IEnumerable<string>);
                    }
                    var response = await client.SendAsync(request);
                    ViewData["Message"] += " and " + await response.Content.ReadAsStringAsync();
                }

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
