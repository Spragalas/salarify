using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Salarify.DataLayer.Models;

namespace Salarify.DataLayer
    {
    public class SalarifyContext: DbContext
        {
        public SalarifyContext (DbContextOptions<SalarifyContext> options) : base(options)
            {
            }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
            {
            
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Manager>().ToTable("Manager");
            modelBuilder.Entity<BaseSalary>().ToTable("BaseSalary");
            }

        public DbSet<Employee> Employees
            {
            get; set;
            }
        public DbSet<Manager> Managers
            {
            get; set;
            }
        public DbSet<BaseSalary> BaseSalaries
            {
            get; set;
            }
        }
    }
