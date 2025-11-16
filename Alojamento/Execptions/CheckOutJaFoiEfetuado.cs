public class CheckOutJaEfetuadoException : Exception
    {
        public CheckOutJaEfetuadoException(int reservaId)
            : base($"A reserva {reservaId} já se encontra em check-out.") { }
    }