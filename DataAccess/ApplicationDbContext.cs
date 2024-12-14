using Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Emit;
namespace DataAccess
{
    public class ApplicationDbContext :IdentityDbContext<IdentityUser>
    {
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentPhone> StudentPhones { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MemberPhone> MemberPhones { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Lectures> Lectures { get; set; }
        public DbSet<Sections> Sections { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
        public ApplicationDbContext()
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<Student>().HasKey(k => new { k.StudentId, k.Level });
            //builder.Entity<Course>().HasKey(k => new { k.CourseId, k.CourseLevel });
            //builder.Entity<StudentCourse>().HasKey(k => new { k.CourseId, k.CourseLevel, k.StudentId, k.Level });

         
            builder.Entity<IdentityRole>().ToTable("IdentityRole", "Securty");
            builder.Entity<IdentityUser>().ToTable("IdentityUser", "Securty");
            builder.Entity<IdentityUserRole<string>>().ToTable("IdentityUserRole", "Securty");
            builder.Entity<IdentityUserClaim<string>>().ToTable("IdentityUserClaim", "Securty");
            builder.Entity<IdentityUserLogin<string>>().ToTable("IdentityUserLogin", "Securty");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("IdentityRoleClaim", "Securty");
            builder.Entity<IdentityUserToken<string>>().ToTable("IdentityUserToken", "Securty");

            //builder.Entity<Student>().ToTable("Students", "Models");

            builder.Entity<Course>().HasOne(c => c.Member).WithMany(m => m.Courses).HasForeignKey(c => c.MemberId).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<StudentCourse>().HasOne(s => s.Student).WithMany(sc => sc.StudentCourses).HasForeignKey(c => c.StudentId).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<StudentCourse>().HasOne(s => s.Course).WithMany(sc => sc.StudentCourses).HasForeignKey(c => c.CourseId).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Sections>().HasOne(s => s.Course).WithMany(c => c.Sections).HasForeignKey(s => new { s.CourseId }).HasConstraintName("FK_Sections_Course");

            builder.Entity<Lectures>().HasOne(l => l.Course).WithMany(c => c.Lectures).HasForeignKey(l => new { l.CourseId }).OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<StudentPhone>()
            //.Property(c => c.StudentPhoneId)
            //.ValueGeneratedOnAdd();


            //builder.Entity<MemberPhone>()
            //.Property(c => c.MemberPhoneId)
            //.ValueGeneratedOnAdd();

        }

    }
}