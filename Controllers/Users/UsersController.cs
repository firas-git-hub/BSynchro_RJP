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

        [HttpGet]
        public ActionResult<UserInfo> GetUser([FromHeader] int userId)
        {
            try
            {
                UserInfo? userInfoToGet = _customersContextService.GetUserInfo(userId);
                return userInfoToGet == null ? NotFound() : Ok(userInfoToGet);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "error GetUser " + ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
