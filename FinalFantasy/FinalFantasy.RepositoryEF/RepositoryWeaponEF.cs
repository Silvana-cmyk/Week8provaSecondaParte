using FinalFantasy.Core.Entities;
using FinalFantasy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.RepositoryEF
{
    public class RepositoryWeaponEF : IRepositoryWeapon
    {
        public ICollection<Weapon> GetAll()
        {
            ICollection<Weapon> result;
            using (var ctx = new GameFFContext())
            {
                result = ctx.Weapons.ToList();
            }
            return result;
        }

        public Weapon GetByID(int id)
        {
            using (var ctx = new GameFFContext())
            {
                return ctx.Weapons.Find(id);
            }
        }
    }
}
