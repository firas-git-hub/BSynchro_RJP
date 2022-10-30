using BSynchro_RJP.Models.Entities;
using BSynchro_RJP.Models.Responses;

namespace BSynchro_RJP.Services.DBIntermidiaryServices.UserAccounts
{
    public interface IUserAccountsService
    {
        int? CreateAccountForUser(int userId);
        List<UserAccount> GetUserAccounts(int userId);
    }
}
