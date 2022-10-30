using BSynchro_RJP.Controllers.Users;
using Microsoft.AspNetCore.Mvc;

namespace BSynchro_RJP.Controllers.Accounts
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountsController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;

        public AccountsController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }
    }
}
