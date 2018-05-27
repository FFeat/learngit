using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFeat.Note.IDal
{
   public partial interface IDbSession
   {
       int SaveChange();
        //IUserInfoDal IUserInfoDal { get; }
    }
}
