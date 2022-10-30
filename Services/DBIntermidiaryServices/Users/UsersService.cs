using BSynchro_RJP.Models.Contexts;
using BSynchro_RJP.Models.Entities;
using BSynchro_RJP.Models.Responses;
using BSynchro_RJP.Services.DBIntermidiaryServices.UsersIntermediaryService.UsersIntermediaryService;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BSynchro_RJP.Services.DBIntermidiaryServices.Users
{
    public class UsersService : IUsersService
    {

        private readonly CustomersContext _context;

        public UsersService(CustomersContext context)
        {
            _context = context;
        }

        public User? GetUser(int userId)
        {
            try
            {
                User? userToFind = _context.Users.Find(userId);
                if (userToFind != null)
                {
                    return userToFind;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
