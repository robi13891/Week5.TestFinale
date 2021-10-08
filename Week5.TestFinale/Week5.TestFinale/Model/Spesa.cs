using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5.TestFinale.Model
{
    public class Spesa
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public string Descrizione { get; set; }
        public string Utente { get; set; }
        public decimal Importo { get; set; }
        public bool Approvato { get; set; }

        public Spesa()
        {

        }

        public Spesa(int categoriaId, DateTime data, string descrizione, string utente, decimal importo)
        {
            CategoriaId = categoriaId;
            string nome;
            if (categoriaId == 1) nome = "Alloggio";
            else if (categoriaId == 2) nome = "Alimentari";
            else if (categoriaId == 3) nome = "Mediche";
            else if (CategoriaId == 4) nome = "Attrezzatura";
            else nome = "Altro";
            Categoria = new Categoria(categoriaId,nome);
            Data = data;
            Descrizione = descrizione;
            Utente = utente;
            Importo = importo;
            Approvato = false;
        }

        
    }

    
}
