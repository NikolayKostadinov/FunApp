//  ------------------------------------------------------------------------------------------------
//   <copyright file="IdAndNameViewModel.cs" company="Business Management System Ltd.">
//       Copyright "" (c), Business Management System Ltd.
//       All rights reserved.
//   </copyright>
//   <author>Nikolay.Kostadinov</author>
//  ------------------------------------------------------------------------------------------------
namespace FunApp.Services.DataServices
{
    using FunApp.Models;
    using Mapping;

    public class CategoryIdAndNameViewModel:IMapFrom<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int JokesCount { get; set; }
    }
}