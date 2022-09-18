using EasyNotes.WebHost.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyNotes.Data.Configurations
{
    public class AppUserConfiguration: IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("Users");
            builder.Property(x => x.FirstName).HasMaxLength(255).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(255).IsRequired();
        }    
    }
}
