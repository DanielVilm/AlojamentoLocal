/// <summary>
/// Representa um cliente do sistema de gestão de alojamentos.
/// </summary>
public class Cliente
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string Nif { get; private set; }
    public string Email { get; private set; }
    public string Telefone { get; private set; }
    public bool Ativo { get; private set; } = true;

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
    /// </summary>
    public void AtualizarNome(string novoNome)
    {
        if (string.IsNullOrWhiteSpace(novoNome))
            throw new ArgumentException("O nome não pode ser vazio.");

        Nome = novoNome;
    }

    /// <summary>
    /// Atualiza os contactos do cliente (email e telefone).
    /// </summary>
    public void AtualizarContactos(string novoEmail, string novoTelefone)
    {
        Email = novoEmail;
        Telefone = novoTelefone;
    }

    /// <summary>
    /// Desativa o cliente (em vez de apagar).
    /// </summary>
    public void Desativar()
    {
        Ativo = false;
    }

    /// <summary>
    /// Ativa novamente o cliente.
    /// </summary>
    public void Ativar()
    {
        Ativo = true;
    }

    /// <summary>
    /// Verifica se o NIF tem 9 dígitos (validação simples).
    /// </summary>
    public bool NifValido()
    {
        return Nif.Length == 9 && Nif.All(char.IsDigit);
    }

    public override string ToString()
    {
        string estado = Ativo ? "Ativo" : "Inativo";
        return $"{Id} - {Nome} | NIF: {Nif} | Email: {Email} | Tel: {Telefone} | {estado}";
    }
}
