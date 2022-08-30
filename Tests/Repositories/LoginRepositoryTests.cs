using Anchor_Assessment.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anchor_Assessment.Tests.Repositories
{
    public class LoginRepositoryTests
    {
        [Test]
        public void LoginRepository_Login_success()
        {
            LoginRepository repo = new LoginRepository();
            Assert.DoesNotThrow(() => repo.getLoginToken("Username", "password"));
            Assert.Throws<ArgumentException>(() => repo.getLoginToken("NotUsername", "password"));
        }
    }
}
