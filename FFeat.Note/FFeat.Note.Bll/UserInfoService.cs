using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFeat.Note.IBll;
using FFeat.Note.IDal;
using FFeat.Note.Model;

namespace FFeat.Note.Bll
{
    public partial class UserInfoService : BaseService<UserInfo>, IUserInfoService
    {
     public bool SettRole(int userId,List<int> roleIds)
        {
            var user= DbSession.IUserInfoDal.GetEntities(u => u.Id == userId).FirstOrDefault();
            
            user.RoleInfo.Clear();
            var allUser = DbSession.IRoleInfoDal.GetEntities(r => roleIds.Contains(r.Id));
            foreach (var item in allUser)
            {
                user.RoleInfo.Add(item);
            }

            DbSession.SaveChange();
            return true;
        }
      
    }
}
