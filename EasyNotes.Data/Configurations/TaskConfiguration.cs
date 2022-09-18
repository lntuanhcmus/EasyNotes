using EasyNotes.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyNotes.Data.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<ToDoTask>
    {
        public void Configure(EntityTypeBuilder<ToDoTask> builder)
        {
            builder.ToTable("ToDoTask");
            builder.Property(x => x.Title).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(255);
            builder.HasKey(x => x.TaskId);
        }
    }
}
