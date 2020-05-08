using System;

namespace DojoCGDF.Core.Domain.Entities
{
    public class Publicacao
    {
        public string Id { get; private set; }
        public string Descricao { get; private set; }
        public string Foto { get; private set; }
        public int Likes { get; private set; }
        public bool Ativo { get; private set; }

        public Publicacao(string descricao, string foto)
        {
            Id = Guid.NewGuid().ToString();
            Descricao = descricao;
            Foto = foto;
            Likes = 0;
            Ativo = true;
        }

        public void Atualizar(string descricao, string foto)
        {
            Descricao = descricao;
            Foto = foto;
        }

        public void Like()
        {
            Likes++;
        }

        public void Remover()
        {
            Ativo = false;
        }
    }
}
