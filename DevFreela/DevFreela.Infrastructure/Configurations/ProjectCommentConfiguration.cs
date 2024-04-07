using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Configurations
{
    internal class ProjectCommentConfiguration: BaseEntityConfiguration<ProjectComment>
    {
        public override void Configure(EntityTypeBuilder<ProjectComment> builder)
        {
            base.Configure(builder);

            builder.ToTable("ProjectComment");

            builder.Property(x => x.Content)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasOne<Project>()
                .WithMany()
                .HasForeignKey(p => p.IdProject)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.IdUser)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
