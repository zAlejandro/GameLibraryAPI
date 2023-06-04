using gamelibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace gamelibraryAPI.Data
{
    public class gamesdbcontext : DbContext
    {
        public gamesdbcontext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<game> Games { get; set; }
    }
}
