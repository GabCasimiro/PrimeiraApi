using Colaboradores.Models;
using Microsoft.EntityFrameworkCore;

namespace Colaboradores.Data
{
    public class ConnectDbContext : DbContext
    {
        public ConnectDbContext(DbContextOptions<ConnectDbContext> options)
            : base(options)
        {
        }

        public DbSet<ColaboradoresModel> ColaboradoresDataBase { get; set; }
            
    }
}
