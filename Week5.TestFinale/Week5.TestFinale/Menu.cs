using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5.TestFinale
{
    public class Menu
    {
        public static void Start()
        {
            bool quit = false;
            do
            {
                Console.Clear();
                Console.WriteLine("MENU GESTIONE SPESE\n");
                Console.WriteLine("[1] Inserimento nuova Spesa (EF)\n" +
                    "[2] Inserimento nuova Spesa (ADO.NET)\n" +
                    "[3] Approva Spese esistenti\n" +
                    "[4] Cancellare Spese esistenti tramite Id\n" +
                    "[5] Visualizzare Spese Approvate\n" +
                    "[6] Visualizzare Spese di un Utente\n" +
                    "[7] Visualizza totale Spese per Categoria\n" +
                    "[8] Esci dal menu\n");
                Console.Write(">> ");
                bool isInt = int.TryParse(Console.ReadLine(), out int index);
                while (!isInt)
                {
                    Console.WriteLine("Inserimento non valido");
                    Console.Write(">> ");
                }
                switch (index)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("NUOVA SPESA (EF)\n");
                        SpesaManager.InserisciNuovaSpesaEF();
                        Console.WriteLine("\n\nPremi un tasto qualsiasi per tornare al menu..");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("NUOVA SPESA (ADO.NET)\n");
                        SpesaManager.InserisciNuovaSpesaADO();
                        Console.WriteLine("\n\nPremi un tasto qualsiasi per tornare al menu..");
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("APPROVAZIONE SPESE\n");
                        SpesaManager.ApprovaSpeseEsistenti();                        
                        Console.WriteLine("\n\nPremi un tasto qualsiasi per tornare al menu..");
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("ELIMINAZIONE SPESE\n");
                        SpesaManager.EliminaSpesa();
                        Console.WriteLine("\n\nPremi un tasto qualsiasi per tornare al menu..");
                        Console.ReadLine();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("ELENCO SPESE APPROVATE\n");
                        SpesaManager.ElencoSpeseApprovate();
                        Console.WriteLine("\n\nPremi un tasto qualsiasi per tornare al menu..");
                        Console.ReadLine();
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("ELENCO SPESE PER UTENTE\n");
                        SpesaManager.ElencoSpesePerUtente();
                        Console.WriteLine("\n\nPremi un tasto qualsiasi per tornare al menu..");
                        Console.ReadLine();
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("TOTALE SPESE PER CATEGORIA\n");
                        SpesaManager.TotaleSpesePerCategoria();
                        Console.WriteLine("\n\nPremi un tasto qualsiasi per tornare al menu..");
                        Console.ReadLine();
                        break;
                    case 8:
                        quit = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Scelta non valida");
                        Console.WriteLine("Premi un tasto qualsiasi per tornare al menu..");
                        Console.ReadLine();
                        break;
                }
            } while (!quit);

        }
    }
}