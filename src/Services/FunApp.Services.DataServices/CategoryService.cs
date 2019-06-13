//  ------------------------------------------------------------------------------------------------
//   <copyright file="CategoryService.cs" company="Business Management System Ltd.">
//       Copyright "" (c), Business Management System Ltd.
//       All rights reserved.
//   </copyright>
//   <author>Nikolay.Kostadinov</author>
//  ------------------------------------------------------------------------------------------------
namespace FunApp.Services.DataServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data.Common;
    using FunApp.Models;
    using Mapping;
    using Microsoft.EntityFrameworkCore;

    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> categoriesRepository;
        private readonly IMapper mapper;

        public CategoryService(IRepository<Category> categoriesRepository, IMapper mapper)
        {
            this.categoriesRepository =
                categoriesRepository ?? throw new ArgumentNullException(nameof(categoriesRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<CategoryIdAndNameViewModel> GetAllCategories()
        {
            var categories = this.categoriesRepository.All()
                .OrderBy(cr=>cr.Name)
                .To<CategoryIdAndNameViewModel>(this.mapper.ConfigurationProvider)
                .ToList();
            return categories;
        }

        public async Task<bool> IsValidCategoryIdAsync(int jokeCategoriId)
        {
            return await this.categoriesRepository.All().AnyAsync(c => c.Id == jokeCategoriId);
        }
    }
}