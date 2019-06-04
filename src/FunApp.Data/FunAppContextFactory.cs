//  ------------------------------------------------------------------------------------------------
//   <copyright file="FunAppContextFactory.cs" company="Business Management System Ltd.">
//       Copyright "2019" (c), Business Management System Ltd. 
//       All rights reserved.
//   </copyright>
//   <author>Nikolay.Kostadinov</author>
//  ------------------------------------------------------------------------------------------------

namespace FunApp.Data
{
    #region Using

    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.EntityFrameworkCore.Diagnostics;
    using Microsoft.Extensions.Configuration;

    #endregion

    public class FunAppContextFactory : IDesignTimeDbContextFactory<FunAppContext>
    {
        public FunAppContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            var builder = new DbContextOptionsBuilder<FunAppContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);
            builder.ConfigureWarnings(w => w.Throw(RelationalEventId.QueryClientEvaluationWarning));

            return new FunAppContext(builder.Options);
        }
    }
}