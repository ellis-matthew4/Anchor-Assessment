using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Anchor_Assessment.Services;

namespace Anchor_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService ?? throw new ArgumentNullException(nameof(LoginService));
        }

        [HttpGet]
        // GET: Login
        public string Login(string username, string password)
        {
            return _loginService.getLoginToken(username, password);
        }
    }
}