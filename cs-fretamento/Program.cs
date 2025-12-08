
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
    | 2. Cadastrar destino
    | 3. Cadastrar garagem
    | 4. Iniciar jornada
    | 5. Encerrar jornada
    | 6. Liberar viagem de uma determinada origem para um determinado destino
    | 7. Listar veículos em determinada garagem (informando a quantidade de veículos e seu potencial de transporte)
    | 8. Informar quantidade de viagens efetuadas de uma determinada origem para um determinado destino
    | 9. Listar viagens efetuadas de uma determinada origem para um determinado destino
    | 10. Informar quantidade de passageiros transportados de uma determinada origem para um determinado destino
    */
    internal class Program
    {
        public static Fretadora fretadora = SeedFretadora();
        public static Aeroporto destinoAtual;
        public static Aeroporto origemAtual;
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
                    " 3 - Cadastrar Garagem\n" +
                    " 4 - Iniciar Jornada\n" +
                    " 5 - Encerrar Jornada\n" +
                    " 6 - Liberar Viagem\n" +
                    " 7 - Listar Veiculos em um Destino\n" +
                    " 8 - Quantidade de Viagens de determinada Origem e Destino\n" +
                    " 9 - Listar Viagens de determinada Origem e Destino\n" +
                    " 10 - Quantidade de Passageiros Transportados de determinada Origem e Destino\n");
                Console.WriteLine(new string('-', 70));
                Console.Write(" Escolha uma opção: ");
                seletor = Utils.lerInt(Console.ReadLine(), 0, " Entrada inválida!\n  Digite outro número: ");

                switch (seletor)
                {
                    case 0:
                        Console.WriteLine(" Programa finalizado!");
                        break;
                    case 1:
                        CadastrarVeiculo();
                        break;
                    case 2:
                        CadastrarDestino();
                        break;
                    case 3:
                        CadastrarGaragem();
                        break;
                    case 4:
                        IniciarJornada();
                        break;
                    case 5:
                        EncerrarJornada();
                        break;
                    case 6:
                        LiberarViagem();
                        break;
                    case 7:
                        ListarVeiculos();
                        break;
                    case 8:
                        CountViagens();
                        break;
                    case 9:
                        ListarViagens();
                        break;
                    case 10:
                        CountPassageiros();
                        break;
                    default:
                        Utils.MensagemErro("Digite um número de 0-10!");
                        break;
                }
                
            }
        }
        static Fretadora SeedFretadora()
        {
            string nome = "GuiVen";
            Aeroporto destino1 = new Aeroporto(1, "Congonhas");
            Aeroporto destino2 = new Aeroporto(2, "Guarulhos");
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
        static void CadastrarVeiculo()
        {
            Utils.Titulo("CADASTRAR VEICULO");
            if (!fretadora.EmJornada)
            {
                Console.Write("Informe a Identificação do veículo: ");
                string id = Console.ReadLine();
                Veiculo veiculoPesquisado = fretadora.Veiculos.FirstOrDefault(v => v.Id == id);
                if (veiculoPesquisado == null)
                {
                    Console.Write("Informe a capacidade: ");
                    int capacidade = Utils.lerInt(Console.ReadLine(), 1, "Capacidade inválida! Digite a capacidade: ");
                    Veiculo veiculo = new Veiculo(id, capacidade);
                    fretadora.CadastrarVeiculo(veiculo);
                    Utils.MensagemSucesso("Veiculo cadastrado com sucesso");
                }
                else
                {
                    Utils.MensagemErro("Veiculo já cadastrado!");
                }
            }
            else
                Utils.MensagemErro("Cadastro bloqueado, jornada diaria em andamento.");

        }
        static void CadastrarDestino()
        {
            Utils.Titulo("CADASTRAR DESTINO");
            if (!fretadora.EmJornada) 
            {
                Console.Write("Informe o nome do destino: ");
                string nome = Console.ReadLine();
                Aeroporto aeroPesquisado = fretadora.Destinos.FirstOrDefault(a => a.Nome == nome);
                if (aeroPesquisado == null)
                {
                    Aeroporto destino = new Aeroporto(fretadora.Destinos.Count, nome);
                    fretadora.CadastrarDestino(destino);
                    Utils.MensagemSucesso($"Destino cadastrado com sucesso (garagem inicial: {destino.Garagens[0].Id}");
                }
                else
                {
                    Utils.MensagemErro("Destino já cadastrado!");
                }
            }
            else
                Utils.MensagemErro("Cadastro bloqueado, jornada diaria em andamento.");

        }
        static void CadastrarGaragem()
        {
            Utils.Titulo("CADASTRAR GARAGEM");
            if (!fretadora.EmJornada)
            {
                Console.Write("Informe o destino: ");
                string nomeDestino = Console.ReadLine();
                Aeroporto destinoPesquisado = fretadora.Destinos.Find(d => d.Nome == nomeDestino);
                if (destinoPesquisado != null)
                {
                    Console.Write(" Informe a identificação da garagem: ");
                    string nomeGaragem = Console.ReadLine();
                    Garagem garagemPesquisada = destinoPesquisado.Garagens.Find(g => g.Id == nomeGaragem);
                    if (garagemPesquisada == null)
                    {
                        Console.Write("Informe a capacidade: ");
                        int capacidade = Utils.lerInt(Console.ReadLine(), 1, "Capacidade inválida. Informe a capacidade: ");
                        Garagem garagem = new Garagem(nomeGaragem, capacidade);
                        fretadora.CadastrarGaragem(destinoPesquisado, garagem);
                        Utils.MensagemSucesso(" Garagem cadastrada! ");
                    }
                    else
                    {
                        Utils.MensagemErro("Garagem já existe");
                    }
                }
                else
                {
                    Utils.MensagemErro("Destino não encontrado");
                }
            }
            else
                Utils.MensagemErro("Cadastro bloqueado, jornada diaria em andamento.");

        }
        static void IniciarJornada()
        {
            Utils.Titulo("INICIAR JORNADA");
            if (fretadora.EmJornada)
            {
                Utils.MensagemErro("É necessário finalizar a jornada atual!");
            }
            else
            {
                Console.WriteLine("Destinos disponíveis: ");
                fretadora.Destinos.ForEach(destino => { Console.WriteLine(destino.Nome); });
                Console.WriteLine(new string('-', 15));
                Console.Write("Informe a origem: ");
                string nomeOrigem = Console.ReadLine();
                if (fretadora.Destinos.Any(d => d.Nome == nomeOrigem))
                {
                    Aeroporto origem = fretadora.getDestino(nomeOrigem);
                    Console.Write("Informe o destino: ");
                    string nomeDestino = Console.ReadLine();
                    if (nomeDestino != nomeOrigem && fretadora.Destinos.Any(d => d.Nome == nomeDestino))
                    {
                        Aeroporto destino = fretadora.getDestino(nomeDestino);
                        destinoAtual = destino;
                        origemAtual = origem;
                        fretadora.IniciarJornada(destino, origem);
                        Utils.MensagemSucesso($"Jornada iniciada!: de {nomeOrigem} à {nomeDestino}");
                    }
                    else
                        Utils.MensagemErro("Nenhum destino encontrado");
                }
                else
                    Utils.MensagemErro("Nenhum destino encontrado.");
            }
        }
        static void EncerrarJornada()
        {
            Utils.Titulo("FINALIZAR JORNADA");
            if (fretadora.EmJornada)
            {
                fretadora.EncerrarJornada(origemAtual, destinoAtual);
                destinoAtual = new Aeroporto();
                origemAtual = new Aeroporto();
                Utils.MensagemSucesso("Jornada encerrada!");
            }
            else
                Utils.MensagemErro("Nenhuma jornada para finalizar!");
        }
        static void LiberarViagem()
        {
            Utils.Titulo("LIBERAR VIAGEM");
            Console.Write("Informe a origem: ");
            string nomeOrigem = Console.ReadLine();
            Aeroporto origem = fretadora.getDestino(nomeOrigem);
            if (origem != null)
            {
                int qtVeiculosOrigem = 0;
                origem.Garagens.ForEach(g => { qtVeiculosOrigem += g.Veiculos.Count; });
                if (qtVeiculosOrigem > 0)
                {
                    Console.Write("Informe o destino: ");
                    string nomeDestino = Console.ReadLine();
                    Aeroporto destino = fretadora.getDestino(nomeDestino);
                    if (destino != null)
                    {
                        bool temVaga = destino.Garagens.Any(g => g.Veiculos.Count < g.Capacidade);
                        if (temVaga)
                        {
                            fretadora.LiberarViagem(origem, destino);
                            Utils.MensagemSucesso("Viagem liberada com sucesso!");
                        }
                        else
                            Utils.MensagemErro("Todas as garagens do destino estão cheias");
                    }
                    else
                        Utils.MensagemErro("Destino não encontrado");
                }
                else
                    Utils.MensagemErro("Nenhum veículo disponível");
            }
            else
                Utils.MensagemErro("Local de origem não encontrado!");
        }
        static void ListarVeiculos()
        {
            Utils.Titulo("LISTAR VEICULOS");
            Console.Write("Informe o destino: ");
            string nomeDestino = Console.ReadLine();
            Aeroporto destino = fretadora.getDestino(nomeDestino);
            if (destino != null)
            {
                Console.WriteLine("Garagens do destino: ");
                destino.Garagens.ForEach(g => Console.WriteLine(g.Id));
                Console.WriteLine(new string('-', 15));
                Console.Write("Informe a garagem: ");
                string idGaragem = Console.ReadLine();
                Garagem garagem = destino.Garagens.Find(g => g.Id == idGaragem);
                if (garagem != null)
                {
                    Console.WriteLine(garagem.Veiculos.Count > 0 ? garagem.ToString() : "Nenhum veículo na garagem");
                    Utils.MensagemSucesso("Fim da listagem");
                }
                else
                    Utils.MensagemErro("Garagem não encontrada");

            }
            else
                Utils.MensagemErro("Destino não encontrado");
        }
        static void CountViagens()
        {
            Utils.Titulo("CONTAGEM DE VIAGENS");
            Console.Write("Informe a origem: ");
            string nomeOrigem = Console.ReadLine();
            Aeroporto origem = fretadora.getDestino(nomeOrigem);
            if (origem != null)
            {
                Console.Write("Informe o destino: ");
                string nomeDestino = Console.ReadLine();
                Aeroporto destino = fretadora.getDestino(nomeDestino);
                if (destino != null)
                {
                    int qtdViagens = fretadora.CountViagens(origem, destino);
                    Utils.MensagemSucesso(qtdViagens > 0 ? $"{qtdViagens} viagens realizadas de {origem.Nome} à {destino.Nome}" : $"Nenhuma viagem registrada de {origem.Nome} à {destino.Nome}");
                }
                else
                    Utils.MensagemErro("Destino não encontrado");
            }
            else
                Utils.MensagemErro("Origem não encontrada");
        }

        static void ListarViagens()
        {
            Utils.Titulo("LISTAGEM DE VIAGENS");
            Console.Write("Informe a origem: ");
            string nomeOrigem = Console.ReadLine();
            Aeroporto origem = fretadora.getDestino(nomeOrigem);
            if (origem != null)
            {
                Console.Write("Informe o destino: ");
                string nomeDestino = Console.ReadLine();
                Aeroporto destino = fretadora.getDestino(nomeDestino);
                if (destino != null)
                {
                    int qtdViagens = fretadora.CountViagens(origem, destino);
                    string listagem = "";
                    fretadora.Viagens.ForEach(v => 
                    { 
                        if (v.Destino.Nome == nomeDestino && v.Origem.Nome == nomeOrigem) 
                        { 
                            listagem += v.ToString(); 
                        } 
                    });
                    Utils.MensagemSucesso(qtdViagens > 0 ? $"{listagem}" : $"Nenhuma viagem registrada de {origem.Nome} à {destino.Nome}");
                }
                else
                    Utils.MensagemErro("Destino não encontrado");
            }
            else
                Utils.MensagemErro("Origem não encontrada");
        }
        static void CountPassageiros()
        {
            Utils.Titulo("CONTAGEM DE PASSAGEIROS");
            Console.Write("Informe a origem: ");
            string nomeOrigem = Console.ReadLine();
            Aeroporto origem = fretadora.getDestino(nomeOrigem);
            if (origem != null)
            {
                Console.Write("Informe o destino: ");
                string nomeDestino = Console.ReadLine();
                Aeroporto destino = fretadora.getDestino(nomeDestino);
                if (destino != null)
                {
                    int qtdPassageiros = 0;
                    fretadora.Viagens.ForEach(v =>
                    {
                        if (v.Destino.Nome == nomeDestino && v.Origem.Nome == nomeOrigem)
                        {
                            qtdPassageiros += v.QtdPassageiros;
                        }
                    });
                    Utils.MensagemSucesso(qtdPassageiros > 0 ? $"{qtdPassageiros} transportados de {origem.Nome} à {destino.Nome}" : $"Nenhuma passageiro transportado de {origem.Nome} à {destino.Nome}");
                }
                else
                    Utils.MensagemErro("Destino não encontrado");
            }
            else
                Utils.MensagemErro("Origem não encontrada");
        }
    }

}
