using DojoCGDF.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DojoCGDF.Core.Infrastructure.Config.Maps
{
    public class PublicacaoMap : IEntityTypeConfiguration<Publicacao>
    {
        public void Configure(EntityTypeBuilder<Publicacao> builder)
        {
            builder.ToTable("TB_PUBLICACOES");
            builder.HasKey(x => x.Id);
        }
    }
}
