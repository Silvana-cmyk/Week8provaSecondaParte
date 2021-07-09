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
    public class HeroConfiguration : IEntityTypeConfiguration<Hero>
    {
        public void Configure(EntityTypeBuilder<Hero> modelBuilder)
        {
            modelBuilder.ToTable("Hero");
            modelBuilder.HasKey(i => i.ID);
            modelBuilder.Property("Name").IsRequired();
            modelBuilder.Property("Type").IsRequired();
            modelBuilder.Property("Life").IsRequired();
            modelBuilder.Property("Score").IsRequired();
            modelBuilder.HasOne(x => x.User).WithMany(y => y.Heroes)
            .HasForeignKey(x => x.UserID);
            modelBuilder.HasOne(x => x.Weapon).WithMany(y => y.Heroes)
                .HasForeignKey(x => x.WeaponID);
            modelBuilder.HasOne(x => x.Level).WithMany(y => y.Heroes)
                .HasForeignKey(x => x.LevelID);
        }
    }
}
