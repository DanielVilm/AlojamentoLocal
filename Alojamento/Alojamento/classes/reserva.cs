/// <summary>
/// Representa uma reserva entre um cliente e um alojamento.
/// Contém as informações essenciais da reserva, como datas,
/// cliente associado e alojamento reservado.
/// </summary>
public class Reserva
{
    // Identificador único da reserva.
    public int Id { get; private set; }

    // Cliente que efetuou a reserva.
    public Cliente Cliente { get; private set; }

    // Alojamento associado à reserva.
    public Alojamento Alojamento { get; private set; }

    // Data prevista de entrada no alojamento.
    public DateTime DataInicio { get; private set; }

    // Data prevista de saída do alojamento.
    public DateTime DataFim { get; private set; }

    // Indica se a reserva está ativa.
    // Uma reserva é marcada como inativa quando é cancelada ou após check-out.
    public bool Ativa { get; protected set; }

    /// <summary>
    /// Construtor da classe Reserva. Verifica a coerência das datas
    /// e inicializa a ligação entre cliente e alojamento.
    /// </summary>
    public Reserva(int id, Cliente cliente, Alojamento alojamento,
                   DateTime dataInicio, DateTime dataFim)
    {
        if (dataFim <= dataInicio)
            throw new ArgumentException("A data de fim deve ser posterior à data de início.");

        Id = id;
        Cliente = cliente ?? throw new ArgumentNullException(nameof(cliente));
        Alojamento = alojamento ?? throw new ArgumentNullException(nameof(alojamento));
        DataInicio = dataInicio;
        DataFim = dataFim;
        Ativa = true;
    }

    /// <summary>
    /// Cancela a reserva, tornando-a inativa.
    /// Se já estiver inativa, lança exceção.
    /// </summary>
    public virtual void Cancelar()
    {
        if (!Ativa)
            throw new InvalidOperationException("A reserva já se encontra inativa.");

        Ativa = false;
    }

    /// <summary>
    /// Altera as datas da reserva.
    /// Esta classe apenas valida coerência interna;
    /// a verificação de conflito com outras reservas é feita no sistema.
    /// </summary>
    public virtual void AlterarDatas(DateTime novoInicio, DateTime novoFim)
    {
        if (!Ativa)
            throw new InvalidOperationException("Não é possível alterar uma reserva inativa.");

        if (novoFim <= novoInicio)
            throw new ArgumentException("A data de fim deve ser posterior à data de início.");

        DataInicio = novoInicio;
        DataFim = novoFim;
    }

    /// <summary>
    /// Representação textual simples da reserva.
    /// Inclui cliente, alojamento e período reservado.
    /// </summary>
    public override string ToString()
    {
        return $"Reserva {Id} | Cliente: {Cliente.Nome} | Alojamento: {Alojamento.Tipo} - {Alojamento.Morada} | " +
               $"{DataInicio:yyyy-MM-dd} a {DataFim:yyyy-MM-dd} | {(Ativa ? "Ativa" : "Inativa")}";
    }
}

/// <summary>
/// Representa o registo de entrada (check-in) de uma reserva.
/// Regista a data/hora em que o cliente entrou e o funcionário responsável.
/// </summary>
public class CheckIn : Reserva
{
    // Momento exato em que o cliente realizou o check-in.
    public DateTime DataHoraCheckIn { get; private set; }

    // Funcionário que realizou/confirmou o check-in.
    public string FuncionarioResponsavel { get; private set; }

    /// <summary>
    /// Construtor do CheckIn.
    /// Reutiliza os dados da reserva base e acrescenta informações do check-in.
    /// </summary>
    public CheckIn(int id, Cliente cliente, Alojamento alojamento,
                   DateTime dataInicio, DateTime dataFim,
                   DateTime dataHoraCheckIn, string funcionarioResponsavel)
        : base(id, cliente, alojamento, dataInicio, dataFim)
    {
        DataHoraCheckIn = dataHoraCheckIn;
        FuncionarioResponsavel = funcionarioResponsavel;
    }

    /// <summary>
    /// Adiciona ao texto base da reserva informação específica do check-in.
    /// </summary>
    public override string ToString()
    {
        return base.ToString() +
               $" | CHECK-IN em {DataHoraCheckIn:yyyy-MM-dd HH:mm} por {FuncionarioResponsavel}";
    }
}


/// <summary>
/// Representa o registo de saída (check-out) de uma reserva.
/// Armazena hora do check-out, valor total e estado da limpeza.
/// </summary>
public class CheckOut : Reserva
{
    // Momento em que o cliente saiu do alojamento.
    public DateTime DataHoraCheckOut { get; private set; }

    // Valor total a ser cobrado ao cliente.
    public decimal ValorTotal { get; private set; }

    // Indica se a limpeza após a saída foi concluída.
    public bool LimpezaConcluida { get; private set; }

    /// <summary>
    /// Construtor do CheckOut.
    /// Marca a reserva automaticamente como inativa
    /// por representar o encerramento da estadia.
    /// </summary>
    public CheckOut(int id, Cliente cliente, Alojamento alojamento,
                    DateTime dataInicio, DateTime dataFim,
                    DateTime dataHoraCheckOut, decimal valorTotal,
                    bool limpezaConcluida)
        : base(id, cliente, alojamento, dataInicio, dataFim)
    {
        DataHoraCheckOut = dataHoraCheckOut;
        ValorTotal = valorTotal;
        LimpezaConcluida = limpezaConcluida;

        // Após check-out, a reserva deixa de estar ativa.
        Ativa = false;
    }

    /// <summary>
    /// Adiciona ao texto base da reserva informações detalhadas do check-out.
    /// </summary>
    public override string ToString()
    {
        return base.ToString() +
               $" | CHECK-OUT em {DataHoraCheckOut:yyyy-MM-dd HH:mm} | Total: {ValorTotal:C} | Limpeza: {(LimpezaConcluida ? "Sim" : "Não")}";
    }
}
