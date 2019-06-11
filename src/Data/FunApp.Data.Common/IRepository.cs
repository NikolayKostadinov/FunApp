//  ------------------------------------------------------------------------------------------------
//   <copyright file="IRepository.cs" company="Business Management System Ltd.">
//       Copyright "2019" (c), Business Management System Ltd.
//       All rights reserved.
//   </copyright>
//   <author>Nikolay.Kostadinov</author>
//  ------------------------------------------------------------------------------------------------

namespace FunApp.Data.Common
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary></summary>
    public interface IRepository<TEntity>
    where TEntity : class
    {
        IQueryable<TEntity> All();

        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        Task<int> SaveChangesAsync();
    }
}