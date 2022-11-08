using BSynchro_RJP.Controllers.Users.Models;
using BSynchro_RJP.Models.Entities;

namespace BSynchro_RJP.Interface.Customers
{
    public interface ICustomersContextService
    {
        void AddUserAccount(int userId, double initialCredit);
        UserInfo? GetUserInfo(int userId);
        List<User>? GetAllUsers();
        int? CreateNewUser(CreateNewUserModel newUser);
    }
}
