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
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
        public ApplicationDbContext()
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Student>().HasKey(k => new { k.StudentId, k.Level });
            builder.Entity<Course>().HasKey(k => new { k.CourseId, k.CourseLevel });
            builder.Entity<StudentCourse>().HasKey(k => new { k.CourseId, k.CourseLevel, k.StudentId, k.Level });

         
            builder.Entity<IdentityRole>().ToTable("IdentityRole", "Securty");
            builder.Entity<IdentityUser>().ToTable("IdentityUser", "Securty");
            builder.Entity<IdentityUserRole<string>>().ToTable("IdentityUserRole", "Securty");
            builder.Entity<IdentityUserClaim<string>>().ToTable("IdentityUserClaim", "Securty");
            builder.Entity<IdentityUserLogin<string>>().ToTable("IdentityUserLogin", "Securty");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("IdentityRoleClaim", "Securty");
            builder.Entity<IdentityUserToken<string>>().ToTable("IdentityUserToken", "Securty");

            //builder.Entity<Student>().ToTable("Students", "Models");
           

           
        }

    }
}