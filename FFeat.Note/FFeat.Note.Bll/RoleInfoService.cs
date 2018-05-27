using FFeat.Note.IBll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFeat.Note.Bll
{
    public partial class RoleInfoService : IRoleInfoService
    {
        public bool SetAction(int roleId, List<int> actinIds)
        {
            var role = DbSession.IRoleInfoDal.GetEntities(r => r.Id == roleId).FirstOrDefault();
            role.ActionInfo.Clear();
            var allAction = DbSession.IActionInfoDal.GetEntities(a => actinIds.Contains(a.Id));
            foreach (var item in allAction)
            {
                role.ActionInfo.Add(item);
            }
            DbSession.SaveChange();
            return true;
        }
    }
}
