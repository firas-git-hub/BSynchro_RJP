using BSynchro_RJP.Controllers.Users.Models;
using BSynchro_RJP.Interface.Customers;
using BSynchro_RJP.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BSynchro_RJP.Controllers.Users
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly ICustomersContextService _customersContextService;

        public UsersController(ILogger<UsersController> logger, ICustomersContextService customersContextService)
        {
            _logger = logger;
            _customersContextService = customersContextService;
        }

        [HttpPost]
        public IActionResult CreateNewAccountForUser([FromBody] CreateNewAccountModel data)
        {
            try
            {
                _customersContextService.AddUserAccount(data.UserId, data.InitialCredit);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "error CreateNewAccountForUser " + ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id?}")]
        public ActionResult<UserInfo> GetUser(int id)
        {
            try
            {
                UserInfo? userInfoToGet = _customersContextService.GetUserInfo(id);
                return userInfoToGet == null ? NotFound() : Ok(userInfoToGet);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "error GetUser " + ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<User>> GetAllUsers()
        {
            try
            {
                List<User>? users = _customersContextService.GetAllUsers();
                return users == null ? NotFound() : Ok(users);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "error GetAllUsers " + ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<User> CreateUser([FromBody] CreateNewUserModel newUser)
        {
            try
            {
                int? newUserId = _customersContextService.CreateNewUser(newUser);
                return newUserId == null ? BadRequest() : Ok(newUserId);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "error CreateUser " + ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
