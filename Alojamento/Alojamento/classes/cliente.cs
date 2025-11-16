/// <summary>
/// Representa um cliente do sistema de gestão de alojamentos.
/// Contém dados pessoais e métodos para gestão do seu estado e contactos.
/// </summary>
public class Cliente
{
    // Identificador único do cliente no sistema.
    // Definido no construtor e não pode ser alterado depois.
    public int Id { get; private set; }

    // Nome completo do cliente.
    // Pode ser atualizado através do método AtualizarNome().
    public string Nome { get; private set; }

    // Número de Identificação Fiscal (NIF) do cliente.
    // Permite validação simples através do método NifValido().
    public string Nif { get; private set; }

    // Endereço de email do cliente.
    // Pode ser alterado pelo método AtualizarContactos().
    public string Email { get; private set; }

    // Número de telefone do cliente.
    // Também alterado pelo método AtualizarContactos().
    public string Telefone { get; private set; }

    // Indica se o cliente está ativo no sistema.
    // Serve para evitar apagar registos e manter histórico de reservas.
    public bool Ativo { get; private set; } = true;

    /// <summary>
    /// Construtor do Cliente.
    /// Inicializa todas as propriedades básicas.
    /// </summary>
    /// <param name="id">Identificador único do cliente.</param>
    /// <param name="nome">Nome do cliente.</param>
    /// <param name="nif">Número de Identificação Fiscal.</param>
    /// <param name="email">Email de contacto.</param>
    /// <param name="telefone">Número de telefone.</param>
    public Cliente(int id, string nome, string nif, string email, string telefone)
    {
        Id = id;
        Nome = nome;
        Nif = nif;
        Email = email;
        Telefone = telefone;
    }

    /// <summary>
    /// Atualiza o nome do cliente.
    /// Garante que o novo nome não é vazio nem inválido.
    /// </summary>
    /// <param name="novoNome">Novo nome do cliente.</param>
    public void AtualizarNome(string novoNome)
    {
        if (string.IsNullOrWhiteSpace(novoNome))
            throw new ArgumentException("O nome não pode ser vazio.");

        Nome = novoNome;
    }

    /// <summary>
    /// Atualiza simultaneamente o email e o telefone do cliente.
    /// Útil para mudanças rápidas de contacto.
    /// </summary>
    /// <param name="novoEmail">Novo endereço de email.</param>
    /// <param name="novoTelefone">Novo número de telefone.</param>
    public void AtualizarContactos(string novoEmail, string novoTelefone)
    {
        Email = novoEmail;
        Telefone = novoTelefone;
    }

    /// <summary>
    /// Marca o cliente como inativo.
    /// Serve como "eliminação lógica" sem apagar dados do histórico.
    /// </summary>
    public void Desativar()
    {
        Ativo = false;
    }

    /// <summary>
    /// Reativa o cliente, tornando-o novamente elegível para reservas.
    /// </summary>
    public void Ativar()
    {
        Ativo = true;
    }

    /// <summary>
    /// Valida o NIF do cliente.
    /// Verifica se tem 9 dígitos e se são todos numéricos.
    /// </summary>
    /// <returns>True se o NIF for válido; False caso contrário.</returns>
    public bool NifValido()
    {
        return Nif.Length == 9 && Nif.All(char.IsDigit);
    }

    /// <summary>
    /// Devolve uma representação textual detalhada do cliente.
    /// Inclui identificação, contactos e estado.
    /// </summary>
    public override string ToString()
    {
        string estado = Ativo ? "Ativo" : "Inativo";
        return $"{Id} - {Nome} | NIF: {Nif} | Email: {Email} | Tel: {Telefone} | {estado}";
    }
}
