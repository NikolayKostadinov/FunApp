using System;
using System.Collections.Generic;
using System.Text;

namespace FunApp.Services.DataServices
{
    using System.Linq;
    using Data.Common;
    using FunApp.Models;
    using Microsoft.EntityFrameworkCore;
    using Models.Home;

    public class JokesService : IJokesService
    {
        private readonly IRepository<Joke> jokesRepository;

        public JokesService(IRepository<Joke> jokesRepository)
        {
            this.jokesRepository = jokesRepository ?? throw new ArgumentNullException(nameof(jokesRepository));
        }

        public IEnumerable<IndexJokeViewModel> GetRandomeJokes(int count)
        {
            return this.jokesRepository.All()
                .Include(j => j.Category)
                .OrderBy(j => Guid.NewGuid())
                .Select(j =>
                    new IndexJokeViewModel
                    {
                        Content = j.Content.Replace("\n", "</br>"),
                        CategoryName = j.Category.Name
                    })
                .Take(count)
                .ToList();
        }
    }
}
