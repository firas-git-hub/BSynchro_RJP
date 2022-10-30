using BSynchro_RJP.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace BSynchro_RJP.Services.ContextsModelRelations
{
    public static class CustomersContextDataRelations
    {
        //this class can be used to define the relationships between objects manually.
        public static void DefineRelationForCustomersContext(ModelBuilder modelBuilder)
        {
            DefineRelationsForUsers(modelBuilder);
            DefineRelationsForAccountTransactions(modelBuilder);
            DefineRelationsForUserAccounts(modelBuilder);
        }

        private static void DefineRelationsForUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<User>()
                .HasMany(x => x.Accounts)
                .WithOne();
        }
        private static void DefineRelationsForUserAccounts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountTransaction>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<AccountTransaction>()
                .HasOne<UserAccount>()
                .WithMany()
                .HasForeignKey(x => x.AccountId);
        }
        private static void DefineRelationsForAccountTransactions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<UserAccount>()
                .HasMany(x => x.Transactions)
                .WithOne();
            modelBuilder.Entity<UserAccount>()
                .HasOne<User>()
                .WithMany(x => x.Accounts)
                .HasForeignKey(x => x.UserId);
        }
    }
}
