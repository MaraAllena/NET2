using System;
using WebShop.Logic;
using Xunit;

namespace WebShop.Test
{
    public class UserTests
    {
        [Fact]
        public void TestCreateUser()
        {

            string mail = GetRandomText();
            UserManager.Create(mail, "testname", "testpass");

            var user = UserManager.GetByEmail(mail);

            //ja asertacija ir pareiza -> tests veiksm�gs
            Assert.NotNull(user);
            Assert.Equal(user.Email, mail);

        }

        public void TestGetUser()
        {
            string mail = GetRandomText();
            string password = "testpass";
            UserManager.Create(mail, "testname", password);

            var user = UserManager.GetByEmailAndPassword(mail, password);
            Assert.NotNull(user);
            Assert.Equal(user.Email, mail);
            Assert.Equal(user.Password, password);
        }

        public static string GetRandomText()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 8);
        }
    }
}
