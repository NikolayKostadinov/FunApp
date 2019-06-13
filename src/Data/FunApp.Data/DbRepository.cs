//  ------------------------------------------------------------------------------------------------
//   <copyright file="DbRepository.cs" company="Business Management System Ltd.">
//       Copyright "2019" (c), Business Management System Ltd.
//       All rights reserved.
//   </copyright>
//   <author>Nikolay.Kostadinov</author>
//  ------------------------------------------------------------------------------------------------

namespace FunApp.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Common;
    using Microsoft.EntityFrameworkCore;

    public class DbRepository<TEntity> : IRepository<TEntity>, IDisposable
        where TEntity : class
    {
        private readonly FunAppContext context;
        private readonly DbSet<TEntity> dbSet;

        public DbRepository(FunAppContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(this.context));
            this.dbSet = this.context.Set<TEntity>();
        }

        public IQueryable<TEntity> All() => this.dbSet;

        public Task AddAsync(TEntity entity) => this.dbSet.AddAsync(entity);

        public void Update(TEntity entity) => this.dbSet.Update(entity);

        public void Delete(TEntity entity) => this.dbSet.Remove(entity);

        public Task<int> SaveChangesAsync() => this.context.SaveChangesAsync();

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}