using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BookStore.Model
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public BookContext(DbContextOptions options) : base(options){}
    }

}
