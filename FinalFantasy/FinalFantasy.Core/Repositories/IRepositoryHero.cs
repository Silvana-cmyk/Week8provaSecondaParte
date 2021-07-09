using FinalFantasy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.Core.Repositories
{
    public interface IRepositoryHero : IRepository<Hero>
    {
        public bool Add(Hero hero);
        public bool Delete(Hero hero);
        public Hero GetByID(int id);
        public bool ChangeLevel(Hero hero);
    }
}
