using Exercicio2.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercicio2.Utils
{
    public class DbHelper: DbContext
    {
        public DbSet<Cavalos> Cavalos { get; set; }
        public DbSet<Utilizadores> Utilizadores { get; set; }
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(
                "Data Source=coudelaria_dwm.db");
        }
    }
}
