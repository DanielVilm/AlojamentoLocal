/// <summary>
/// Representa uma Quinta no sistema de gestão de alojamentos.
/// Esta classe herda de Alojamento e adiciona atributos específicos,
/// como a área total em hectares e a presença de animais.
/// </summary>
public class Quinta : Alojamento
{
    // Área total da quinta medida em hectares.
    // Este valor só pode ser alterado através dos métodos públicos apropriados.
    public double AreaTotalHectares { get; private set; }

    // Indica se a quinta possui animais (por exemplo, quinta agrícola ou turística).
    public bool TemAnimais { get; private set; }

    // Tipo de alojamento definido pela classe derivada.
    public override string Tipo => "Quinta";

    /// <summary>
    /// Construtor da classe Quinta.
    /// Inicializa os atributos específicos e invoca o construtor da classe base.
    /// </summary>
    /// <param name="id">Identificador único da quinta.</param>
    /// <param name="morada">Localização da quinta.</param>
    /// <param name="proprietario">Nome do proprietário.</param>
    /// <param name="areaTotalHectares">Área total em hectares.</param>
    /// <param name="temAnimais">Indica se a quinta possui animais.</param>
    public Quinta(int id, string morada, string proprietario,
                  double areaTotalHectares, bool temAnimais)
        : base(id, morada, proprietario)
    {
        AreaTotalHectares = areaTotalHectares;
        TemAnimais = temAnimais;
    }

    // ---------------------------------------------------------
    // MÉTODOS DE ALTERAÇÃO ESPECÍFICOS DA QUINTA
    // ---------------------------------------------------------

    /// <summary>
    /// Altera a área total da quinta.
    /// Deve ser sempre superior a zero.
    /// </summary>
    /// <param name="novaArea">Nova área total em hectares.</param>
    public void AlterarArea(double novaArea)
    {
        if (novaArea <= 0)
            throw new ArgumentException("A área deve ser superior a 0 hectares.");

        AreaTotalHectares = novaArea;
    }

    /// <summary>
    /// Ativa o atributo indicando que a quinta possui animais.
    /// </summary>
    public void AtivarAnimais()
    {
        TemAnimais = true;
    }

    /// <summary>
    /// Desativa o atributo indicando a presença de animais na quinta.
    /// </summary>
    public void DesativarAnimais()
    {
        TemAnimais = false;
    }
}
