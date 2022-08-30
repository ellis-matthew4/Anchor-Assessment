using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anchor_Assessment.Repositories;

namespace Anchor_Assessment.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository ?? throw new ArgumentNullException(nameof(LoginRepository));
        }

        public string getLoginToken(string username, string password)
        {
            return _loginRepository.getLoginToken(username, password);
        }
    }
}
