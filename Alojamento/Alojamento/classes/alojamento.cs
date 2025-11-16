/// <summary>
//// Classe base mãe que representa um alojamento genérico.
//  Contém atributos comuns a todos os tipos de alojamentos (Quarto, Casa, Hostel, etc.).
/// </summary>
public abstract class Alojamento
{
    // Identificador único do alojamento.
    // É definido no construtor e não pode ser alterado posteriormente.
    public int Id { get; private set; }

    // Morada completa do alojamento.
    // Pode ser alterada através do método AlterarMorada().
    public string Morada { get; private set; }

    // Nome do proprietário ou entidade responsável pelo alojamento.
    // Pode ser alterado com o método AlterarProprietario().
    public string Proprietario { get; private set; }

    /// <summary>
    /// Tipo de alojamento (ex: Quarto, Hostel, Apartamento...),
    /// definido obrigatoriamente pelas classes derivadas.
    /// </summary>
    public abstract string Tipo { get; }

    /// <summary>
    /// Construtor protegido, usado apenas pelas subclasses.
    /// Inicializa propriedades comuns a qualquer alojamento.
    /// </summary>
    protected Alojamento(int id, string morada, string proprietario)
    {
        Id = id;
        Morada = morada;
        Proprietario = proprietario;
    }

    /// <summary>
    /// Retorna uma representação textual simples do alojamento.
    /// Útil para listagens no sistema.
    /// </summary>
    public override string ToString()
    {
        return $"{Id} | {Tipo} | {Morada} | Proprietário: {Proprietario}";
    }

    // --------------------------------------------------------------
    // MÉTODOS DE ALTERAÇÃO DE DADOS
    // --------------------------------------------------------------

    /// <summary>
    /// Altera a morada do alojamento.
    /// Garante que o novo valor não é nulo nem vazio.
    /// </summary>
    /// <param name="novaMorada">Nova morada a ser definida.</param>
    public void AlterarMorada(string novaMorada)
    {
        if (string.IsNullOrWhiteSpace(novaMorada))
            throw new ArgumentException("A morada não pode ser vazia.");

        Morada = novaMorada;
    }

    /// <summary>
    /// Altera o nome do proprietário do alojamento.
    /// Garante que o novo nome é válido.
    /// </summary>
    /// <param name="novoProprietario">Novo nome do proprietário.</param>
    public void AlterarProprietario(string novoProprietario)
    {
        if (string.IsNullOrWhiteSpace(novoProprietario))
            throw new ArgumentException("O nome do proprietário não pode ser vazio.");

        Proprietario = novoProprietario;
    }
}

   

