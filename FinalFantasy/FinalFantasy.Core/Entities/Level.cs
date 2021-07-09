using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.Core.Entities
{
    public class Level
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public ICollection<Hero> Heroes { get; set; } = new List<Hero>();
        public ICollection<Monster> Monsters { get; set; } = new List<Monster>();

    }
}
