using Microsoft.EntityFrameworkCore;
using MvcCreditApp1.Models;
namespace MvcCreditApp1.Data
{
    public class CreditContext : DbContext
    {
        public CreditContext(DbContextOptions<CreditContext> options)
        : base(options)
        { }
        public DbSet<Credit> Credits { get; set; }
        public DbSet<Bid> Bids { get; set; }
    }
}
