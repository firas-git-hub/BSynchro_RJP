using BSynchro_RJP.Models.Contexts;
using BSynchro_RJP.Models.Entities;
using BSynchro_RJP.Models.Responses;
using System.Net;

namespace BSynchro_RJP.Services.DBIntermidiaryServices.UserAccounts
{
    //this service might seem useless due to it's simplicity but it'll be useful when complex operations are needed to be done when creating a transaction
    public class UserAccountsService : IUserAccountsService
    {
        private readonly CustomersContext _context;

        public UserAccountsService(CustomersContext context)
        {
            _context = context;
        }
        public int? CreateAccountForUser(int userId)
        {
            try
            {
                User? userRequestingAccount = _context.Users.Find(userId);
                if (userRequestingAccount != null)
                {
                    UserAccount newAccount = new UserAccount()
                    {
                        UserId = userId,
                        Balance = 0
                    };
                    _context.UsersAccounts.Add(newAccount);
                    _context.SaveChanges();
                    return newAccount.Id;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<UserAccount> GetUserAccounts(int userId)
        {
            try
            {
                List<UserAccount>? userAccountsToReturn = _context.UsersAccounts.Where(x => x.UserId == userId).ToList();
                return userAccountsToReturn.Count == 0 ? new List<UserAccount>() : userAccountsToReturn;
            }
            catch (Exception)
            {
                return new List<UserAccount>();
            }
        }
    }
}
