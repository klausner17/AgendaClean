using System.Data.Entity;

namespace AgendaClean.Models
{
    public class AgendaContext : DbContext
    {

        public DbSet<ContactModel> Contacts { get; set; }
        public DbSet<UserModel> Users { get; set; }

        public AgendaContext() : base("AgendaDb")
        {

        }
    }
}