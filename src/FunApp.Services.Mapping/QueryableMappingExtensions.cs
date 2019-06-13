//  ------------------------------------------------------------------------------------------------
//   <copyright file="QueryableMappingExtensions.cs" company="Business Management System Ltd.">
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
    using System.Linq.Expressions;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    #endregion

    public static class QueryableMappingExtensions
    {
        public static IQueryable<TDestination> To<TDestination>(
            this IQueryable source,
            IConfigurationProvider configuration,
            params Expression<Func<TDestination, object>>[] membersToExpand)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.ProjectTo(configuration, membersToExpand);
        }

        public static IQueryable<TDestination> To<TDestination>(
            this IQueryable source,
            IConfigurationProvider configuration,
            object parameters)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.ProjectTo<TDestination>(configuration, parameters);
        }
    }
}