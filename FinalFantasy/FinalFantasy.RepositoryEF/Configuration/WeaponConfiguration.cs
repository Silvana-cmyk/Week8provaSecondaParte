﻿using FinalFantasy.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.RepositoryEF.Configuration
{
    public class WeaponConfiguration : IEntityTypeConfiguration<Weapon>
    {
        public void Configure(EntityTypeBuilder<Weapon> modelBuilder)
        {
            modelBuilder.ToTable("Weapon");
            modelBuilder.HasKey(i => i.ID);
            modelBuilder.Property("Name").IsRequired();

            modelBuilder.HasData(
                new Weapon { ID = 1, Name = Name.ASCIA },
                new Weapon { ID = 2, Name = Name.MAZZA },
                new Weapon { ID = 3, Name = Name.SPADA },
                new Weapon { ID = 4, Name = Name.ARCO_FRECCE },
                new Weapon { ID = 5, Name = Name.BACCHETTA },
                new Weapon { ID = 6, Name = Name.BASTONE_MAGICO },
                new Weapon { ID = 7, Name = Name.ARCO },
                new Weapon { ID = 8, Name = Name.CLAVA },
                new Weapon { ID = 9, Name = Name.DIVINAZIONE },
                new Weapon { ID = 10, Name = Name.FULMINE },
                new Weapon { ID = 11, Name = Name.TEMPESTA },
                new Weapon { ID = 12, Name = Name.TEMPESTA_OSCURA }
            );
        }
    }
}
