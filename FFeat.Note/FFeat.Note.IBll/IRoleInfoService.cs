using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFeat.Note.IBll
{
    public partial interface IRoleInfoService
    {
        bool SetAction(int roleId, List<int> actinIds);
   
    }
}
