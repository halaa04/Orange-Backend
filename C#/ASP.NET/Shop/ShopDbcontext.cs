using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop
{
    public class ShopDbcontext : DbContext 
    {
        public ShopDbcontext(DbContextOptions<ShopDbcontext>options) : base(options) 
        {
        }
        //migrations :
        // table 1 > user 
        public DbSet<user> users { get; set; }
    }
    
}
