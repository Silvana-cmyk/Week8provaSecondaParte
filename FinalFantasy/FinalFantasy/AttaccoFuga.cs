using FinalFantasy.Core.Entities;
using FinalFantasy.RepositoryMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy
{
    public class AttaccoFuga
    {
        public static RepositoryWeaponMock repoWeaponM = new RepositoryWeaponMock();
        public static int Attacco(Hero hero, Monster monster)
        {
            if (hero.Type.Equals("Soldier"))
            {
                Weapon w = repoWeaponM.GetByID(hero.WeaponID);
                Console.WriteLine("Vita mostro: " + w.Damage);
                monster.Life = monster.Life - w.Damage;
            }
            return monster.Life;
            
        }

        public static int Fuga()
        {
            Random RandomClass = new Random();
            int random = RandomClass.Next(0, 3);
            return random;
        }

        public static void AttaccoMostro(Hero hero, Monster monster)
        {
            Weapon w = repoWeaponM.GetByID(monster.WeaponID);
            hero.Life = hero.Life - w.Damage;
        }

    }
}
