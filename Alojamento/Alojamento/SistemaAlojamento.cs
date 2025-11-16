     /// <summary>
    /// Sistema principal de gestão de clientes, alojamentos e reservas.
    /// </summary>
    public class SistemaAlojamentos
    {
        // Coleções principais
        private readonly List<Cliente> _clientes = new();
        private readonly List<Alojamento> _alojamentos = new();
        private readonly List<Reserva> _reservas = new();

        // Contadores de Id
        private int _proximoIdCliente = 1;
        private int _proximoIdAlojamento = 1;
        private int _proximoIdReserva = 1;

        // ---------------------------
        // CLIENTES
        // ---------------------------

        public Cliente RegistarCliente(string nome, string nif, string email, string telefone)
        {
            var cliente = new Cliente(_proximoIdCliente++, nome, nif, email, telefone);
            _clientes.Add(cliente);
            return cliente;
        }

        public IEnumerable<Cliente> ObterClientes()
        {
            return _clientes;
        }

        public Cliente ObterClientePorId(int idCliente)
        {
            return _clientes.FirstOrDefault(c => c.Id == idCliente);
        }

        // ---------------------------
        // ALOJAMENTOS
        // ---------------------------

        public Quarto AdicionarQuarto(string morada, string proprietario,
                                      int capacidade, bool temCasaDeBanhoPrivada)
        {
            var quarto = new Quarto(_proximoIdAlojamento++, morada, proprietario,
                                    capacidade, temCasaDeBanhoPrivada);
            _alojamentos.Add(quarto);
            return quarto;
        }

        public Hostel AdicionarHostel(string morada, string proprietario,
                                      int numeroCamas, bool incluiPequenoAlmoco)
        {
            var hostel = new Hostel(_proximoIdAlojamento++, morada, proprietario,
                                    numeroCamas, incluiPequenoAlmoco);
            _alojamentos.Add(hostel);
            return hostel;
        }

        public Apartamento AdicionarApartamento(string morada, string proprietario,
                                                int numeroQuartos, bool temCozinhaEquipada)
        {
            var apartamento = new Apartamento(_proximoIdAlojamento++, morada, proprietario,
                                              numeroQuartos, temCozinhaEquipada);
            _alojamentos.Add(apartamento);
            return apartamento;
        }

        public Casa AdicionarCasa(string morada, string proprietario,
                                  int numeroQuartos, bool temJardim, bool temPiscina)
        {
            var casa = new Casa(_proximoIdAlojamento++, morada, proprietario,
                                numeroQuartos, temJardim, temPiscina);
            _alojamentos.Add(casa);
            return casa;
        }

        public Quinta AdicionarQuinta(string morada, string proprietario,
                                      double areaTotalHectares, bool temAnimais)
        {
            var quinta = new Quinta(_proximoIdAlojamento++, morada, proprietario,
                                    areaTotalHectares, temAnimais);
            _alojamentos.Add(quinta);
            return quinta;
        }

        public IEnumerable<Alojamento> ObterAlojamentos()
        {
            return _alojamentos;
        }

        public Alojamento ObterAlojamentoPorId(int idAlojamento)
        {
            return _alojamentos.FirstOrDefault(a => a.Id == idAlojamento);
        }

        // ---------------------------
        // RESERVAS
        // ---------------------------

        /// <summary>
        /// Cria uma reserva entre um cliente e um alojamento.
        /// </summary>
        public Reserva CriarReserva(int idCliente, int idAlojamento,
                                    DateTime dataInicio, DateTime dataFim)
        {
            var cliente = ObterClientePorId(idCliente)
                ?? throw new ArgumentException("Cliente não encontrado.", nameof(idCliente));

            var alojamento = ObterAlojamentoPorId(idAlojamento)
                ?? throw new ArgumentException("Alojamento não encontrado.", nameof(idAlojamento));

            var reserva = new Reserva(_proximoIdReserva++, cliente, alojamento, dataInicio, dataFim);
            _reservas.Add(reserva);
            return reserva;
        }

        public IEnumerable<Reserva> ObterReservas()
        {
            return _reservas;
        }

        public Reserva ObterReservaPorId(int idReserva)
        {
            return _reservas.FirstOrDefault(r => r.Id == idReserva);
        }

        // ---------------------------
        // CHECK-IN
        // ---------------------------

        /// <summary>
        /// Efetua o check-in numa reserva, convertendo a reserva existente num objeto CheckIn.
        /// </summary>
        public CheckIn EfetuarCheckIn(int idReserva, DateTime dataHoraCheckIn, string funcionarioResponsavel)
        {
            var reservaExistente = ObterReservaPorId(idReserva);

            if (reservaExistente == null)
                throw new ArgumentException("Reserva não encontrada.", nameof(idReserva));

            if (reservaExistente is CheckOut)
                throw new InvalidOperationException("Não é possível fazer check-in numa reserva já em check-out.");

            if (reservaExistente is CheckIn)
                throw new InvalidOperationException("A reserva já tem check-in efetuado.");

            // Criar novo objeto CheckIn com base na reserva atual
            var checkIn = new CheckIn(
                reservaExistente.Id,
                reservaExistente.Cliente,
                reservaExistente.Alojamento,
                reservaExistente.DataInicio,
                reservaExistente.DataFim,
                dataHoraCheckIn,
                funcionarioResponsavel
            );

            // Substituir na lista
            SubstituirReservaNaLista(checkIn);

            return checkIn;
        }

        // ---------------------------
        // CHECK-OUT
        // ---------------------------

        /// <summary>
        /// Efetua o check-out numa reserva, convertendo-a num objeto CheckOut.
        /// </summary>
        public CheckOut EfetuarCheckOut(int idReserva, DateTime dataHoraCheckOut,
                                        decimal valorTotal, bool limpezaConcluida)
        {
            var reservaExistente = ObterReservaPorId(idReserva);

            if (reservaExistente == null)
                throw new ArgumentException("Reserva não encontrada.", nameof(idReserva));

            if (reservaExistente is CheckOut)
                throw new InvalidOperationException("A reserva já se encontra em check-out.");

            // (Opcional) Obrigar a que já tenha havido check-in:
            // if (reservaExistente is not CheckIn)
            //     throw new InvalidOperationException("A reserva tem de ter check-in antes do check-out.");

            var checkOut = new CheckOut(
                reservaExistente.Id,
                reservaExistente.Cliente,
                reservaExistente.Alojamento,
                reservaExistente.DataInicio,
                reservaExistente.DataFim,
                dataHoraCheckOut,
                valorTotal,
                limpezaConcluida
            );

            SubstituirReservaNaLista(checkOut);

            return checkOut;
        }

        // ---------------------------
        // MÉTODO DE APOIO
        // ---------------------------

        private void SubstituirReservaNaLista(Reserva novaReserva)
        {
            var index = _reservas.FindIndex(r => r.Id == novaReserva.Id);
            if (index >= 0)
            {
                _reservas[index] = novaReserva;
            }
        }

    public bool CancelarReserva(int idReserva)
{
    var reserva = ObterReservaPorId(idReserva);
    if (reserva == null)
        return false;
    reserva.Cancelar();
    return true;
}
public bool AlterarDatasReserva(int idReserva, DateTime novoInicio, DateTime novoFim)
{
    var reserva = ObterReservaPorId(idReserva);
    if (reserva == null)
        return false;

    // 1. Verificar conflitos com outras reservas ativas do mesmo alojamento
    bool conflito = _reservas
        .Where(r => r.Alojamento.Id == reserva.Alojamento.Id &&
                    r.Id != reserva.Id &&    // ignorar a própria reserva
                    r.Ativa)
        .Any(r => IntervalosSobrepoem(r.DataInicio, r.DataFim, novoInicio, novoFim));

    if (conflito)
    {
        // não altera, devolve false a dizer que não foi possível
        return false;
    }

    // 2. Sem conflitos → altera datas na própria reserva
    reserva.AlterarDatas(novoInicio, novoFim);
    return true;
}

private static bool IntervalosSobrepoem(DateTime inicio1, DateTime fim1,
                                        DateTime inicio2, DateTime fim2)
{
    return inicio1 < fim2 && inicio2 < fim1;
}
    }


