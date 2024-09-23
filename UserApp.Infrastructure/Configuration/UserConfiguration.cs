using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApp.Domain.Users;

namespace UserApp.Infrastructure.Configuration
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.FirstNames).HasMaxLength(50).IsRequired().HasConversion(a => a.value , value => new FirstName(value));
            builder.Property(t => t.FirstLastNames).HasMaxLength(50).IsRequired().HasConversion(a => a.value, value => new FirstLastname(value));
            builder.Property(t => t.SecondNames).HasMaxLength(50).IsRequired(false).HasConversion(a => a.value, value => new SecondName(value));
            builder.Property(t => t.SecondLastNames).HasMaxLength(50).IsRequired(false).HasConversion(a => a.value, value => new SecondLastname(value));
            builder.Property(t => t.Birthdays).IsRequired().HasConversion(a => a.value, value => new Birthday(value));
            builder.Property(t => t.Salarys).IsRequired().HasConversion(a => a.value, value => new Salary(value));
            builder.Property(t => t.CreateDates).IsRequired().HasConversion(a => a.value, value => new CreateDate(value));
            builder.Property(t => t.ModifiedDates).IsRequired(false).HasConversion(a => a.value, value => new ModifiedDate(value));
        }
    }
}
