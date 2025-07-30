using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;


namespace paddockCcell.Models
{
    public class OrdemServico
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataHoraAbertura { get; set; } = DateTime.Now;

        [ForeignKey("Servico")]
        public int Id_Servico { get; set; }

        [ForeignKey("Cliente")]
        public int Id_Cliente { get; set; }

        //novos campos
        public string? DadosEquipamento { get; set; }
        // Tipo de equipamento (celular, tablet,
        // notebook, etc.), marca, modelo, número de série(IMEI para
        // celulares), cor, estado de conservação(com avarias, riscos,
        // trincado, etc., com campo para observações detalhadas e fotos).
        // Senha do dispositivo

        public string? DescricaoProblema { get; set; }
        //Campo de texto livre para o cliente descrever o defeito.

        public string? Status { get; set; }
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
        

    }
}