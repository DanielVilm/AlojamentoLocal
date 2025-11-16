
    public class ConflitoReservaException : Exception
    {
        public ConflitoReservaException()
            : base("Existe um conflito de datas com outra reserva para este alojamento.") { }
    }

