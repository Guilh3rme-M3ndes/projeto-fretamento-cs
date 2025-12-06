using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_fretamento
{
    internal class Veiculo
    {
        private string id;
        private int capacidade;
        private int viagens;

        public int Capacidade { get { return capacidade; } set { capacidade = value; }}
        public string Id { get { return id; } }
        public int Viagens { get => viagens; set => viagens = value; }
        public Veiculo (string id, int capacidade)
        {
            this.viagens = 0;
            this.id = id;
            Capacidade = capacidade;
        }

        public override string ToString()
        {
            return $"\nVeiculo: {Id} \nCapacidade: {capacidade} \n";
        }

    }
}
