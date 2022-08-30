using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anchor_Assessment.Repositories;

namespace Anchor_Assessment.Services
{
    public interface ILoginService
    {
        public string getLoginToken(string username, string password);
    }
}
