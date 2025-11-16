using System;

namespace WebAPI_Empresas.Domain.ValueObjects
{
    public class Simples
    {
        public bool Optante { get; private set; }
        public DateTime? DataOpcao { get; private set; }
        public DateTime? DataExclusao { get; private set; }
        public DateTime? UltimaAtualizacao { get; private set; }

        protected Simples() { }

        public Simples(bool optante, DateTime? dataOpcao, DateTime? dataExclusao, DateTime? ultimaAtualizacao)
        {
            Optante = optante;
            DataOpcao = dataOpcao;
            DataExclusao = dataExclusao;
            UltimaAtualizacao = ultimaAtualizacao;
        }
    }
}
