using DojoCGDF.Core.Domain.Entities;
using DojoCGDF.Core.Infrastructure.Config.Maps;
using Microsoft.EntityFrameworkCore;

namespace DojoCGDF.Core.Infrastructure
{
    public class DojoCGDFDbContext : DbContext
    {
        public DbSet<Publicacao> Publicacoes { get; set; }

        public DojoCGDFDbContext(DbContextOptions<DojoCGDFDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PublicacaoMap());
        }
    }
}
