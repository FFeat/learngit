using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using FFeat.Note.Model;

namespace FFeat.Note.Factory
{
    public class DbContextFactory
    {
        public static DbContext GetCurrentDbContext()
        {
            DbContext db = CallContext.GetData("DbContext") as DbContext;
            if (db == null)
            {
                db = new NoteModelContainer();
                CallContext.SetData("DbContext",db);
            }
            return db;
            
        }

      
    }
}
