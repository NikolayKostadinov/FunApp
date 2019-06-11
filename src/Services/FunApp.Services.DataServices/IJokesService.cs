//  ------------------------------------------------------------------------------------------------
//   <copyright file="IJokesService.cs" company="Business Management System Ltd.">
//       Copyright "" (c), Business Management System Ltd.
//       All rights reserved.
//   </copyright>
//   <author>Nikolay.Kostadinov</author>
//  ------------------------------------------------------------------------------------------------
namespace FunApp.Services.DataServices
{
    using System.Collections.Generic;
    using FunApp.Models;
    using Models.Home;

    public interface IJokesService
    {
        IEnumerable<IndexJokeViewModel> GetRandomeJokes(int count);
    }
}