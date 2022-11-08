using BSynchro_RJP.Interface.DBIntermidiaryServices.Users;
using BSynchro_RJP.Models.Contexts;
using BSynchro_RJP.Models.Entities;
using BSynchro_RJP.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BSynchro_RJP.Services.DBIntermidiaryServices.Users
{
    public class UsersService : IUsersService
    {
        private readonly ILogger<UsersService> _logger;
        private readonly CustomersContext _context;

        public UsersService(CustomersContext context, ILogger<UsersService> logger)
        {
            _context = context;
            _logger = logger;
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
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "error GetUser: " + ex.Message);
                return null;
            }
        }

        public List<User>? GetAllUsers()
        {
            try
            {
                List<User>? users = _context.Users.ToList();
                if(users != null)
                {
                    return users;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "error GetAllUsers: " + ex.Message);
                return null;
            }
        }

        public int? CreateNewUser(User newUser)
        {
            try
            {
                _context.Users.Add(newUser);
                _context.SaveChanges();
                return newUser.Id;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "error CreateNewUser: " + ex.Message);
                return null;
            }
        }
    }
}
