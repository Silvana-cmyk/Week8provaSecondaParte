using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.Core.Entities
{
    public class Monster
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Life { get; set; }
        public Level Level { get; set; }
        public int LevelID { get; set; }
        public Weapon Weapon { get; set; }
        public int WeaponID { get; set; }
    }
}
