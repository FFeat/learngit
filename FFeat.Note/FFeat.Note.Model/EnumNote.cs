using FFeat.Note.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFeat.Note.Model
{
    public class EnumNote
    {
        public enum DelFlagEnum
        {
            Normal = 0,
            Deleted = 1
        }
        public enum NoteTypeEnum
        {
            [SelectDisplayName("基础知识")]
            BasicKnow = 0,
            [SelectDisplayName("Winform知识")]
            Winform =1,
            [SelectDisplayName("Webform知识")]
            Webform =2,
            [SelectDisplayName("MVC知识")]
            Aspmvc =3
        }
    }
}
