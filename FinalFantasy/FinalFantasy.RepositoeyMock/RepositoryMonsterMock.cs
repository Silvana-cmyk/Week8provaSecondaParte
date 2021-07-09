using FinalFantasy.Core.Entities;
using FinalFantasy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.RepositoryMock
{
    public class RepositoryMonsterMock : IRepositoryMonster
    {
        private ICollection<Monster> monsters = new List<Monster>()
        {
            new Monster{ID = 1, Name = "Fantasma1", Type = "Ghost", Life = 20, LevelID = 1, WeaponID = 1},
            new Monster{ID = 2, Name = "Fantasma2", Type = "Ghost", Life = 40, LevelID = 2, WeaponID = 2},
            new Monster{ID = 3, Name = "Lucifer1", Type = "Lucifer", Life = 100, LevelID = 5, WeaponID = 1},
            new Monster{ID = 4, Name = "Lucifer2", Type = "Lucifer", Life = 60, LevelID = 3, WeaponID = 2},
            new Monster{ID = 5, Name = "Lucifer3", Type = "Lucifer", Life = 80, LevelID = 4, WeaponID = 3},
            new Monster{ID = 6, Name = "Lucifer4", Type = "Lucifer", Life = 100, LevelID = 5, WeaponID = 4},
        };
        public ICollection<Monster> GetAll()
        {
            return monsters;
        }

        public Monster GetByID(int id)
        {
            return GetAll().FirstOrDefault(x => x.ID == id);
        }
    }
}
