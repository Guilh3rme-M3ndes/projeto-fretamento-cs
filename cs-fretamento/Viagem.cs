using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_fretamento
{
    internal class Viagem
    {
        private int id;
        private Aeroporto destino, origem;
        private int qtdPassageiros;

        public int Id {  get { return id; } }
        public Aeroporto Destino { get => destino; set => destino = value; }
        public Aeroporto Origem { get => origem; set => origem = value; }
        public int QtdPassageiros { get => qtdPassageiros; }
        public Viagem(int id, Aeroporto destino, Aeroporto origem, int qtdPassageiros)
        {
            this.id = id;
            this.destino = destino;
            this.origem = origem;
            this.qtdPassageiros = qtdPassageiros;
        }
    }
}
