using Microsoft.EntityFrameworkCore;
using PeginationCrudDemo.Models.Domian;

namespace PeginationCrudDemo.Data
{
    public class PDemoDbContext : DbContext
    {
        public PDemoDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
