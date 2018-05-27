using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FFeat.Note.Factory;

namespace FFeat.Note.Dal
{
    public class BaseDal<T> where T : class, new()
    {
        public DbContext Db
        {
            get { return DbContextFactory.GetCurrentDbContext(); }
        }

        public IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda)
        {
            return Db.Set<T>().Where(whereLambda).AsQueryable();
        }

        public IQueryable<T> GetEntitesByPage<S>(int pageSize, int pageIndex, out int total,
            Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc)
        {
            total = Db.Set<T>().Where(whereLambda).Count();
            if (isAsc)
            {
                return Db.Set<T>().Where(whereLambda).OrderBy<T, S>(orderByLambda).Skip(pageSize * (pageIndex - 1))
                    .Take(pageSize).AsQueryable();
            }
            else
            {
                return Db.Set<T>().Where(whereLambda).OrderByDescending<T, S>(orderByLambda)
                    .Skip(pageSize * (pageIndex - 1)).Take(pageSize).AsQueryable();

            }
        }

        public T Add(T entities)
        {
            Db.Set<T>().Add(entities);
            return entities;
        }

        public bool Delete(int id)
        {
            Db.Set<T>().Remove(Db.Set<T>().Find(id));
            return true;
        }

        public bool Delete(T entities)
        {
            Db.Entry(entities).State = System.Data.Entity.EntityState.Deleted;
            return true;
        }

        public int LogicalDelete(List<int> ids)
        {
            foreach (var id in ids)
            {
                var entities = Db.Set<T>().Find(id);
                Db.Entry(entities).Property("DelFlag").CurrentValue = (short)FFeat.Note.Model.EnumNote.DelFlagEnum.Deleted;
                Db.Entry(entities).Property("DelFlag").IsModified = true;
            }

            return ids.Count();
        }

        public bool Edit(T entites)
        {
            Db.Entry(entites).State = EntityState.Modified;
            return true;
        }
    }
}
