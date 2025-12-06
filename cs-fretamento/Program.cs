
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;

namespace cs_fretamento
{
    /*
    | Instituto Federal de São Paulo - Campus Cubatão
    | Nome: Guilherme Mendes de Sousa - CB3030857
    | Nome: Stiven Richardy Silva Rodrigues - CB3030202
    | Turma: ADS 471
    | 
    | Opções no seletor:
    | 0. Sair
    | 1. Cadastrar veículo
    | 2. Cadastrar garagem
    | 3. Iniciar jornada
    | 4. Encerrar jornada
    | 5. Liberar viagem de uma determinada origem para um determinado destino
    | 6. Listar veículos em determinada garagem (informando a quantidade de veículos e seu potencial de transporte)
    | 7. Informar quantidade de viagens efetuadas de uma determinada origem para um determinado destino
    | 8. Listar viagens efetuadas de uma determinada origem para um determinado destino
    | 9. Informar quantidade de passageiros transportados de uma determinada origem para um determinado destino
    */
    internal class Program
    {
        public static Fretadora fretadora = SeedFretadora();
        public static Aeroporto destino = fretadora.Destinos[0];
        public static Aeroporto origem = fretadora.Destinos[1];
        static void Main(string[] args)
        {
            int seletor = -1;
            while (seletor != 0)
            {
                Console.Clear();
                Utils.Titulo("PAINEL PRINCIPAL");
                Console.WriteLine(" 0 - Sair\n" +
                    " 1 - Cadastrar Veiculo\n" +
                    " 2 - Cadastrar Destino\n" +
                    " 3 - Iniciar Jornada\n" +
                    " 4 - Encerrar Jornada\n" +
                    " 5 - Liberar Viagem\n" +
                    " 6 - Listar Veiculos em um Destino\n" +
                    " 7 - Quantidade de Viagens de determinada Origem e Destino\n" +
                    " 8 - Listar Viagens de determinada Origem e Destino\n" +
                    " 9 - Quantidade de Passageiros Transportados de determinada Origem e Destino\n");
                Console.WriteLine(new string('-', 70));
                Console.Write(" Escolha uma opção: ");
                seletor = Utils.lerInt(Console.ReadLine(), 0, " Entrada inválida!\n  Digite outro número: ");

                switch (seletor)
                {
                    case 0:
                        Console.WriteLine(" Programa finalizado!");
                        break;
                    case 1:
                        //CadastrarVeiculo();
                        break;
                    case 2:
                        //CadastrarDestino();
                        break;
                    case 3:
                        //IniciarJornada();
                        break;
                    case 4:
                        //EncerrarJornada();
                        break;
                    case 5:
                        //LiberarViagem();
                        break;
                    case 6:
                        //ListarVeiculos();
                        break;
                    case 7:
                        //CountViagens();
                        break;
                    case 8:
                        //ListarViagens();
                        break;
                    case 9:
                        //CountPassageiros();
                        break;
                    default:
                        Utils.MensagemErro("Digite um número de 0-11!");
                        break;
                }
                
            }
        }
        static Fretadora SeedFretadora()
        {
            string nome = "GuiVen";
            Aeroporto destino1 = new Aeroporto(1, "Congonhas");
            Aeroporto destino2 = new Aeroporto(2, "Congonhas");
            List<Aeroporto> destinos = new List<Aeroporto>([destino1, destino2]);
            Stack<Veiculo> veiculos = new Stack<Veiculo>();
            for (int ii = 0; ii < 8; ii++)
            {
                Veiculo veiculo = new Veiculo($"Veiculo {ii + 1}", 15);
                veiculos.Push(veiculo);
            }
            Fretadora fretadora = new Fretadora(nome, destinos, veiculos);
            return fretadora;
        }
    }
}
