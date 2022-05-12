using EntitiyLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        public IEnumerable<object> students;

        public DbSet<Academician> Academicians { get; set; }
        public DbSet<AcademicianLecture> AcademicianLectures { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Inturn> Inturns { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<LectureSyllabus> LectureSyllabuses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentLecture> StudentLectures { get; set; }
        public DbSet<Syllabus> Syllabuses { get; set; }
        public DbSet<Personnel> Personnels{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            

            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.OneToManyCascadeDeleteConvention>();
            //modelBuilder.Entity<Department>()
            //    .HasMany(e => e.Students)
            //    .WithOptional()
            //    .WillCascadeOnDelete(true);

            //modelBuilder.Entity<Department>()
            //    .HasMany(e => e.Academicians)
            //    .WithOptional()
            //    .WillCascadeOnDelete(true);

            //modelBuilder.Entity<Department>()
            //     .HasMany(e => e.Lectures)
            //     .WithOptional()
            //     .WillCascadeOnDelete(false);


            //modelBuilder.Entity<Department>()
            //    .HasOne(s => s.Department)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);


            //modelBuilder.Entity<Department>()
            //    .HasOptional(s => s.Students)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Lecture>()
            //   .HasOptional(s => s.StudentLectures)
            //   .WithMany()
            //   .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Student>()
            //    .HasOptional(s => s.StudentLectures)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Syllabus>()
            //    .HasOptional(s => s.Academicians)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);


            //modelBuilder.Entity<Department>()
            //   .HasOptional(s => s.Lectures)
            //   .WithMany()
            //   .WillCascadeOnDelete(false);

        }
    }
}
