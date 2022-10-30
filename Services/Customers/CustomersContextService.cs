using BSynchro_RJP.Models.Entities;
using BSynchro_RJP.Services.DBIntermidiaryServices.AccountTransactions;
using BSynchro_RJP.Services.DBIntermidiaryServices.UserAccounts;
using BSynchro_RJP.Services.DBIntermidiaryServices.UsersIntermediaryService.UsersIntermediaryService;

namespace BSynchro_RJP.Services.Customers
{
    public class CustomersContextService : ICustomersContextService
    {
        private readonly IUsersService _usersService;
        private readonly IUserAccountsService _userAccountsService;
        private readonly IAccountTransactionsService _accountTransactionsService;
        public CustomersContextService(IUsersService usersService, IUserAccountsService userAccountsService, IAccountTransactionsService accountTransactionsService)
        {
            _usersService = usersService;
            _userAccountsService = userAccountsService;
            _accountTransactionsService = accountTransactionsService;
        }
        public void AddUserAccount(int userId, double initialCredit)
        {
            try
            {
                int? newAccountId = _userAccountsService.CreateAccountForUser(userId);
                if (newAccountId != null && initialCredit > 0)
                {
                    _accountTransactionsService.CreateTransaction((int)newAccountId, initialCredit);
                }
                return;
            }
            catch (Exception)
            {
                return;
            }
        }

        public UserInfo? GetUserInfo(int userId)
        {
            try
            {
                return PrepareUserInfoData(userId);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private UserInfo? PrepareUserInfoData(int userId)
        {
            try
            {
                User? userToFind = _usersService.GetUser(userId);
                if (userToFind == null)
                    return null;
                List<UserAccount> userAccountsToFind = _userAccountsService.GetUserAccounts(userId);
                List<int> accountsIdsList = userAccountsToFind.Select(x => x.Id).ToList();
                return new UserInfo()
                {
                    Name = userToFind.Name,
                    Surname = userToFind.Surname,
                    TotalBalance = userAccountsToFind.Sum(x => x.Balance),
                    AccountList = userAccountsToFind
                };
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
