using BSynchro_RJP.Models.Entities;
using BSynchro_RJP.Services.ContextsModelRelations;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace BSynchro_RJP.Models.Contexts
{
    public class CustomersContext : DbContext
    {
        public CustomersContext(DbContextOptions<CustomersContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAccount> UsersAccounts { get; set; }
        public DbSet<AccountTransaction> AccountsTransactions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CustomersContextDataRelations.DefineRelationForCustomersContext(modelBuilder);
        }
    }
}
