using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Configurations
{
    public class UserSkillConfiguration : BaseEntityConfiguration<UserSkill>
    {
        public override void Configure(EntityTypeBuilder<UserSkill> builder)
        {
            base.Configure(builder);

            builder.ToTable("UserSkill");

            builder.Property(x => x.IdUser)
                .IsRequired();

            builder.Property(x => x.IdSkill)
                .IsRequired();        

            builder.HasIndex(x => new { x.IdUser, x.IdSkill })
                .IsUnique();

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.IdUser)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Skill>()
                .WithMany()
                .HasForeignKey(x => x.IdSkill)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
