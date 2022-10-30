using BSynchro_RJP.Models.Entities;

namespace BSynchro_RJP.Services.DBIntermidiaryServices.AccountTransactions
{
    public interface IAccountTransactionsService
    {
        int? CreateTransaction(int accountId, double amount);
        List<AccountTransaction> GetAccountTransactions(List<int> accountIds);
    }
}
