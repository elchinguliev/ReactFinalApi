using Microsoft.EntityFrameworkCore;
using ReactFinalApi.Models;

namespace ReactFinalApi
{
    public class BookDbContext:DbContext
    {
        public BookDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
                
        }
        public DbSet<Book> Books { get; set; }
    }
}
