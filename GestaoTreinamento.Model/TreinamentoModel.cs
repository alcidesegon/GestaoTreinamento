using System;

namespace GestaoTreinamento.Model
{
    public class TreinamentoModel : ModelBase
    {
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public SituacaoEnum Situacao { get; set; }
    }
    
}
