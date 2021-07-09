using FinalFantasy.Core.Entities;
using FinalFantasy.RepositoryMock;
using System;

namespace FinalFantasy
{
    class Program
    {
        //public static RepositoryUserMock repoUserM = new RepositoryUserMock();
        //public static RepositoryWeaponMock repoWeaponM = new RepositoryWeaponMock();
        //public static RepositoryHeroMock repoHeroM = new RepositoryHeroMock();
        static void Main(string[] args)
        {
            bool continua = true;
            while (continua)
            {
                continua = Gaming.MenuIniziale();
            }

        }


    }
}
