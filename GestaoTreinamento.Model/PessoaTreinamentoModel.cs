using System;

namespace GestaoTreinamento.Model
{
    public class PessoaTreinamentoModel : ModelBase
    {
        public long Pessoa { get; set; }
        public long Treinamento { get; set; }
        public long Sala { get; set; }
        public long Espaco { get; set; }
    }
}
