using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace FFeat.Note.IBll
{
    [ServiceContract]
    public interface IBaseService<T> where T : class, new()
    {
        
        IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda);

        
        IQueryable<T> GetEntitesByPage<S>(int pageSize, int pageIndex, out int total,
            Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc);
        [OperationContract]
        T Add(T entities);

        [OperationContract]
        bool Delete(int id);


        bool Delete(T entities);

        [OperationContract]
        int LogicalDelete(List<int> ids);

        [OperationContract]
        bool Edit(T entites);
    }
}
