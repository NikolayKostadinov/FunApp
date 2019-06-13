//  ------------------------------------------------------------------------------------------------
//   <copyright file="IJokesService.cs" company="Business Management System Ltd.">
//       Copyright "2019" (c), Business Management System Ltd.
//       All rights reserved.
//   </copyright>
//   <author>Nikolay.Kostadinov</author>
//  ------------------------------------------------------------------------------------------------

namespace FunApp.Services.DataServices
{
    #region Using

    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.Home;

    #endregion

    public interface IJokesService
    {
        IEnumerable<IndexJokeViewModel> GetRandomeJokes(int count);
        Task<int> CreateJokeAsync(int jokeCategoryId, string Cntent);
        JokeDetailsViewModel GetJokeById(int id);
    }
}