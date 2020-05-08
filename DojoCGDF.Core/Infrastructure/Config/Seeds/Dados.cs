using DojoCGDF.Core.Domain.Entities;

namespace DojoCGDF.Core.Infrastructure.Config.Seeds
{
    public static class Dados
    {
        public static void Adicionar(DojoCGDFDbContext context)
        {
            var publicacao1 = new Publicacao("Publicação 1", "foto1.png");
            context.Publicacoes.Add(publicacao1);

            var publicacao2 = new Publicacao("Publicação 2", "foto2.png");
            context.Publicacoes.Add(publicacao2);

            var publicacao3 = new Publicacao("Publicação 3", "foto3.png");
            context.Publicacoes.Add(publicacao3);

            context.SaveChanges();
        }
    }
}
