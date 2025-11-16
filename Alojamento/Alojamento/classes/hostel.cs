/// <summary>
/// Representa um Hostel no sistema de gestão de alojamentos.
/// Herda da classe Alojamento e adiciona propriedades específicas
/// deste tipo de alojamento, como o número de camas disponíveis
/// e se o pequeno-almoço está incluído.
/// </summary>
public class Hostel : Alojamento
{
    // Número total de camas disponíveis no hostel.
    // A capacidade só pode ser alterada através dos métodos públicos.
    public int NumeroCamas { get; private set; }

    // Indica se o hostel oferece pequeno-almoço incluído na estadia.
    public bool IncluiPequenoAlmoco { get; private set; }

    // Especifica o tipo de alojamento.
    // Este valor é fixo para a classe Hostel.
    public override string Tipo => "Hostel";

    /// <summary>
    /// Construtor da classe Hostel.
    /// Inicializa todos os atributos específicos deste tipo de alojamento
    /// e utiliza o construtor base para definir as informações comuns.
    /// </summary>
    /// <param name="id">Identificador único do hostel.</param>
    /// <param name="morada">Morada completa do hostel.</param>
    /// <param name="proprietario">Nome do proprietário.</param>
    /// <param name="numeroCamas">Número total de camas disponíveis.</param>
    /// <param name="incluiPequenoAlmoco">Indica se o hostel oferece pequeno-almoço.</param>
    public Hostel(int id, string morada, string proprietario,
                  int numeroCamas, bool incluiPequenoAlmoco)
        : base(id, morada, proprietario)
    {
        NumeroCamas = numeroCamas;
        IncluiPequenoAlmoco = incluiPequenoAlmoco;
    }

    // ---------------------------------------------------------
    // MÉTODOS DE ALTERAÇÃO DE ATRIBUTOS ESPECÍFICOS DO HOSTEL
    // ---------------------------------------------------------

    /// <summary>
    /// Altera o número total de camas disponíveis no hostel.
    /// Garante que o novo número é válido (mínimo de 1).
    /// </summary>
    /// <param name="novoNumero">Novo número de camas.</param>
    public void AlterarNumeroCamas(int novoNumero)
    {
        if (novoNumero <= 0)
            throw new ArgumentException("O hostel deve ter pelo menos 1 cama.");

        NumeroCamas = novoNumero;
    }

    /// <summary>
    /// Ativa a opção de pequeno-almoço incluído.
    /// </summary>
    public void AtivarPequenoAlmoco()
    {
        IncluiPequenoAlmoco = true;
    }

    /// <summary>
    /// Desativa a opção de pequeno-almoço incluído.
    /// </summary>
    public void DesativarPequenoAlmoco()
    {
        IncluiPequenoAlmoco = false;
    }
}
