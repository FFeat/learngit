﻿ //------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------


using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFeat.Note.IDal;

using System;
using System.Collections.Generic;

namespace FFeat.Note.Factory
{
    public partial class DbSession:IDbSession
     {
         	  public IActionInfoDal IActionInfoDal=>StaticDalFactory.GetActionInfoDal(); 
    		  public INoteInfoDal INoteInfoDal=>StaticDalFactory.GetNoteInfoDal(); 
    		  public IR_UsreInfo_ActionInfoDal IR_UsreInfo_ActionInfoDal=>StaticDalFactory.GetR_UsreInfo_ActionInfoDal(); 
    		  public IRoleInfoDal IRoleInfoDal=>StaticDalFactory.GetRoleInfoDal(); 
    		  public IUserInfoDal IUserInfoDal=>StaticDalFactory.GetUserInfoDal(); 
    	    
    
    }
    
}
