public class OperacaoNaoPermitidaException : Exception
    {
        public OperacaoNaoPermitidaException()
            : base("A operação solicitada não é permitida nesta reserva.") { }
    }