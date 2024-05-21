namespace AbstractFactory
{
    #region Interfaces
    public interface IEnergia
    {
        void Composicao();
    }

    public interface IRevestimento 
    {
        void Composicao();
    }
    
    public interface IArmy
    {
        void Composicao();
    }

    public interface IFabricaBases
    {
        void CriarBase();
    }
    #endregion

    #region Fabricas
    public class FabricaBaseTerran: IFabricaBases
    {
        public FabricaBaseTerran()
        {
            CriarBase();
        }

        public void CriarBase()
        {
            Console.WriteLine("Base Terran criada com sucesso!");
            RevestimentoBaseTerran revestimentoBaseTerran = new();
            EnergiaBaseTerran energiaBaseTerran = new();
            ArmyBaseTerran armyBaseTerran = new();
            revestimentoBaseTerran.Composicao();
            energiaBaseTerran.Composicao();
            armyBaseTerran.Composicao();
        }
    }

    public class FabricaBaseProtoss: IFabricaBases
    {
       public FabricaBaseProtoss()
        {
            CriarBase();
        }

        public void CriarBase()
        {
            Console.WriteLine("Base Protoss criada com sucesso!");
            RevestimentoBaseProtoss revestimentoBaseProtoss = new();
            EnergiaBaseProtoss energiaBaseProtoss = new();
            ArmyBaseProtoss armyBaseProtoss = new();

            revestimentoBaseProtoss.Composicao();
            energiaBaseProtoss.Composicao();
            armyBaseProtoss.Composicao();
        }
    }

    public class FabricaBaseZerg: IFabricaBases
    {
       public FabricaBaseZerg()
        {
            CriarBase();
        }

        public void CriarBase()
        {
            Console.WriteLine("Base Zerg criada com sucesso!");
            RevestimentoBaseZerg revestimentoBaseZerg = new();
            EnergiaBaseZerg energiaBaseZerg = new();
            ArmyBaseZerg armyBaseZerg = new();
            revestimentoBaseZerg.Composicao();
            energiaBaseZerg.Composicao();
            armyBaseZerg.Composicao();
        }
    }

    public class FabricaBaseSkyWalker: IFabricaBases
    {
        public FabricaBaseSkyWalker()
        {
            CriarBase();
        }
        public void CriarBase()
        {
            Console.WriteLine("Base SkyWalker criada com sucesso!");

            RevestimentoBaseSkyWalker revestimentoBaseSkyWalker = new();
            EnergiaBaseSkyWalker energiaBaseSkyWalker = new();
            ArmyBaseSkyWalker armyBaseSkyWalker = new();
            revestimentoBaseSkyWalker.Composicao();
            energiaBaseSkyWalker.Composicao();
            armyBaseSkyWalker.Composicao();
        }
    }

    public class FabricaBaseLizards: IFabricaBases
    {
        public FabricaBaseLizards()
        {
            CriarBase();
        }

        public void CriarBase()
        {
            Console.WriteLine("Base Lizard criada com sucesso");
            EnergiaBaseLizards energiaBaseLizards = new();
            RevestimentoBaseLizards revestimentoBaseLizards = new();
            ArmyBaseLizards armyBaseLizards= new();

            energiaBaseLizards.Composicao();
            revestimentoBaseLizards.Composicao();
            armyBaseLizards.Composicao();
        }
    }
    #endregion

    #region Terran
    public class EnergiaBaseTerran: IEnergia
    {
        public void Composicao() => Console.WriteLine("Energia de sustentação da base mecânica");
    }

    public class ArmyBaseTerran : IArmy
    {
        public void Composicao() => Console.WriteLine("Usamos Machine Guns de base metalica revestida de prata e chumbo com polvora.");
    }
    public class RevestimentoBaseTerran: IRevestimento
    {
        public void Composicao() => Console.WriteLine("Base revestida pela cor verde");
    }
    #endregion

    #region Protoss
    public class EnergiaBaseProtoss: IEnergia
    {
        public void Composicao() => Console.WriteLine("Energia de sustentação da base com cristais.");
    }
    public class ArmyBaseProtoss: IArmy
    {
        public void Composicao() => Console.WriteLine("Usamos armas de plasma celestiais");
    }
    public class RevestimentoBaseProtoss: IRevestimento
    {
        public void Composicao() => Console.WriteLine("Base revestida pela cor amarela.");
    }
    #endregion

    #region Zerg
    public class EnergiaBaseZerg: IEnergia
    {
        public void Composicao() => Console.WriteLine("Energia de sustentação da base pela terra.");
    }

    public class ArmyBaseZerg : IArmy
    {
        public void Composicao() => Console.WriteLine("Usamos espadas de cristais e catapultas.");
    }
    public class RevestimentoBaseZerg: IRevestimento
    {
        public void Composicao() => Console.WriteLine("Base revestida pela cor vermelha.");
    }
    #endregion

    #region SkyWalker
    public class EnergiaBaseSkyWalker: IEnergia
    {
        public void Composicao() => Console.WriteLine("Energia da base com particulas de estrelas de neutrons");
    }

    public class ArmyBaseSkyWalker : IArmy
    {
        public void Composicao() => Console.WriteLine("Usamos compressores estrelares e criadores de buraco negro.");
    }
    public class RevestimentoBaseSkyWalker: IRevestimento
    {
        public void Composicao() => Console.WriteLine("Revestimento da base de cor branca");
    }
    #endregion

    #region Lizards
    public class EnergiaBaseLizards: IEnergia
    {
        public void Composicao() => Console.WriteLine("Energia da base com Sangue Terreano");
    }

    public class ArmyBaseLizards: IArmy
    {
        public void Composicao() => Console.WriteLine("Usamos armas acidas e possuimos uma bilindade quase indestrutivel.");
    }
    public class RevestimentoBaseLizards: IRevestimento
    {
        public void Composicao() => Console.WriteLine("Revestimento da base de cor purpura");
    }
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Escolha um dos personagens: 1-| Terranos 2-| Protoss 3-| Zergs 4-|SkyWalkers 5-|Lizards:");

            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    _ = new FabricaBaseTerran();
                    break;
                case 2:
                    _ = new FabricaBaseProtoss();
                    break;
                case 3:
                    _ = new FabricaBaseZerg();
                    break;
                case 4:
                    _ = new FabricaBaseSkyWalker();
                    break;
                case 5:
                    _ = new FabricaBaseLizards();
                    break;
                default:
                    break;
            }
            Console.ReadKey();
        }
    }
}
