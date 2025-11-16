  public class AlojamentoNaoEncontradoException : Exception
    {
        public AlojamentoNaoEncontradoException(int id)
            : base($"Alojamento com ID {id} não foi encontrado.") { }
    }