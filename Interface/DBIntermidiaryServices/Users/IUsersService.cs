using BSynchro_RJP.Models.Entities;
using BSynchro_RJP.Models.Responses;

namespace BSynchro_RJP.Interface.DBIntermidiaryServices.Users
{
    public interface IUsersService
    {
        User? GetUser(int userId);
    }
}
