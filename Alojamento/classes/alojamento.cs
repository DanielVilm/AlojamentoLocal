/// <summary>
    /// Classe base para todos os tipos de alojamento.
    /// </summary>
    public abstract class Alojamento
    {
        public int Id { get; private set; }
        public string Morada { get; private set; }
        public string Proprietario { get; private set; }

        /// <summary>
        /// Tipo de alojamento (ex: Quarto, Hostel, Apartamento...)
        /// Definido nas subclasses.
        /// </summary>
        public abstract string Tipo { get; }

        protected Alojamento(int id, string morada, string proprietario)
        {
            Id = id;
            Morada = morada;
            Proprietario = proprietario;
        }

        public override string ToString()
        {
            return $"{Id} | {Tipo} | {Morada} | Proprietário: {Proprietario}";
        }
    }

    public class Quarto : Alojamento
    {
        public int Capacidade { get; private set; }
        public bool TemCasaDeBanhoPrivada { get; private set; }

        public override string Tipo => "Quarto";

        public Quarto(int id, string morada, string proprietario,
                      int capacidade, bool temCasaDeBanhoPrivada)
            : base(id, morada, proprietario)
        {
            Capacidade = capacidade;
            TemCasaDeBanhoPrivada = temCasaDeBanhoPrivada;
        }
    }

    public class Hostel : Alojamento
    {
        public int NumeroCamas { get; private set; }
        public bool IncluiPequenoAlmoco { get; private set; }

        public override string Tipo => "Hostel";

        public Hostel(int id, string morada, string proprietario,
                      int numeroCamas, bool incluiPequenoAlmoco)
            : base(id, morada, proprietario)
        {
            NumeroCamas = numeroCamas;
            IncluiPequenoAlmoco = incluiPequenoAlmoco;
        }
    }

    public class Apartamento : Alojamento
    {
        public int NumeroQuartos { get; private set; }
        public bool TemCozinhaEquipada { get; private set; }

        public override string Tipo => "Apartamento";

        public Apartamento(int id, string morada, string proprietario,
                           int numeroQuartos, bool temCozinhaEquipada)
            : base(id, morada, proprietario)
        {
            NumeroQuartos = numeroQuartos;
            TemCozinhaEquipada = temCozinhaEquipada;
        }
    }

    public class Casa : Alojamento
    {
        public int NumeroQuartos { get; private set; }
        public bool TemJardim { get; private set; }
        public bool TemPiscina { get; private set; }

        public override string Tipo => "Casa";

        public Casa(int id, string morada, string proprietario,
                    int numeroQuartos, bool temJardim, bool temPiscina)
            : base(id, morada, proprietario)
        {
            NumeroQuartos = numeroQuartos;
            TemJardim = temJardim;
            TemPiscina = temPiscina;
        }
    }

     public class Quinta : Alojamento
    {
        public double AreaTotalHectares { get; private set; }
        public bool TemAnimais { get; private set; }

        public override string Tipo => "Quinta";

        public Quinta(int id, string morada, string proprietario,
                      double areaTotalHectares, bool temAnimais)
            : base(id, morada, proprietario)
        {
            AreaTotalHectares = areaTotalHectares;
            TemAnimais = temAnimais;
        }
    }