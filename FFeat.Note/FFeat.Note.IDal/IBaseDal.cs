using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FFeat.Note.IDal
{
    public interface IBaseDal<T> where T:class,new()
    {
        IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda);

        IQueryable<T> GetEntitesByPage<S>(int pageSize, int pageIndex, out int total,
            Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc);

        T Add(T entities);
        bool Delete(int id);
        bool Delete(T entities);
        int LogicalDelete(List<int> ids);
        bool Edit(T entites);
    }
}
