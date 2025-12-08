using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_fretamento
{
    internal class Fretadora
    {
        private string nome;
        private List<Aeroporto> destinos;
        private Stack<Veiculo> veiculos;
        private List<Viagem> viagens;
        private bool emJornada;
        public string Nome { get => nome; set => nome = value; }
        public List<Aeroporto> Destinos { get => destinos; set => destinos = value; }
        public Stack<Veiculo> Veiculos {  get => veiculos; set => veiculos = value; }

        public List<Viagem> Viagens { get => viagens; set => viagens = value; }
        public bool EmJornada { get => emJornada; set => emJornada = value; }

        public Fretadora(string nome, List<Aeroporto> destinos, Stack<Veiculo> veiculos)
        {
            this.nome = nome;
            this.destinos = destinos;
            this.veiculos = veiculos;
            this.viagens = new List<Viagem>();
            this.emJornada = false;
        }

        public void IniciarJornada(Aeroporto destino, Aeroporto origem)
        {
            List<Garagem> garagens = new List<Garagem>();
            garagens.AddRange(origem.Garagens);
            garagens.AddRange(destino.Garagens);
            int indGaragem = 0;
            while (veiculos.Count > 0)
            {
                garagens[indGaragem].Veiculos.Push(veiculos.Pop());
                indGaragem = (indGaragem + 1) % garagens.Count;
            }
            this.EmJornada = true;
        }
        public void EncerrarJornada(Aeroporto origem, Aeroporto destino)
        {
            if (destino.Garagens.All(g => g.Veiculos.Count == 0))
            {
                Console.WriteLine("Todas as garagens do destino estão vazias. Nada a reportar");
            }
            else
            {
                List<Garagem> garagens = new List<Garagem>();
                garagens.AddRange(origem.Garagens);
                garagens.AddRange(destino.Garagens);
                foreach (Garagem g in garagens)
                {
                    if (g.Veiculos.Count == 0)
                    {
                        Console.WriteLine($"Garagem {g.Id} vazia, próxima!");
                    }
                    else
                    {
                        while (g.Veiculos.Count > 0)
                        {
                            Veiculo veiculo;
                            veiculos.Push(veiculo = g.Veiculos.Pop());
                            Console.WriteLine($"Retornando veiculo {veiculo.Id}. Passageiros transportados: {veiculo.Capacidade * veiculo.Viagens}");
                            veiculo.Viagens = 0;
                        }
                    }
                }
            }
            EmJornada = false;
        }
        public void LiberarViagem(Aeroporto origem, Aeroporto destino)
        {
            Garagem garagemDestino = destino.Garagens.OrderBy(g => g.Veiculos.Count).First();
            Garagem garagemOrigem = origem.Garagens.OrderByDescending(g => g.Veiculos.Count).First();
            garagemDestino.Veiculos.Push(garagemOrigem.Veiculos.Pop());
            Veiculo veiculoUtilizado = garagemDestino.Veiculos.Peek();
            veiculoUtilizado.Viagens++;
            Viagem viagem = new Viagem(viagens.Count, destino, origem, veiculoUtilizado.Capacidade);
            Viagens.Add(viagem);

        }

        public void CadastrarVeiculo(Veiculo veiculo)
        {
            veiculos.Push(veiculo);
        }
        public void CadastrarDestino(Aeroporto aeroporto)
        {
            destinos.Add(aeroporto);
        }
        public void CadastrarGaragem(Aeroporto aeroporto, Garagem garagem)
        {
            aeroporto.Garagens.Add(garagem);
        }
        public Aeroporto getDestino(string nomeDestino)
        {
            return Destinos.Find(d => d.Nome == nomeDestino);
        }

        public int CountViagens(Aeroporto origem, Aeroporto destino)
        {
            List<Viagem> viagens = Viagens.FindAll(v => v.Origem.Nome == origem.Nome && v.Destino.Nome == destino.Nome);
            return viagens.Count();
        }
    }
}
