using FinalFantasy.Core.Entities;
using FinalFantasy.RepositoryEF.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.RepositoryEF
{
    public class GameFFContext : DbContext
    {
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Weapon> Weapons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optBuilder)
        {
            optBuilder.UseSqlServer(@"Persist Security Info = False; Integrated Security = true; 
                                    Initial Catalog = GameFF; Server = .\SQLEXPRESS");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration<Hero>(new HeroConfiguration());
            modelBuilder.ApplyConfiguration<Level>(new LevelConfiguration());
            modelBuilder.ApplyConfiguration<Monster>(new MonsterConfiguration());
            modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
            modelBuilder.ApplyConfiguration<Weapon>(new WeaponConfiguration());
        }

    }
}
