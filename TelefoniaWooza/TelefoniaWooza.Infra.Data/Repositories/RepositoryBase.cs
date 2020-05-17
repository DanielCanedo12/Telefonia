using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TelefoniaWooza.Domain.Interfaces.Repositories;

namespace TelefoniaWooza.Infra.Data.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected DbContext Context { get; }


        public RepositoryBase(DbContext db)
        {
            Context = db;
        }

        public TEntity Get(int id)
        {

            return Context.Set<TEntity>().Find(id);
        }


        public virtual IEnumerable<TEntity> Get()
        {
            return Context.Set<TEntity>().ToList();
        }

        public TEntity Add(TEntity obj)
        {
            return Context.Set<TEntity>().Add(obj).Entity;
        }

        public void Update(TEntity obj)
        {
            Context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(TEntity obj)
        {
            Context.Set<TEntity>().Remove(obj);
        }

        public void Delete(int id)
        {
            Context.Set<TEntity>().Remove(Get(id));
        }        

    }

}
