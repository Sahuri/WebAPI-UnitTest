using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using WebAppMvc.Core;
using WebAppMvc.Models;

namespace WebAppMvc.Tests.Core
{
    [TestClass()]
    public class UserDaoTests
    {

        const string FileUser = @"F:\users.json";
        [TestMethod()]
        public void GetAllTest()
        {
            var obj = new UserDao();
            var res = JsonConvert.SerializeObject(obj.GetAll());
            var users = File.ReadAllText(FileUser);
            Assert.AreEqual(users, res);

        }
        
        [TestMethod()]
        public void AddTest()
        {
            var obj = new UserDao();
            var user = new User()
            {
                Id = 2,
                Account = "yogi",
                Name = "yogi",
                Propesion = "Programmer",
                Phone = "081299038999",
                Email = "yogi@hmail.com"
            };

            var res = obj.Add(user);
            Assert.AreEqual(true,res);

            

        }

        [TestMethod()]
        public void DeleteTest()
        {
            var user = new User()
            {
                Id = 2,
                Account = "yogi",
                Name = "yogi",
                Propesion = "Programmer",
                Phone = "081299038999",
                Email = "yogi@hmail.com"
            };

            var obj = new UserDao();
            var res=obj.Delete(user);
            Assert.AreEqual(true, res);

        }

        [TestMethod()]
        public void UpdateTest()
        {
            var user = new User()
            {
                Id = 2,
                Account = "Yogi",
                Name = "Yogi R",
                Propesion = "Programmer",
                Phone = "081299038999",
                Email = "yogi@hmail.com"
            };


            var obj = new UserDao();
            var res = obj.Update(user);
            Assert.AreEqual(true, res);
        }
    }
}


