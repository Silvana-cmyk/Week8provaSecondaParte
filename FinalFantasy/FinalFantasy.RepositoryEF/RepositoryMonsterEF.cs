using FinalFantasy.Core.Entities;
using FinalFantasy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.RepositoryEF
{
    public class RepositoryMonsterEF : IRepositoryMonster
    {
        public ICollection<Monster> GetAll()
        {
            ICollection<Monster> result;
            using (var ctx = new GameFFContext())
            {
                result = ctx.Monsters.ToList();
            }
            return result;
        }

        public Monster GetByID(int id)
        {
            using (var ctx = new GameFFContext())
            {
                return ctx.Monsters.Find(id);
            }
        }

        //ICollection<Monster> IRepository<Monster>.GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //Monster IRepositoryMonster.GetByID(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
