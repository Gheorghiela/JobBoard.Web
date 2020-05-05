using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.BusinessLogic.DBModel
{
    class SessionContext: DbContext
    {
        public SessionContext() : base("name=JobBoardDB")
        {

        }

        public virtual DbSet<SessionBL> Sessions { get; set; }
    }
}
