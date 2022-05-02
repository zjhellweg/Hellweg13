using Microsoft.VisualStudio.TestTools.UnitTesting;
using Group_3_Week_11_DB_API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_3_Week_11_DB_API.Controllers.Tests
{
    [TestClass()]
    public class LoginTests
    {
        [TestMethod()]
        public void TestLength()
        {

            JwtAuthenticationManager manger = new JwtAuthenticationManager("testKeyDon'tUse23156");

            User RealUser = new User
            {
                Username = "test",
                Password = "Password"
            };

            var token2 = manger.Authenticate(RealUser.Username, RealUser.Password);

            Assert.IsTrue(token2.ToString().Length == 169);


        }

        [TestMethod()]
        public void LoginFailsAndSuccedesProperly()
        {
            JwtAuthenticationManager manger = new JwtAuthenticationManager("testKeyDon'tUse23156");

            User user = new User
            {
                Username = "TestUser",
                Password = "TestPassword"
            };

            User RealUser = new User
            {
                Username = "test",
                Password = "Password"
            };

            var token = manger.Authenticate(user.Username, user.Password);

            var token2 = manger.Authenticate(RealUser.Username, RealUser.Password);

            Assert.IsNull(token);

            Assert.IsNotNull(token2);
        }

        
    }
}