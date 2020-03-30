using System.Data.Entity;
using JobBoard.Domain.Entities.User;

namespace JobBoard.BusinessLogic.DBModel
{
    class UserContext : DbContext
    {
        public UserContext():
            base("name=eUseControl") //connectionstring name define in your web.confib
        {

        }

        public virtual DbSet<UDbTable> Users { get; set; }
    }
}
