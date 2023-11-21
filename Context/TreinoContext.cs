using ControleExercicios.Model;
using Microsoft.EntityFrameworkCore;

namespace ControleExercicios.Context
{
    public class TreinoContext : DbContext
    {
        public TreinoContext(DbContextOptions<TreinoContext> options) : base(options)
        {

        }

        public DbSet<Treino> Treinos { get; set; }
    }
}