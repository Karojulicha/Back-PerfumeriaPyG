using Microsoft.EntityFrameworkCore;
using Perfumeria.Models;

namespace Perfumeria.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        public DbSet<User> Users {get; set;}
        public DbSet<Perfume> Perfumes {get; set;}
        
    }



}