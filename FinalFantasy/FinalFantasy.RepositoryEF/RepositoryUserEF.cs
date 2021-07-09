using FinalFantasy.Core.Entities;
using FinalFantasy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.RepositoryEF
{
    public class RepositoryUserEF : IRepositoryUser
    {
        public bool Add(User user)
        {
            using (var ctx = new GameFFContext())
            {
                ctx.Users.Add(user);
                ctx.SaveChanges();
            }
            return true;
        }

        public ICollection<User> GetAll()
        {
            ICollection<User> result;
            using (var ctx = new GameFFContext())
            {
                result = ctx.Users.ToList();
            }
            return result;
        }

        public User GetByID(string id)
        {
            using (var ctx = new GameFFContext())
            {
                if (id == null || id.Length == 0)
                {
                    return null;
                }
                return ctx.Users.Find(id);
            }
        }
    }
}
