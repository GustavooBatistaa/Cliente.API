using System;

namespace Domain.Entities
{
    public class Ocorrencia
    {
        public int Id { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public string Descricao { get; set; }
        public int ResponsavelAberturaId { get; set; }
        public Cliente ResponsavelAbertura { get; set; }

        public int ResponsavelOcorrenciaId { get; set; }
        public Cliente ResponsavelOcorrencia { get; set; }

        public string Conclusao { get; set; }

        public bool IsAberturaCompleta => DataAbertura != default && DataOcorrencia != default && !string.IsNullOrEmpty(Descricao);
        public bool IsIdentificacaoCompleta => ResponsavelAbertura != null && ResponsavelOcorrencia != null;
    }
}
