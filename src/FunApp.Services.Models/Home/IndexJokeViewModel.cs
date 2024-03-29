﻿//  ------------------------------------------------------------------------------------------------
//   <copyright file="IndexJokeViewModel.cs" company="Business Management System Ltd.">
//       Copyright "2019" (c), Business Management System Ltd.
//       All rights reserved.
//   </copyright>
//   <author>Nikolay.Kostadinov</author>
//  ------------------------------------------------------------------------------------------------

namespace FunApp.Services.Models.Home
{
    #region Using

    using AutoMapper;
    using FunApp.Models;
    using Mapping;

    #endregion

    public class IndexJokeViewModel : IMapFrom<Joke>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string CategoryName { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Joke, IndexJokeViewModel>()
                .ForMember(p => p.Content, opt => opt.MapFrom(p => p.Content.Replace("\n", "<br/>")));
        }
    }
}