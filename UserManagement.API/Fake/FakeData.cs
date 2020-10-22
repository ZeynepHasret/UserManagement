using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.API.Models;

namespace UserManagement.API.Fake
{
    public static class FakeData
    {
        private static List<Users> _users;
        public static List<Users> GetUsers(int number)
        {
            if (_users==null) // her refreshte yeni ürün üretmemesi için bu koşulu oluşturduk.
            {
                _users = new Faker<Users>()  //bogus yapısı
                          .RuleFor(u => u.Id, f => f.IndexFaker + 1)
                          .RuleFor(u => u.FirstName,f=> f.Name.FirstName())
                          .RuleFor(u => u.LastName, f => f.Name.LastName())
                          .RuleFor(u => u.Address, f => f.Address.City())
                          .Generate(number);
               
            }
            return _users;
        }
    }
}
