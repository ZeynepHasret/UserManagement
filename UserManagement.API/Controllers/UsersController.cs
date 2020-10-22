using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.API.Fake;
using UserManagement.API.Models;

namespace UserManagement.API.Controllers
{
    /*
    [Route("Products")]
    public class ProductsController : ControllerBase
    {

        [Route("Merhaba")]
        public string Merhaba()
        {
              return "Merhaba";
        }
    } */

    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private List<Users> _users = FakeData.GetUsers(200);
        [HttpGet]
        public List<Users> Get()
        {
            return _users;
        }
        [HttpGet("{id}")]
        public Users Get2(int id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);
            return user;
        }
        [HttpPost]
        public Users Post([FromBody] Users users)
        {
            _users.Add(users);
            return users;
        }
        [HttpPut]
        public Users Put([FromBody] Users users)
        {
            var editedUser = _users.FirstOrDefault(x => x.Id == users.Id);
            editedUser.FirstName = users.FirstName;
            editedUser.LastName = users.LastName;
            editedUser.Address = users.Address;

            return users;
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var deleteuser = _users.FirstOrDefault(x => x.Id == id);
            _users.Remove(deleteuser);
        }
    }
}
