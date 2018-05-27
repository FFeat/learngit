using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFeat.Note.IDal;

namespace FFeat.Note.Factory
{
    public partial class DbSession : IDbSession
    {
        //public IUserInfoDal IUserInfoDal => throw new NotImplementedException();

        //public IUserInfoDal IUserInfoDal => StaticDalFactory.GetUserInfoDal();

        public int SaveChange()
        {
            return DbContextFactory.GetCurrentDbContext().SaveChanges();
        }
    }
}
