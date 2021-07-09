using FinalFantasy.Core.Entities;
using FinalFantasy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.RepositoryMock
{
    public class RepositoryUserMock : IRepositoryUser
    {
        private ICollection<User> users = new List<User>();

        public bool Add(User user)
        {
            if (user != null)
            {
                users.Add(user);
                return true;
            }
            else
            {
                return false;
            }
        }

        public ICollection<User> GetAll()
        {
            return users;
        }

        public User GetByID(string id)
        {
            return GetAll().FirstOrDefault(x => x.Nickname == id);
        }
    }
}
