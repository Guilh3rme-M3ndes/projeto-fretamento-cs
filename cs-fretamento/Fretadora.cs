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
        
        public string Nome { get => nome; set => nome = value; }
        public List<Aeroporto> Destinos { get => destinos; set => destinos = value; }
        public Stack<Veiculo> Veiculos {  get => veiculos; set => veiculos = value; }

        public List<Viagem> Viagens { get => viagens; set => viagens = value; }

        public Fretadora(string nome, List<Aeroporto> destinos, Stack<Veiculo> veiculos)
        {
            this.nome = nome;
            this.destinos = destinos;
            this.veiculos = veiculos;
            this.viagens = new List<Viagem>();
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
                indGaragem = indGaragem == garagens.Count? 0 : indGaragem + 1;
            }
        }
        public void EncerrarJornada(Aeroporto destino)
        {
            foreach (Garagem g in destino.Garagens)
            {
                while (g.Veiculos.Count > 0)
                {
                    veiculos.Push(g.Veiculos.Pop());
                }
            }
        }
        public void LiberarViagem(Aeroporto origem, Aeroporto destino)
        {
            Garagem garagemDestino = destino.Garagens.OrderBy(g => g.Veiculos.Count).First();
            garagemDestino.Veiculos.Push(veiculos.Pop());
            Veiculo veiculoUtilizado = garagemDestino.Veiculos.Peek();
            Viagem viagem = new Viagem(viagens.Count, destino, origem, veiculoUtilizado.Capacidade);

        }

        public void CadastrarVeiculo(Veiculo veiculo)
        {
            veiculos.Push(veiculo);
        }

        public void CadastrarGaragem(Aeroporto aeroporto, Garagem garagem)
        {
            aeroporto.Garagens.Add(garagem);
        }
    }
}
