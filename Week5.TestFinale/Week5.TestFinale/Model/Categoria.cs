using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5.TestFinale.Model
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IList<Spesa> Spese { get; set; }

        public Categoria()
        {

        }

        public Categoria(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
