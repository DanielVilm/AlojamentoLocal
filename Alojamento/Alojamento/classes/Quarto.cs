/// <summary>
/// Representa um Quarto no sistema de gestão de alojamentos.
/// Esta classe herda de Alojamento e inclui características
/// específicas como capacidade máxima e existência de casa
/// de banho privada.
/// </summary>
public class Quarto : Alojamento
{
    // Capacidade máxima de hóspedes que o quarto pode acomodar.
    // Este valor só pode ser alterado através de métodos próprios.
    public int Capacidade { get; private set; }

    // Indica se o quarto possui casa de banho privada.
    public bool TemCasaDeBanhoPrivada { get; private set; }

    // Tipo de alojamento, definido pela classe derivada.
    public override string Tipo => "Quarto";

    /// <summary>
    /// Construtor do Quarto. Define os atributos específicos do quarto
    /// e utiliza o construtor base para preencher as propriedades comuns.
    /// </summary>
    /// <param name="id">Identificador único do quarto.</param>
    /// <param name="morada">Morada do alojamento onde o quarto está inserido.</param>
    /// <param name="proprietario">Nome do proprietário.</param>
    /// <param name="capacidade">Capacidade máxima de hóspedes.</param>
    /// <param name="temCasaDeBanhoPrivada">Indica se o quarto possui WC privada.</param>
    public Quarto(int id, string morada, string proprietario,
                  int capacidade, bool temCasaDeBanhoPrivada)
        : base(id, morada, proprietario)
    {
        Capacidade = capacidade;
        TemCasaDeBanhoPrivada = temCasaDeBanhoPrivada;
    }

    // ---------------------------------------------------------
    // MÉTODOS DE ALTERAÇÃO ESPECÍFICOS DO QUARTO
    // ---------------------------------------------------------

    /// <summary>
    /// Altera a capacidade máxima do quarto.
    /// Garante que a capacidade nunca seja inferior a 1.
    /// </summary>
    /// <param name="novaCapacidade">Nova capacidade máxima.</param>
    public void AlterarCapacidade(int novaCapacidade)
    {
        if (novaCapacidade <= 0)
            throw new ArgumentException("A capacidade deve ser pelo menos 1.");

        Capacidade = novaCapacidade;
    }

    /// <summary>
    /// Ativa o atributo indicando que o quarto possui casa de banho privada.
    /// </summary>
    public void AtivarCasaDeBanhoPrivada()
    {
        TemCasaDeBanhoPrivada = true;
    }

    /// <summary>
    /// Desativa o atributo indicando que o quarto possui casa de banho privada.
    /// </summary>
    public void DesativarCasaDeBanhoPrivada()
    {
        TemCasaDeBanhoPrivada = false;
    }
}
