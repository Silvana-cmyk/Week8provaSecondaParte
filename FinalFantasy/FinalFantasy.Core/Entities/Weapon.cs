using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.Core.Entities
{
    public enum Name
    {
        ASCIA,
        MAZZA,
        SPADA,
        ARCO_FRECCE,
        BACCHETTA,
        BASTONE_MAGICO,
        ARCO,
        CLAVA,
        DIVINAZIONE,
        FULMINE,
        TEMPESTA,
        TEMPESTA_OSCURA
    }

    public class Weapon
    {
        public const int asciaDamage = 8;
        public const int mazzaDamage = 5;
        public const int spadaDamage = 10;
        public const int arcoFrecceDamage = 8;
        public const int bacchettaDamage = 5;
        public const int bastoneMagicoDamage = 10;
        public const int arcoDamage = 7;
        public const int clavaDamage = 5;
        public const int divinazioneDamage = 15;
        public const int fulmineDamage = 10;
        public const int tempestaDamage = 8;
        public const int tempestaOscuraDamage = 15;

        public int ID { get; set; }
        public Name Name { get; set; }
        public int Damage { get { return DamageCalculation(); } }
        public ICollection<Hero> Heroes { get; set; } = new List<Hero>();
        public ICollection<Monster> Monsters { get; set; } = new List<Monster>();
        private int DamageCalculation()
        {
            int danno = 0;
            switch (Name)
            {
                case Name.ASCIA:
                    danno = asciaDamage;
                    break;
                case Name.SPADA:
                    danno = spadaDamage;
                    break;
                case Name.MAZZA:
                    danno = mazzaDamage;
                    break;
                case Name.ARCO_FRECCE:
                    danno = arcoFrecceDamage;
                    break;
                case Name.BACCHETTA:
                    danno = bacchettaDamage;
                    break;
                case Name.BASTONE_MAGICO:
                    danno = bastoneMagicoDamage;
                    break;
                case Name.ARCO:
                    danno = arcoDamage;
                    break;
                case Name.CLAVA:
                    danno = clavaDamage;
                    break;
                case Name.DIVINAZIONE:
                    danno = divinazioneDamage;
                    break;
                case Name.FULMINE:
                    danno = fulmineDamage;
                    break;
                case Name.TEMPESTA:
                    danno = tempestaDamage;
                    break;
                case Name.TEMPESTA_OSCURA:
                    danno = tempestaOscuraDamage;
                    break;
                default:
                    danno = 0;
                    break;
            }
            return danno;
        }
    }
}
