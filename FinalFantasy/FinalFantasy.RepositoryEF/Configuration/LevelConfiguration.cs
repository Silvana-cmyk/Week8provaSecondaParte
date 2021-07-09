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
    public class LevelConfiguration : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> modelBuilder)
        {
            modelBuilder.ToTable("Level");
            modelBuilder.HasKey(i => i.ID);
            modelBuilder.Property("Name").IsRequired();

            modelBuilder.HasData(
                new Level { ID = 1, Name = "Level 1" },
                new Level { ID = 2, Name = "Level 2" },
                new Level { ID = 3, Name = "Level 3" },
                new Level { ID = 4, Name = "Level 4" },
                new Level { ID = 5, Name = "Level 5" }
            );
        }

    }
}
