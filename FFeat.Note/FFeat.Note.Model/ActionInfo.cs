//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

    
namespace FFeat.Note.Model
{
    [Serializable]
    public partial class ActionInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ActionInfo()
        {
            this.RoleInfo = new HashSet<RoleInfo>();
            this.R_UsreInfo_ActionInfo = new HashSet<R_UsreInfo_ActionInfo>();
        }
    
        public int Id { get; set; }
        public string ActionName { get; set; }
        public string Url { get; set; }
        public System.DateTime SubTime { get; set; }
        public short DelFlag { get; set; }
        public string Remark { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RoleInfo> RoleInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<R_UsreInfo_ActionInfo> R_UsreInfo_ActionInfo { get; set; }
    }
}