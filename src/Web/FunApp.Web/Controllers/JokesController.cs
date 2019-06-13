//  ------------------------------------------------------------------------------------------------
//   <copyright file="JokesController.cs" company="Business Management System Ltd.">
//       Copyright "2019" (c), Business Management System Ltd.
//       All rights reserved.
//   </copyright>
//   <author>Nikolay.Kostadinov</author>
//  ------------------------------------------------------------------------------------------------

namespace FunApp.Web.Controllers
{
    #region Using

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models.Jokes;
    using Services.DataServices;

    #endregion

    public class JokesController : BaseController
    {
        private readonly ICategoryService categoryService;

        private readonly IJokesService jokesService;

        /// <summary>Initializes a new instance of the <see cref="JokesController" /> class.</summary>
        /// <param name="jokesService">The jokes service.</param>
        /// <param name="categoryService">The category service.</param>
        /// <exception cref="ArgumentNullException">
        ///     jokesService
        ///     or
        ///     categoryService
        /// </exception>
        public JokesController(IJokesService jokesService,
            ICategoryService categoryService)
        {
            this.jokesService = jokesService ?? throw new ArgumentNullException(nameof(jokesService));
            this.categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }


        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            var categories = categoryService.GetAllCategories()
                .Select(c => new SelectListItem($"{c.Name} ({c.JokesCount})", c.Id.ToString()))
                .ToList();
            ViewData["categories"] = categories;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateJokeInputModel joke)
        {
            if (!ModelState.IsValid)
            {
                return View(joke);
            }

            var id = await jokesService.CreateJokeAsync(joke.CategoriId, joke.Content);
            return RedirectToAction("Details", new { id });
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(jokesService.GetJokeById(id));
        }
    }
}