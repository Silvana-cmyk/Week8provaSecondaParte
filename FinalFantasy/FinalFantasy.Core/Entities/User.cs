using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.Core.Entities
{
    public class User
    {
        public string Nickname { get; set; }
        public ICollection<Hero> Heroes { get; set; } = new List<Hero>();
    }
}
