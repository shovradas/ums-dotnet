using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using Ums.Service.Interfaces;
using Ums.Infrastructure.Data.EF;
using System;

namespace Ums.Service.EF
{
    public abstract class ServiceBase<T> : IService<T> where T : class
    {
        private readonly DbContext _ctx;

        public ServiceBase(DbContext context)
        {
            _ctx = context;
        }        
        
        public virtual IEnumerable<T> GetAll()
        {
            return _ctx.Set<T>().ToList();
        }

        public virtual T GetById<Key>(Key id)
        {
            return _ctx.Set<T>().Find(id);
        }

        public virtual bool Insert(T entity)
        {
            //context.Students;
            //context.Set<Student>;
            //context.Set<T>().Add(entity);
            try
            {
                _ctx.Entry(entity).State = EntityState.Added;
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public virtual bool Update(T entity)
        {
            try
            {
                _ctx.Entry(entity).State = EntityState.Modified;
                _ctx.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        //public virtual bool Delete<Key>(Key id)
        //{
        //    try
        //    {
        //        T entity = _ctx.Set<T>().Find(id);
        //        _ctx.Entry(entity).State = EntityState.Deleted;
        //        _ctx.SaveChanges();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
    }
}
