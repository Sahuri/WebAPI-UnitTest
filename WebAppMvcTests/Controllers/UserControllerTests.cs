using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using WebAppMvc.Controllers;

namespace WebAppMvcTests.Controllers
{
    [TestClass()]
    public class UserControllerTests
    {
        const string FileUser = @"F:\users.json";
        [TestMethod()]
        public void GetAllTest()
        {
            var obj = new UserController();
            var res = JsonConvert.SerializeObject(obj.GetAll());
            var users = File.ReadAllText(FileUser);
            Assert.AreEqual(users, res);
        }
    }
}
