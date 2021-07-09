using FinalFantasy.Core.Entities;
using FinalFantasy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.RepositoryEF
{
    public class RepositoryLevelEF : IRepositoryLevel
    {
        public ICollection<Level> GetAll()
        {
            ICollection<Level> result;
            using (var ctx = new GameFFContext())
            {
                result = ctx.Levels.ToList();
            }
            return result;
        }

        public Level GetByID(int id)
        {
            using (var ctx = new GameFFContext())
            {
                return ctx.Levels.Find(id);
            }
        }
    }
}
