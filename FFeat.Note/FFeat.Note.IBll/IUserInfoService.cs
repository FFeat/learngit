using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using FFeat.Note.Model;

namespace FFeat.Note.IBll
{
    //服务契约

   public partial interface IUserInfoService:IBaseService<UserInfo>
    {
        bool SettRole(int userId, List<int> roleIds);
    }
}
