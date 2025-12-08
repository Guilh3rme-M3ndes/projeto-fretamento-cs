using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_fretamento
{
    internal class Garagem
    {
        private string id;
        private int capacidade;
        private Stack<Veiculo> veiculos;

        public string Id { get { return id; } }
        public int Capacidade { get { return capacidade; } }
        public Stack<Veiculo> Veiculos { get { return veiculos; } }

        public Garagem(string id, int capacidade)
        {
            this.id = id;
            this.capacidade = capacidade;
            this.veiculos = new Stack<Veiculo>();
        }

        public override string ToString()
        {
            string saida = new string('-', 15) + "\n";
            foreach(Veiculo v in veiculos)
            {
                saida += v.ToString() + new string('-', 15) + "\n";
            }
            return saida + $"Total de veiculos: {Veiculos.Count}";
        }
        public bool Estacionar(Garagem origem)
        {
            //Verificar se a origem tem veiculos la fora
            Veiculo veiculo = origem.Veiculos.Pop(); 
            bool estacionou = false;

            if (veiculos.Count < capacidade)
            {
                veiculos.Push(veiculo);
                estacionou = true;
            }
            else
            {
                //Utils.MensagemErro(veiculo == null ? "Veiculo não existe" : "Garagem cheia");
            }
            return estacionou;
        }
        public Veiculo PesquisarVeiculo(string id)
        {
            return veiculos.First(v => v.Id == id);
        }
        public bool Desestacionar(Garagem destino)
        {
            //Verificar se o destino está cheio do lado de fora
            int qtd = Veiculos.Count();
            if (Veiculos.Count > 0) 
            {
                destino.Veiculos.Push(veiculos.Pop());
                destino.Veiculos.Peek().Viagens++;
            }
            else
            {
                //Utils.MensagemErro(!veiculoPertence? "Veiculo não está na garagem" : "Existem veiculos a frente");
            }
            return qtd > 0;
        }
    }
}
