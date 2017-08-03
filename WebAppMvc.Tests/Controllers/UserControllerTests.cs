using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebAppMvc.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace WebAppMvc.Tests.Controllers
{
    [TestClass()]
    public class UserControllerTests
    {
        const string FileUser = @"users.json";
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
