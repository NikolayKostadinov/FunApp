//  ------------------------------------------------------------------------------------------------
//   <copyright file="AutoMapperProfile.cs" company="Business Management System Ltd.">
//       Copyright "2019" (c), Business Management System Ltd.
//       All rights reserved.
//   </copyright>
//   <author>Nikolay.Kostadinov</author>
//  ------------------------------------------------------------------------------------------------

namespace FunApp.Services.Mapping
{
    #region Using

    using System;
    using System.Linq;
    using System.Reflection;
    using AutoMapper;

    #endregion

    public class AutoMapperProfile : Profile
    {
        private readonly Assembly[] assemblies;

        public AutoMapperProfile()
        {
            var solutionName = Assembly.GetExecutingAssembly().FullName.Split('.')[0];
            assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.StartsWith(solutionName))
                .ToArray();

            LoadStandardMappings();
            LoadCustomMappings();
            LoadConverters();
        }

        private void LoadConverters()
        {
        }

        private void LoadStandardMappings()
        {
            foreach (var assembly in assemblies)
            {
                var mapsFrom = MapperProfileHelper.LoadStandardMappings(assembly);

                foreach (var map in mapsFrom) CreateMap(map.Source, map.Destination).ReverseMap();
            }
        }

        private void LoadCustomMappings()
        {
            foreach (var assembly in assemblies)
            {
                var mapsFrom = MapperProfileHelper.LoadCustomMappings(assembly);

                foreach (var map in mapsFrom) map.CreateMappings(this);
            }
        }
    }
}