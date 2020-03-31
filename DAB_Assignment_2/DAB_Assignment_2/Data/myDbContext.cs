using System;
using System.Collections.Generic;
using System.Text;
using DAB_Assignment_2.Models;
using Microsoft.EntityFrameworkCore;

namespace DAB_Assignment_2.Data
{
    class myDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=Nics-PC;Initial Catalog=DAB_Assignment_2;Integrated Security=True");
        }

        public DbSet<Attends> Attends { get; set; } //many to many between Student and Course
        public DbSet<RequestHelpAssignments> RequestHelpAssignments { get; set; } // many to many between Student and Assignments

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //student
            modelBuilder.Entity<Student>().HasKey(a => new {a.StudentAUid});
            modelBuilder.Entity<Student>() //One to many with Exercises
                .HasMany<Exercise>(c => c.Exercises)
                .WithOne(po => po.student)
                .HasForeignKey(po => po.StudentAUid);

            //Course
            modelBuilder.Entity<Course>().HasKey(b => new {b.courseId});
            modelBuilder.Entity<Course>() //One to many with Exercise
                .HasMany<Exercise>(b => b.Exercises)
                .WithOne(c => c.Course)
                .HasForeignKey(c => c.courseId);
            modelBuilder.Entity<Course>() //one to many with Assignments
                .HasMany<Assignment>(b => b.Assignments)
                .WithOne(f => f.Course)
                .HasForeignKey(f => f.courseId);
            modelBuilder.Entity<Course>() //one to many with Teachers
                .HasMany<Teacher>(b => b.Teachers)
                .WithOne(d => d.Course)
                .HasForeignKey(d => d.courseId);

            //Exercise
            modelBuilder.Entity<Exercise>().HasKey(c => new {c.lecture, c.number});

            //Teacher
            modelBuilder.Entity<Teacher>().HasKey(d => new {d.TeacherAUid});
            //modelBuilder.Entity<Teacher>() //one to many with Assignments 
                // NOT DONE! FINISH IT! 
                

            //Assignment
            modelBuilder.Entity<Assignment>().HasKey(f => new {f.lecture,f.number});
         
            //RequestHelpAssignments
            modelBuilder.Entity<RequestHelpAssignments>().HasKey(rha => rha.RequestHelpAssignmentID);
            // many to many between Student and Assignments
            modelBuilder.Entity<RequestHelpAssignments>()
                .HasOne(rha => rha.Student)
                .WithMany(a => a.RequestHelpAssignments)
                .HasForeignKey(rha => new {rha.StudentId});
            modelBuilder.Entity<RequestHelpAssignments>()
                .HasOne(rha => rha.Assignment)
                .WithMany(f => f.RequestHelpAssignmentses)
                .HasForeignKey(rha => new {rha.AssignmentLecture, rha.AssignmentNumber});

            //Attends
            modelBuilder.Entity<Attends>().HasKey(at => at.Semester);
            //many to many between Student and Course
            modelBuilder.Entity<Attends>()
                .HasOne(sc => sc.Student) // many to many
                .WithMany(a => a.Attends)
                .HasForeignKey(sc => new {sc.StudentId});
            modelBuilder.Entity<Attends>()
                .HasOne(sc => sc.Course) // many to many
                .WithMany(b => b.Attends)
                .HasForeignKey(sc => new {sc.CourseId});
        }
    }
}
