 /// <summary>
/// Representa uma reserva entre um cliente e um alojamento.
/// </summary>
public class Reserva
{
    public int Id { get; private set; }

    // Associação ao Cliente
    public Cliente Cliente { get; private set; }

    // Associação ao Alojamento
    public Alojamento Alojamento { get; private set; }

    // Datas da reserva
    public DateTime DataInicio { get; private set; }
    public DateTime DataFim { get; private set; }

    // Indica se a reserva ainda está ativa
    public bool Ativa { get; protected set; }

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
    /// Cancela a reserva, marcando-a como inativa.
    /// </summary>
    public virtual void Cancelar()
    {
        if (!Ativa)
            throw new InvalidOperationException("A reserva já se encontra inativa.");

        Ativa = false;
    }

    /// <summary>
    /// Altera as datas da reserva (valida apenas coerência interna).
    /// A verificação de conflitos com outras reservas é responsabilidade do sistema.
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

    public override string ToString()
    {
        return $"Reserva {Id} | Cliente: {Cliente.Nome} | Alojamento: {Alojamento.Tipo} - {Alojamento.Morada} | " +
               $"{DataInicio:yyyy-MM-dd} a {DataFim:yyyy-MM-dd} | {(Ativa ? "Ativa" : "Inativa")}";
    }
}

     /// <summary>
    /// Representa uma reserva no momento de check-in.
    /// </summary>
    public class CheckIn : Reserva
    {
        public DateTime DataHoraCheckIn { get; private set; }
        public string FuncionarioResponsavel { get; private set; }

        public CheckIn(int id, Cliente cliente, Alojamento alojamento,
                       DateTime dataInicio, DateTime dataFim,
                       DateTime dataHoraCheckIn, string funcionarioResponsavel)
            : base(id, cliente, alojamento, dataInicio, dataFim)
        {
            DataHoraCheckIn = dataHoraCheckIn;
            FuncionarioResponsavel = funcionarioResponsavel;
        }

        public override string ToString()
        {
            return base.ToString() +
                   $" | CHECK-IN em {DataHoraCheckIn:yyyy-MM-dd HH:mm} por {FuncionarioResponsavel}";
        }
    }

     /// <summary>
    /// Representa uma reserva no momento de check-out.
    /// </summary>
    public class CheckOut : Reserva
    {
        public DateTime DataHoraCheckOut { get; private set; }
        public decimal ValorTotal { get; private set; }
        public bool LimpezaConcluida { get; private set; }

        public CheckOut(int id, Cliente cliente, Alojamento alojamento,
                        DateTime dataInicio, DateTime dataFim,
                        DateTime dataHoraCheckOut, decimal valorTotal,
                        bool limpezaConcluida)
            : base(id, cliente, alojamento, dataInicio, dataFim)
        {
            DataHoraCheckOut = dataHoraCheckOut;
            ValorTotal = valorTotal;
            LimpezaConcluida = limpezaConcluida;
            Ativa = false; // check-out normalmente "encerra" a reserva
        }

        public override string ToString()
        {
            return base.ToString() +
                   $" | CHECK-OUT em {DataHoraCheckOut:yyyy-MM-dd HH:mm} | Total: {ValorTotal:C} | Limpeza: {(LimpezaConcluida ? "Sim" : "Não")}";
        }
    }

