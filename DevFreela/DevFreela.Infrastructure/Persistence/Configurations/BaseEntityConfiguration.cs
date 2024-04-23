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
    public class BaseEntityConfiguration<TBase> : IEntityTypeConfiguration<TBase> where TBase : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TBase> builder)
        {
            builder.HasKey(p => p.Id);

            builder
                .Property(p => p.CreatedAt)
                .HasColumnType("DateTime")
                //.HasPrecision(0)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
