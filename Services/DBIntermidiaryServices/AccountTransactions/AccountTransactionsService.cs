using BSynchro_RJP.Models.Contexts;
using BSynchro_RJP.Models.Entities;
using BSynchro_RJP.Services.Customers;

namespace BSynchro_RJP.Services.DBIntermidiaryServices.AccountTransactions
{
    public class AccountTransactionsService : IAccountTransactionsService
    {
        private readonly CustomersContext _context;

        public AccountTransactionsService(CustomersContext context)
        {
            _context = context;
        }

        public int? CreateTransaction(int accountId, double amount)
        {
            try
            {
                AccountTransaction transaction = new AccountTransaction()
                {
                    AccountId = accountId,
                    Amount = amount
                };
                _context.AccountsTransactions.Add(transaction);
                TransferAmountToAccount(accountId, amount);
                return transaction.Id;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private bool TransferAmountToAccount(int accountId, double amount)
        {
            try
            {
                UserAccount? accountToTransferTo = _context.UsersAccounts.Find(accountId);
                if (accountToTransferTo == null)
                    return false;
                accountToTransferTo.Balance += amount;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<AccountTransaction> GetAccountTransactions(List<int> accountIds)
        {
            try
            {
                List<AccountTransaction>? accountsTransactionsToGet = _context.AccountsTransactions.Where(x => accountIds.Contains(x.AccountId)).ToList();
                return accountsTransactionsToGet == null ? new List<AccountTransaction>() : accountsTransactionsToGet;
            }
            catch (Exception)
            {
                return new List<AccountTransaction>();
            }
        }
    }
}
