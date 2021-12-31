using DatabaseExample.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseExample.Database
{
    public class StudentContext : DbContext
    {

        public DbSet<Student> Students { get; set; }
        /*public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Grade> Grades { get; set; }*/


        public StudentContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Path.Combine(Environment.CurrentDirectory, "students.db");
            optionsBuilder.UseSqlite($"Data Source = {path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
