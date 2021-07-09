using FinalFantasy.Core.Entities;
using FinalFantasy.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.RepositoryEF
{
    public class RepositoryHeroEF : IRepositoryHero
    {
        public bool Add(Hero hero)
        {
            using (var ctx = new GameFFContext())
            {
                ctx.Heroes.Add(hero);
                ctx.SaveChanges();
            }
            return true;
        }

        public Hero ChangeLevel(int numero , int levelid, int life)
        {
            Hero heroToUpdateDb = null;
            using (var ctx = new GameFFContext())
            {
                if (numero != 0)
                {
                    heroToUpdateDb = ctx.Heroes.Find(numero);
                }
            }

            using (var ctx = new GameFFContext())
            {
                if (heroToUpdateDb != null)
                {
                    try
                    {
                        heroToUpdateDb.LevelID = levelid;
                        heroToUpdateDb.Score = 0;
                        heroToUpdateDb.Life = life;
                        ctx.Entry<Hero>(heroToUpdateDb).State = EntityState.Modified;
                        ctx.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }

                }
            }
            return heroToUpdateDb;
        }

        public bool ChangeLevel(Hero hero)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Hero hero)
        {
            using (var ctx = new GameFFContext())
            {
                ctx.Heroes.Remove(hero);
                ctx.SaveChanges();
            }
            return true;
        }

        public ICollection<Hero> GetAll()
        {
            ICollection<Hero> result;
            using (var ctx = new GameFFContext())
            {
                result = ctx.Heroes.ToList();
            }
            return result;
        }

        public Hero GetByID(int id)
        {
            using (var ctx = new GameFFContext())
            {
                return ctx.Heroes.Find(id);
            }
        }
    }
}
