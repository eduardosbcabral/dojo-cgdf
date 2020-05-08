using DojoCGDF.Core.Domain.DTO;
using DojoCGDF.Core.Domain.Entities;
using DojoCGDF.Core.Infrastructure;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace DojoCGDF.Core.Domain.Services
{
    public class PublicacaoService : IPublicacaoService
    {
        private readonly DojoCGDFDbContext _context;
        private readonly IHostEnvironment _hostEnvironment;

        public PublicacaoService(
            DojoCGDFDbContext context,
            IHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public void AdicionarPublicacao(PublicacaoDTO publicacaoDTO)
        {
            var fileName = Path.GetRandomFileName() + ".png";
            var uploadPath = Path.Combine(_hostEnvironment.ContentRootPath, "Uploads");
            var filePath = Path.Combine(uploadPath, fileName);

            publicacaoDTO.Foto.CopyTo(
                new FileStream(filePath, FileMode.Create));

            var publicacao = new Publicacao(publicacaoDTO.Descricao, fileName);

            _context.Publicacoes.Add(publicacao);
            _context.SaveChanges();
        }

        public void AtualizarPublicacao(PublicacaoDTO publicacaoDTO)
        {
            var fileName = Path.GetRandomFileName() + ".png";
            var uploadPath = Path.Combine(_hostEnvironment.ContentRootPath, "Uploads");
            var filePath = Path.Combine(uploadPath, fileName);

            publicacaoDTO.Foto.CopyTo(
                new FileStream(filePath, FileMode.Create));

            var publicacao = _context.Publicacoes.Find(publicacaoDTO.Id);

            // Removendo foto antiga para ser atualizada pela nova
            File.Delete(Path.Combine(uploadPath, publicacao.Foto));

            publicacao.Atualizar(publicacao.Descricao, fileName);

            _context.Publicacoes.Add(publicacao);
            _context.SaveChanges();
        }

        public void RemoverPublicacao(string id)
        {
            var publicacao = _context.Publicacoes.Find(id);
            publicacao.Remover();
            _context.Publicacoes.Update(publicacao);
            _context.SaveChanges();
        }

        public void LikePublicacao(string id)
        {
            var publicacao = _context.Publicacoes.Find(id);
            publicacao.Like();
            _context.Publicacoes.Update(publicacao);
            _context.SaveChanges();
        }
    }
}
