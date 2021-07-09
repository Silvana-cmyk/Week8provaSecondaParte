using FinalFantasy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.Core.Repositories
{
    public interface IRepositoryUser : IRepository<User>
    {
        public bool Add(User user);

        public User GetByID(string id);

    }
}
