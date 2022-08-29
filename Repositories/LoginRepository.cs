using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anchor_Assessment.Repositories
{
    public class LoginRepository:ILoginRepository
    {
        public string getLoginToken(string username, string password)
        {
            // In an normal web API, I would call AWS or whatever cloud provider here to get a real JWT token or whatever auth we're using, but I'm just going to fake it here
            if (username == "Username" && password == "password")
                return "sample_login_token";
            throw new ArgumentException("Incorrect login credentials.");
        }
    }
}
