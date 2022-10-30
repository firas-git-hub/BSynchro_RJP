using BSynchro_RJP.Controllers.Users;
using BSynchro_RJP.Interface.Customers;
using BSynchro_RJP.Interface.DBIntermidiaryServices.AccountTransactions;
using BSynchro_RJP.Interface.DBIntermidiaryServices.UserAccounts;
using BSynchro_RJP.Interface.DBIntermidiaryServices.Users;
using BSynchro_RJP.Models.Entities;

namespace BSynchro_RJP.Services.Customers
{
    public class CustomersContextService : ICustomersContextService
    {
        private readonly ILogger<CustomersContextService> _logger;
        private readonly IUsersService _usersService;
        private readonly IUserAccountsService _userAccountsService;
        private readonly IAccountTransactionsService _accountTransactionsService;
        public CustomersContextService(
            IUsersService usersService,
            IUserAccountsService userAccountsService,
            IAccountTransactionsService accountTransactionsService,
            ILogger<CustomersContextService> logger)
        {
            _usersService = usersService;
            _userAccountsService = userAccountsService;
            _accountTransactionsService = accountTransactionsService;
            _logger = logger;
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
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "error AddUserAccount: " + ex.Message);
                return;
            }
        }

        public UserInfo? GetUserInfo(int userId)
        {
            try
            {
                return PrepareUserInfoData(userId);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "error GetUserInfo: " + ex.Message);
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
                return new UserInfo()
                {
                    Name = userToFind.Name,
                    Surname = userToFind.Surname,
                    TotalBalance = userAccountsToFind.Sum(x => x.Balance),
                    AccountList = userAccountsToFind
                };
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "error PrepareUserInfoData: " + ex.Message);
                return null;
            }
        }
    }
}
