using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anchor_Assessment.Repositories
{
    public interface ILoginRepository
    {
        public string getLoginToken(string username, string password);
    }
}
