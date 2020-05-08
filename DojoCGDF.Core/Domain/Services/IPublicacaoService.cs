using DojoCGDF.Core.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DojoCGDF.Core.Domain.Services
{
    public interface IPublicacaoService
    {
        void AdicionarPublicacao(PublicacaoDTO publicacaoDTO);
        void AtualizarPublicacao(PublicacaoDTO publicacaoDTO);
        void RemoverPublicacao(string id);
        void LikePublicacao(string id);
    }
}
