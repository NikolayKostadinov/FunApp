//  ------------------------------------------------------------------------------------------------
//   <copyright file="JokesService.cs" company="Business Management System Ltd.">
//       Copyright "2019" (c), Business Management System Ltd.
//       All rights reserved.
//   </copyright>
//   <author>Nikolay.Kostadinov</author>
//  ------------------------------------------------------------------------------------------------

namespace FunApp.Services.DataServices
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data.Common;
    using FunApp.Models;
    using Mapping;
    using Microsoft.EntityFrameworkCore;
    using Models.Home;

    #endregion

    public class JokesService : IJokesService
    {
        private readonly IRepository<Joke> jokesRepository;
        private readonly IMapper mapper;

        public JokesService(IRepository<Joke> jokesRepository, IMapper mapper)
        {
            this.jokesRepository = jokesRepository ?? throw new ArgumentNullException(nameof(jokesRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<IndexJokeViewModel> GetRandomeJokes(int count)
        {
            return jokesRepository.All()
                .Include(j => j.Category)
                .OrderBy(j => Guid.NewGuid())
                .To<IndexJokeViewModel>(this.mapper.ConfigurationProvider)
                .Take(count)
                .ToList();

            //return this.mapper.Map<IEnumerable<IndexJokeViewModel>>(dbJokes);
        }

        public async Task<int> CreateJokeAsync(int jokeCategoryId, string content)
        {
            var newJoke = new Joke
            {
                CategoryId = jokeCategoryId,
                Content = content
            };

            await jokesRepository.AddAsync(newJoke);
            await jokesRepository.SaveChangesAsync();

            return newJoke.Id;
        }

        public JokeDetailsViewModel GetJokeById(int id)
        {
            return this.jokesRepository.All()
                .Where(x => x.Id == id)
                .To<JokeDetailsViewModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefault();
        }
    }
}