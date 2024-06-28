
public record Contrato(int Id, int ClienteId, decimal PrecoCobrado, DateTime DataContratacao)
{
    private global::System.Int32 servicoId;

    public int ServicoId { get => servicoId; set => servicoId = value; }
}
