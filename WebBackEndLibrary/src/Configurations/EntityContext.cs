using Microsoft.EntityFrameworkCore;
using WebBackEndLibrary.Models;

namespace WebBackEndLibrary.Configurations
{
    public class EntityContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCourse> BookCourses { get; set; }

        public EntityContext(DbContextOptions options) : base(options)
        {

        }
        public void Traceable(ModelBuilder builder, Type type)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedStatus(modelBuilder);
          
        }

        private void SeedStatus(ModelBuilder modelBuilder)
        {
            
        }
    }
}