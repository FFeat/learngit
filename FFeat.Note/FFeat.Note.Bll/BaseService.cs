using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FFeat.Note.IDal;

namespace FFeat.Note.Bll
{
    public abstract class BaseService<T> where T : class, new()
    {
        public IBaseDal<T> CurrentDal { get; set; }
        public IDbSession DbSession { get; set; }
        public abstract void SetCurrentDal();

        public BaseService(IDbSession DbSession)
        {
            this.DbSession = DbSession;
            SetCurrentDal();

        }

        public IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda)
        {
            return CurrentDal.GetEntities(whereLambda);

        }

        public IQueryable<T> GetEntitesByPage<S>(int pageSize, int pageIndex, out int total,
            Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc)
        {
            return CurrentDal.GetEntitesByPage<S>(pageSize, pageIndex, out total, whereLambda, orderByLambda, isAsc);

        }

        public T Add(T entities)
        {
            CurrentDal.Add(entities);
            DbSession.SaveChange();
            return entities;
        }

        public bool Delete(int id)
        {
            CurrentDal.Delete(id);
            return DbSession.SaveChange() > 0;
        }

        public bool Delete(T entities)
        {
            CurrentDal.Delete(entities);
            return DbSession.SaveChange() > 0;
        }

        public int LogicalDelete(List<int> ids)
        {
            //foreach (var id in ids)
            //{
            //    CurrentDal.Delete(id);
            //}
            CurrentDal.LogicalDelete(ids);

            return DbSession.SaveChange();
        }

        public bool Edit(T entites)
        {
            CurrentDal.Edit(entites);
            return DbSession.SaveChange() > 0;
        }
    }
}
