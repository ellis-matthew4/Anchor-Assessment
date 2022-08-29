using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Anchor_Project.Controllers
{
    public class LoginController : ApiController
    {
        [HttpGet]
        // GET: Login
        public async Task<string> Login(string username, string password)
        {
            return "";
        }
    }
}