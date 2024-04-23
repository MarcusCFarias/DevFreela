using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Configurations
{
    public class ProjectConfiguration : BaseEntityConfiguration<Project>
    {
        public override void Configure(EntityTypeBuilder<Project> builder)
        {
            base.Configure(builder);

            builder.ToTable("Project");

            builder.Property(x => x.Title)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(255)
                .IsRequired();

            // como fazer essa propriedade virar uma foreign key?
            builder.Property(x => x.Status)
                //.HasConversion<int>()
                .IsRequired();

            builder.Property(x => x.TotalCost)
                .HasPrecision(10, 2)
                .IsRequired();

            builder.Property(x => x.StartedAt)
                .HasColumnType("DATETIME")
                .IsRequired(false);

            builder.Property(x => x.FinishedAt)
                .HasColumnType("DATETIME")
                .IsRequired(false);

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.IdClient)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.IdFreelancer)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
