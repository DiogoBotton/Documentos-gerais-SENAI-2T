using System;
using System.Collections.Generic;

namespace Senai.InLock.WebApi.DatabaseFirst.Domains
{
    public partial class Jogos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataLancamento { get; set; }
        public decimal? Valor { get; set; }
        public int? EstudioId { get; set; }

        public Estudios Estudio { get; set; }

        public void AlterarInformacoes(string nome, string descricao, DateTime? dataLancamento, decimal? valor, int? estudioId)
        {
            Nome = nome;
            Descricao = descricao;
            DataLancamento = dataLancamento;
            Valor = valor;
            EstudioId = estudioId;
        }
    }
}
