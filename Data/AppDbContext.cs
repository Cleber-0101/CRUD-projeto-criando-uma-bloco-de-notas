using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WordProjetoView.Models;

namespace WordProjetoView.Data
{
    //meio de campo entre api eo banco de dados 
    public class AppDbContext : DbContext
    {

        //construtor injetar a string de conexão
        public AppDbContext(DbContextOptions<AppDbContext> options) :  base(options)
        {           
        }

        public DbSet<Documento> Documentos { get; set; }    

    }
}
