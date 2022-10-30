using BSynchro_RJP.Controllers.Users.Models;
using BSynchro_RJP.Models.Entities;
using BSynchro_RJP.Services.Customers;
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
        public IActionResult CreateNewAccountForUser([FromBody] CreateNewAccountData data)
        {
            _customersContextService.AddUserAccount(data.UserId, data.InitialCredit);
            return Ok();
        }

        [HttpGet]
        public ActionResult<UserInfo> GetUser([FromHeader] int userId)
        {
            UserInfo? userInfoToGet = _customersContextService.GetUserInfo(userId);
            return userInfoToGet == null ?  NotFound() : Ok(userInfoToGet);
        }
    }
}
