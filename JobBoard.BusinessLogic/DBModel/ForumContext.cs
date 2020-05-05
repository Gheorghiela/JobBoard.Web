using System.Data.Entity;
using JobBoard.Domain.Entites.Topics;

namespace JobBoard.BusinessLogic.DBModel
{
    public class ForumContext : DbContext
    {
        public ForumContext() : base("name=eUseControl")
        {
        }

        public virtual DbSet<Forum> Forum { get; set; }
    }
}