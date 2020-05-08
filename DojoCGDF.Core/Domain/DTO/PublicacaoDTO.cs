using Microsoft.AspNetCore.Http;

namespace DojoCGDF.Core.Domain.DTO
{
    public class PublicacaoDTO
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public IFormFile Foto { get; set; }
    }
}
