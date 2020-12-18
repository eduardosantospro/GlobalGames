using GlobalGamesCet49.Dados.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GlobalGamesCet49.Dados
{
    public class DataContext : DbContext
    {
        public DbSet<PedidoDeContacto> PedidosDeContacto { get; set; }
        public DbSet<Inscricao> Inscricoes { get; set; }

        /*
         * options é o nome que quiseremos da variavel
         * 
         * O meu DataContext vai usar as opções do DataContext dele que estão na base (DbContext) 
         * Este processo chama-se HERANÇA porque o objecto herda todas as funcionalidades do DbContext da Entity Framework Core
         */
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        /*
         * options é o nome que quiseremos da variavel
         * 
         * O meu DataContext vai usar as opções do DataContext dele que estão na base (DbContext) 
         * Este processo chama-se HERANÇA porque o objecto herda todas as funcionalidades do DbContext da Entity Framework Core
         */
        /* public DbSet<GlobalGamesCet49.Dados.Entidades.Inscricao> Inscricao { get; set; } */
    }
}
