using FinalFantasy.Core.Entities;
using FinalFantasy.RepositoryMock;
using System;
using Xunit;

namespace FinalFantasy.TestProject
{
    public class UnitTest1
    {
        public static RepositoryUserMock repoUserM = new RepositoryUserMock();
        public static RepositoryHeroMock repoHeroM = new RepositoryHeroMock();
        public static RepositoryMonsterMock repoMonsterM = new RepositoryMonsterMock();
        
        [Fact]
        public void Test1()
        {
            User user = new User() { Nickname = "UserProva" };
            repoUserM.Add(user);

            Hero hero = new Hero() { ID = 34, Name ="prova", LevelID =1,
            WeaponID = 1, UserID= "UserProva", Type="Soldato", Score =0, Life =20
            };
            repoHeroM.Add(hero);
            Monster monster = repoMonsterM.GetByID(1);
            monster.Life = 20;

            Assert.Equal(20, AttaccoFuga.Attacco(hero, monster));
        }
    }
}
