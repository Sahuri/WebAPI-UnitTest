using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebAppMvc.Models;

namespace WebAppMvc.Core
{
    public class UserDao
    {
        const string FileUser = @"F:\users.json";
        public UserDao()
        {
            
        }

        public List<User> GetAll()
        {
            List<User> users;
            if (!File.Exists(FileUser))
            {
                var user = new User()
                {
                    Id = 1,
                    Account = "sahuri",
                    Name = "Sahuri Abqori",
                    Propesion = "Programmer",
                    Phone = "081299038999",
                    Email = "sahuri@hmail.com"
                };

                users = new List<User> { user };
                File.WriteAllText(FileUser, JsonConvert.SerializeObject(users));  
            }

            users =JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(FileUser));
            
            return users;
        }

        public bool Add(User user)
        {
            var users = GetAll();
            if (users.Any(u => u.Id == user.Id))
            {
                return false;
            }

            users.Add(user);
            File.WriteAllText(FileUser, JsonConvert.SerializeObject(users));
            return true;
        }

        public bool Delete(User user)
        {
            var users = GetAll();
            var u = users.SingleOrDefault(x => x.Id == user.Id);
            if (u != null)
            {
                users.Remove(u);
                File.WriteAllText(FileUser, JsonConvert.SerializeObject(users));
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool Update(User user)
        {
            var users = GetAll();
            var u = users.SingleOrDefault(x => x.Id == user.Id);
            if (u != null)
            {
                users.Remove(u);
                users.Add(user);
                File.WriteAllText(FileUser, JsonConvert.SerializeObject(users));
                return true;    
            }
            else
            {
                return false;
            }
            
        }

        public User GetById(User user)
        {
            var users = GetAll();
            var u = users.SingleOrDefault(x => x.Id == user.Id);
            return u;
        }
    }
}