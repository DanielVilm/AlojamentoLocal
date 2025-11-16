public class CheckInJaEfetuadoException : Exception
    {
        public CheckInJaEfetuadoException(int reservaId)
            : base($"A reserva {reservaId} já tem check-in efetuado.") { }
    }