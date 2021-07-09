using FinalFantasy.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.RepositoryEF.Configuration
{
    public class MonsterConfiguration : IEntityTypeConfiguration<Monster>
    {
        public void Configure(EntityTypeBuilder<Monster> modelBuilder)
        {
            modelBuilder.ToTable("Monster");
            modelBuilder.HasKey(i => i.ID);
            modelBuilder.Property("Name").IsRequired();
            modelBuilder.Property("Type").IsRequired();
            modelBuilder.Property("Life").IsRequired();
            modelBuilder.HasOne(x => x.Weapon).WithMany(y => y.Monsters)
                .HasForeignKey(x => x.WeaponID);
            modelBuilder.HasOne(x => x.Level).WithMany(y => y.Monsters)
                .HasForeignKey(x => x.LevelID);

            modelBuilder.HasData(
                new Monster { ID = 1, Name = "Fantasma1", Type = "Ghost", Life = 20, LevelID = 1, WeaponID = 1 },
                new Monster { ID = 2, Name = "Fantasma2", Type = "Ghost", Life = 40, LevelID = 2, WeaponID = 2 },
                new Monster { ID = 3, Name = "Lucifer1", Type = "Lucifer", Life = 100, LevelID = 5, WeaponID = 1 },
                new Monster { ID = 4, Name = "Lucifer2", Type = "Lucifer", Life = 60, LevelID = 3, WeaponID = 2 },
                new Monster { ID = 5, Name = "Lucifer3", Type = "Lucifer", Life = 80, LevelID = 4, WeaponID = 3 },
                new Monster { ID = 6, Name = "Lucifer4", Type = "Lucifer", Life = 100, LevelID = 5, WeaponID = 4 }
        );
        }

    }
}
