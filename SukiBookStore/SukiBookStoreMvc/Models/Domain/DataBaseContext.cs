using Microsoft.EntityFrameworkCore;

namespace SukiBookStoreMvc.Models.Domain
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Publisher> Publisher { get; set; }

        public DbSet<Author> Author { get; set; }




    }
}
