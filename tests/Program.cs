//  ------------------------------------------------------------------------------------------------
//   <copyright file="Program.cs" company="Business Management System Ltd.">
//       Copyright "2019" (c), Business Management System Ltd. 
//       All rights reserved.
//   </copyright>
//   <author>Nikolay.Kostadinov</author>
//  ------------------------------------------------------------------------------------------------

namespace SаndBox
{
    #region Using

    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using AngleSharp;
    using FunApp.Data;
    using FunApp.Data.Common;
    using FunApp.Data.Models;
    using FunApp.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    #endregion

    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"{typeof(Program).Namespace} ({string.Join(" ", args)}) starts working...");
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider(true);

            // Seed data on application startup
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<FunAppContext>();
                dbContext.Database.Migrate();
            }

            using (var serviceScope = serviceProvider.CreateScope())
            {
                serviceProvider = serviceScope.ServiceProvider;

                SandboxCode(serviceProvider).GetAwaiter().GetResult();
            }
        }

        private static async Task SandboxCode(IServiceProvider serviceProvider)
        {
            var jokesBuffer = new ConcurrentBag<JokeBuffer>();
            var dbContext = serviceProvider.GetService<FunAppContext>();
            var tasks = new List<Task>();

            for (int i = 40001; i < 50000; i++)//46967; i++)
            {
                tasks.Add(CreateJoke(i, jokesBuffer));
            }

            Task.WaitAll(tasks.ToArray());
            // TODO: Code here
            var dist = jokesBuffer.Select(x => x.CategoryName).Distinct();
            var dbCategories = await dbContext.Categories.Select(x => x).ToArrayAsync();

            var categories = jokesBuffer.Select(x => x.CategoryName).Distinct().Select(y => new Category() { Name = y }).Where(c=>!dbCategories.Any(dc=>dc.Name == c.Name));

            await dbContext.Categories.AddRangeAsync(categories);
            await dbContext.SaveChangesAsync();

            dbCategories = await dbContext.Categories.Select(x => x).ToArrayAsync();

            var jokes = jokesBuffer.Select(jb =>
               new Joke()
               {
                   Content = jb.Content,
                   Category = dbCategories.FirstOrDefault(c => c.Name == jb.CategoryName)
               });

            await dbContext.Jokes.AddRangeAsync(jokes);
            await dbContext.SaveChangesAsync();
        }

        private static async Task CreateJoke(int id, ConcurrentBag<JokeBuffer> jokesBuffer)
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var urlPattern = "https://fun.dir.bg/vic_open.php?id=";
            var address = $"{urlPattern}{id}";
            var document = await context.OpenAsync(address);
            Console.WriteLine($"id => {id}");
            if (document != null)
            {
                var jokeContent = document.QuerySelector("#newsbody")?.TextContent?.Trim();
                var categoryName = document.QuerySelector(".tag-links-left a")?.TextContent.Trim();
                if (!string.IsNullOrEmpty(jokeContent) &&
                    !string.IsNullOrEmpty(categoryName))
                {
                    var jokeBuffer = new JokeBuffer()
                    {
                        CategoryName = categoryName,
                        Content = jokeContent
                    };

                    jokesBuffer.Add(jokeBuffer);
                    Console.WriteLine($"For id: {id} record:{jokesBuffer.Count}");
                }
            }

        }

        private static void ConfigureServices(ServiceCollection serviceCollection)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables()
                .Build();

            serviceCollection.AddDbContext<FunAppContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            // Application services
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));
        }
    }
}