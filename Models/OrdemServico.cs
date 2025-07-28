using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace paddockCcell.Models
{
    public class OrdemServico
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Servico")]
        public int Id_Servico { get; set; }

        [ForeignKey("Cliente")]
        public int Id_Cliente { get; set; }

        //novos campos
        public string? Observao { get; set; }

        // Pendente: Aberta, aguardando avaliação/orçamento.
        // Em Análise/Orçamento: Técnico avaliando o problema e levantando custos.
        // Aguardando Aprovação do Cliente: Orçamento pronto, esperando resposta.
        // Aprovado: Cliente autorizou o serviço.
        // Em Reparo: Serviço em execução.
        // Aguardando Peça: Reparo parado por falta de componente.
        // Concluído: Serviço finalizado, aguardando retirada.
        // Entregue: Aparelho retirado pelo cliente.
        // Cancelado/Não Aprovado: Cliente desistiu ou não aprovou o orçamento.
        // Sem Reparo: Não foi possível reparar o aparelho.
        public string? Status { get; set; }

    }
}