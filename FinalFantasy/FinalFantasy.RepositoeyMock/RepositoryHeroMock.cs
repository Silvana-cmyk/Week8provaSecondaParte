using FinalFantasy.Core.Entities;
using FinalFantasy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.RepositoryMock
{
    public class RepositoryHeroMock : IRepositoryHero
    {
        private ICollection<Hero> heroes = new List<Hero>();

        public bool Add(Hero hero)
        {
            if (hero != null)
            {
                heroes.Add(hero);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ChangeLevel(Hero hero)
        {
            RepositoryLevelMock repoLevelM = new RepositoryLevelMock();
            Level level;
            try
            {
                if (hero.Score >= 0 && hero.Score <= 29)
                {
                    level = repoLevelM.GetByID(1);
                }else if (hero.Score >=30 && hero.Score <= 59)
                {
                    level = repoLevelM.GetByID(2);
                }
                else if (hero.Score >= 60 && hero.Score <= 89)
                {
                    level = repoLevelM.GetByID(3);
                }
                else if (hero.Score >= 90 && hero.Score <= 119)
                {
                    level = repoLevelM.GetByID(4);
                } else
                {
                    level = repoLevelM.GetByID(5);
                }
                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Delete(Hero hero)
        {
            if (hero != null)
            {
                heroes.Remove(hero);
                return true;
            }
            else
            {
                return false;
            }
        }

        public ICollection<Hero> GetAll()
        {
            return heroes;
        }

        public Hero GetByID(int id)
        {
            return GetAll().FirstOrDefault(x=> x.ID == id);
        }
    }
}
