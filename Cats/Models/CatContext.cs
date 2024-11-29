using Microsoft.EntityFrameworkCore;

namespace Cats.Models
{
    public class CatContext: DbContext
    {
        public CatContext(DbContextOptions<CatContext> options)
        : base(options)
        {
        }

        public DbSet<Cat> Cats { get; set; } = null!;
    }
}
