using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccessLayer
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions options) : base(options)
        { }

        public virtual DbSet<Task> Tasks { get; set; }
    }
}
