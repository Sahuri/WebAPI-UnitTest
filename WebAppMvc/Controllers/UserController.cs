using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppMvc.Models;
using WebAppMvc.Core;

namespace WebAppMvc.Controllers
{
    public class UserController : ApiController
    {
        private readonly UserDao _dao=new UserDao();
        [HttpGet]
        public List<User> GetAll()
        {
            var res = _dao.GetAll();
            return res;
        } 
    }
}
