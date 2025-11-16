/// <summary>
//// Representa um Apartamento no sistema de alojamentos.
//  Herda da classe base Alojamento e adiciona propriedades
//  específicas deste tipo de alojamento, como número de quartos
//  e se possui cozinha equipada.
/// </summary>
public class Apartamento : Alojamento
{
    // Número total de quartos existentes no apartamento.
    // O valor só pode ser alterado através de métodos próprios.
    public int NumeroQuartos { get; private set; }

    // Indica se o apartamento dispõe de cozinha totalmente equipada.
    public bool TemCozinhaEquipada { get; private set; }

    // Tipo de alojamento, definido pela classe derivada.
    // Override obrigatório da propriedade abstrata da classe Alojamento.
    public override string Tipo => "Apartamento";

    /// <summary>
    /// Construtor do Apartamento. Inicializa todos os atributos específicos
    /// e reutiliza o construtor base para preencher as propriedades comuns.
    /// </summary>
    /// <param name="id">Identificador único do alojamento.</param>
    /// <param name="morada">Morada completa do apartamento.</param>
    /// <param name="proprietario">Nome do proprietário.</param>
    /// <param name="numeroQuartos">Quantidade de quartos do apartamento.</param>
    /// <param name="temCozinhaEquipada">Indica se a cozinha é equipada.</param>
    public Apartamento(int id, string morada, string proprietario,
                       int numeroQuartos, bool temCozinhaEquipada)
        : base(id, morada, proprietario)
    {
        NumeroQuartos = numeroQuartos;
        TemCozinhaEquipada = temCozinhaEquipada;
    }

    // -------------------------------------------------------------
    // MÉTODOS DE ALTERAÇÃO DE ATRIBUTOS ESPECÍFICOS DO APARTAMENTO
    // -------------------------------------------------------------

    /// <summary>
    /// Altera o número total de quartos do apartamento.
    /// Garante que o valor é válido (mínimo: 1).
    /// </summary>
    /// <param name="novoNumero">Novo número de quartos.</param>
    public void AlterarNumeroQuartos(int novoNumero)
    {
        if (novoNumero <= 0)
            throw new ArgumentException("O número de quartos deve ser pelo menos 1.");

        NumeroQuartos = novoNumero;
    }

    /// <summary>
    /// Ativa a opção de cozinha equipada no apartamento.
    /// </summary>
    public void AtivarCozinha()
    {
        TemCozinhaEquipada = true;
    }

    /// <summary>
    /// Desativa a opção de cozinha equipada no apartamento.
    /// </summary>
    public void DesativarCozinha()
    {
        TemCozinhaEquipada = false;
    }
}
