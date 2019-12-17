using EmployeeManagement.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Data.Configuration
{
    public class AuditConfiguration : IEntityTypeConfiguration<Audit>
    {
        public void Configure(EntityTypeBuilder<Audit> builder)
        {
            builder.ToTable("Audit");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.TableName).HasMaxLength(100);            
            builder.Property(x => x.DateTime).IsRequired();
            builder.Property(x => x.KeyValues).IsRequired().HasMaxLength(200);
            builder.Property(x => x.OldValues).HasMaxLength(500);
            builder.Property(x => x.NewValues).HasMaxLength(500);
        }
    }
}
