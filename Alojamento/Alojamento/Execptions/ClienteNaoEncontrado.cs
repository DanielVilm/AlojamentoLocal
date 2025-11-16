 public class ClienteNaoEncontradoException : Exception
    {
        public ClienteNaoEncontradoException(int id)
            : base($"Cliente com ID {id} não foi encontrado.") { }
    }