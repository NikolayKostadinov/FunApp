using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace FunApp.Web.Controllers
{
    using System;
    using System.Linq;
    using Data.Common;
    using FunApp.Models;
    using Services.DataServices;
    using Services.Models;
    using Services.Models.Home;

    public class HomeController : BaseController
    {
        private readonly IJokesService jokesService;

        public HomeController(IJokesService jokesService)
        {
            this.jokesService = jokesService ?? throw new ArgumentNullException(nameof(jokesService));
        }

        public IActionResult Index()
        {
            var jokes = this.jokesService.GetRandomeJokes(20);
            var viewModel = new IndexViewModel() { Jokes = jokes };
            return View(viewModel);
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
