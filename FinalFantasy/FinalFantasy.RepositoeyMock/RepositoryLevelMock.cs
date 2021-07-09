using FinalFantasy.Core.Entities;
using FinalFantasy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.RepositoryMock
{
    public class RepositoryLevelMock : IRepositoryLevel
    {
        private ICollection<Level> levels = new List<Level>()
        {
            new Level{ID = 1, Name = "Level 1" },
            new Level{ID = 2, Name = "Level 2" },
            new Level{ID = 3, Name = "Level 3" },
            new Level{ID = 4, Name = "Level 4" },
            new Level{ID = 5, Name = "Level 5" },
        };
        public ICollection<Level> GetAll()
        {
            return levels;
        }

        public Level GetByID(int id)
        {
            return GetAll().FirstOrDefault(x => x.ID == id);
        }
    }
}
