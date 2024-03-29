﻿//  ------------------------------------------------------------------------------------------------
//   <copyright file="IndexViewModel.cs" company="Business Management System Ltd.">
//       Copyright "2019" (c), Business Management System Ltd.
//       All rights reserved.
//   </copyright>
//   <author>Nikolay.Kostadinov</author>
//  ------------------------------------------------------------------------------------------------

namespace FunApp.Services.Models.Home
{
    #region Using

    using System.Collections.Generic;

    #endregion

    public class IndexViewModel
    {
        public IEnumerable<IndexJokeViewModel> Jokes { get; set; }
    }
}