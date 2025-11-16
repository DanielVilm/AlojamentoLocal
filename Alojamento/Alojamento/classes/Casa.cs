/// <summary>
/// Representa uma Casa no sistema de gestão de alojamentos.
/// Esta classe herda de Alojamento e acrescenta características
/// específicas como número de quartos, jardim e piscina.
/// </summary>
public class Casa : Alojamento
{
    // Número total de quartos da casa.
    // Só pode ser alterado pelos métodos providenciados.
    public int NumeroQuartos { get; private set; }

    // Indica se a casa possui jardim.
    public bool TemJardim { get; private set; }

    // Indica se a casa possui piscina.
    public bool TemPiscina { get; private set; }

    // Tipo de alojamento, definido pela classe derivada.
    public override string Tipo => "Casa";

    /// <summary>
    /// Construtor da Casa. Inicializa as propriedades específicas deste tipo de alojamento
    /// e invoca o construtor da classe base para os atributos comuns.
    /// </summary>
    /// <param name="id">Identificador único da casa.</param>
    /// <param name="morada">Morada completa da casa.</param>
    /// <param name="proprietario">Nome do proprietário.</param>
    /// <param name="numeroQuartos">Número total de quartos existentes.</param>
    /// <param name="temJardim">Indica se possui jardim.</param>
    /// <param name="temPiscina">Indica se possui piscina.</param>
    public Casa(int id, string morada, string proprietario,
                int numeroQuartos, bool temJardim, bool temPiscina)
        : base(id, morada, proprietario)
    {
        NumeroQuartos = numeroQuartos;
        TemJardim = temJardim;
        TemPiscina = temPiscina;
    }

    // ---------------------------------------------------------
    // MÉTODOS DE ALTERAÇÃO DAS CARACTERÍSTICAS DA CASA
    // ---------------------------------------------------------

    /// <summary>
    /// Altera o número total de quartos disponíveis na casa.
    /// Garante que o novo número é válido (mínimo de 1 quarto).
    /// </summary>
    /// <param name="novoNumero">Novo número de quartos.</param>
    public void AlterarNumeroQuartos(int novoNumero)
    {
        if (novoNumero <= 0)
            throw new ArgumentException("O número de quartos deve ser pelo menos 1.");

        NumeroQuartos = novoNumero;
    }

    /// <summary>
    /// Ativa o atributo que indica que a casa possui jardim.
    /// </summary>
    public void AtivarJardim()
    {
        TemJardim = true;
    }

    /// <summary>
    /// Desativa o atributo que indica a existência de jardim.
    /// </summary>
    public void DesativarJardim()
    {
        TemJardim = false;
    }

    /// <summary>
    /// Ativa o atributo que indica que a casa possui piscina.
    /// </summary>
    public void AtivarPiscina()
    {
        TemPiscina = true;
    }

    /// <summary>
    /// Desativa o atributo que indica a existência de piscina.
    /// </summary>
    public void DesativarPiscina()
    {
        TemPiscina = false;
    }
}
