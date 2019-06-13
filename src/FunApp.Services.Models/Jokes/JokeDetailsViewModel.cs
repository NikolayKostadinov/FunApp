//  ------------------------------------------------------------------------------------------------
//   <copyright file="JokeDetailsViewModel.cs" company="Business Management System Ltd.">
//       Copyright "" (c), Business Management System Ltd.
//       All rights reserved.
//   </copyright>
//   <author>Nikolay.Kostadinov</author>
//  ------------------------------------------------------------------------------------------------
namespace FunApp.Services.DataServices
{
    using AutoMapper;
    using FunApp.Models;
    using Mapping;

    public class JokeDetailsViewModel:IMapFrom<Joke>, IHaveCustomMappings
    {
        public string Content { get; set; }
        public string CategoryName { get; set; }
        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Joke, JokeDetailsViewModel>()
                .ForMember(p => p.Content, opt => opt.MapFrom(p => p.Content.Replace("\n", "<br/>")));
        }
    }
}