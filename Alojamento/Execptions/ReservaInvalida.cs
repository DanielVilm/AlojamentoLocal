    public class ReservaInvalidaException : Exception
    {
        public ReservaInvalidaException()
            : base("A reserva contém valores inválidos ou está em estado inválido para esta operação.") { }
    }
