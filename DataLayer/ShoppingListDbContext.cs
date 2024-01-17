using Microsoft.EntityFrameworkCore;
using Paskaita14.Models;

namespace Paskaita14.DataLayer
{
    public class ShoppingListDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<ShoppingListItem> ShoppingListItems { get; set; }


        public ShoppingListDbContext(DbContextOptions<ShoppingListDbContext> options) : base(options)
        {

        }
    }
}
