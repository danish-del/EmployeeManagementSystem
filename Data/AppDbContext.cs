using EmployeeManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EmployeeManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            public DbSet<Employee> Employees { get; set; }
            public DbSet<User> Users { get; set; }
        }

    }
