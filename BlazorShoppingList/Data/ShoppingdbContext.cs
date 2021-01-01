using BlazorShoppingList.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShoppingList.Data
{
    public class ShoppingdbContext : DbContext
    {
        public DbSet<user_> user_ { get; set; }
        public DbSet<shopping_list> shopping_list { get; set; }
        public DbSet<auth_token> auth_token { get; set; }
        public DbSet<item> item { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=POSTGRESQL;Database=DBNAME;Username=postgres;Password=PASSWORD;Persist Security Info=True");
    }
}
