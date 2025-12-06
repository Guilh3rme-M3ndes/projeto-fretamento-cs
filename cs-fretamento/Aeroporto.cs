using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_fretamento
{
    internal class Aeroporto
    {
        private int id;
        private string nome;
        private List<Garagem> garagens;

        public int Id { get { return id; } }
        public string Nome { get { return nome; } set { this.nome = value; } }
        public List<Garagem> Garagens { get { return garagens; } set { garagens = value; } }

        public Aeroporto(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
            garagens = new List<Garagem>();
        }

        public void AdicionarGaragem(Garagem garagem)
        {
            Garagens.Add(garagem);
        }

    }
}
