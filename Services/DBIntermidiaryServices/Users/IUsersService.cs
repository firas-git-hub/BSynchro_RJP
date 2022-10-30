using BSynchro_RJP.Models.Entities;
using BSynchro_RJP.Models.Responses;

namespace BSynchro_RJP.Services.DBIntermidiaryServices.UsersIntermediaryService.UsersIntermediaryService
{
    public interface IUsersService
    {
        User? GetUser(int userId);
    }
}
