using DojoCGDF.Core.Domain.DTO;
using DojoCGDF.Core.Domain.Services;
using DojoCGDF.Core.Infrastructure;
using DojoCGDF.Core.Infrastructure.Config.Seeds;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DojoCGDF.Api.Controllers
{
    [Route("publicacoes")]
    public class PublicacaoController : ControllerBase
    {
        private readonly DojoCGDFDbContext _context;
        private readonly IPublicacaoService _publicacaoService;

        public PublicacaoController(
            DojoCGDFDbContext context,
            IPublicacaoService publicacaoService)
        {
            _context = context;
            _publicacaoService = publicacaoService;
        }

        [HttpGet("listar-todas")]
        public IActionResult ListarTodasPublicacoes()
        {
            var publicacoes = _context.Publicacoes
                .ToList();
            return Ok(publicacoes);
        }

        [HttpGet("listar-ativas")]
        public IActionResult ListarPublicacoesAtivas()
        {
            var publicacoes = _context.Publicacoes
                .Select(x => x.Ativo)
                .ToList();
            return Ok(publicacoes);
        }

        [HttpGet("recuperar")]
        public IActionResult RecuperarPublicacao(string id)
        {
            var publicacao = _context.Publicacoes
                .Select(x => x.Id == id)
                .SingleOrDefault();

            return Ok(publicacao);
        }

        [HttpPost("adicionar")]
        public IActionResult AdicionarPublicacao(PublicacaoDTO publicacaoDTO)
        {
            _publicacaoService.AdicionarPublicacao(publicacaoDTO);
            return Ok();
        }

        [HttpPut("atualizar")]
        public IActionResult AtualizarPublicacao(PublicacaoDTO publicacaoDTO)
        {
            _publicacaoService.AtualizarPublicacao(publicacaoDTO);
            return Ok();
        }

        [HttpDelete("remover")]
        public IActionResult RemoverPublicacao(string id)
        {
            _publicacaoService.RemoverPublicacao(id);
            return Ok();
        }

        [HttpPost("like")]
        public IActionResult LikePublicacao(string id)
        {
            _publicacaoService.LikePublicacao(id);
            return Ok();
        }

        [HttpGet("limpar-dados")]
        public IActionResult LimparDados()
        {
            _publicacaoService.LimparDados();
            return Ok();
        }
    }
}
