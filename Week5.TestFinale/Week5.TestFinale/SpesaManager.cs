using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5.TestFinale.EF;
using Week5.TestFinale.Model;

namespace Week5.TestFinale
{
    public class SpesaManager
    {

        public static Spesa AcquisizioneDatiSpesa()
        {
            Console.WriteLine("1 --> Alloggio\n" +
                    "2 --> Alimentari\n" +
                    "3 --> Mediche\n" +
                    "4 --> Attrezzatura\n" +
                    "5 --> Altro\n");
            Console.Write("Categoria: ");
            bool isCorrect = int.TryParse(Console.ReadLine(), out int categoriaId);
            while (!(isCorrect && categoriaId >= 1 && categoriaId <= 5))
            {
                Console.WriteLine("Inserimento non valido");
                Console.Write("Categoria: ");
                isCorrect = int.TryParse(Console.ReadLine(), out categoriaId);
            }

            Console.Write("Data (yyyy-mm-dd): ");
            DateTime data = DateTime.Parse(Console.ReadLine());

            Console.Write("Descrizione: ");
            string descrizione = Console.ReadLine();
            while (string.IsNullOrEmpty(descrizione))
            {
                Console.WriteLine("Inserimento non valido");
                Console.Write("Descrizione: ");
                descrizione = Console.ReadLine();
            }

            Console.Write("Utente: ");
            string utente = Console.ReadLine();
            while (string.IsNullOrEmpty(utente))
            {
                Console.WriteLine("Inserimento non valido");
                Console.Write("Utente: ");
                utente = Console.ReadLine();
            }

            Console.Write("Importo: ");
            bool isOk = decimal.TryParse(Console.ReadLine(), out decimal importo);
            while (!(isOk && importo >= 0))
            {
                Console.WriteLine("Inserimento non valido");
                Console.Write("Importo: ");
                isCorrect = decimal.TryParse(Console.ReadLine(), out importo);
            }

            Spesa spesa = new Spesa(categoriaId, data, descrizione, utente, importo);

            return spesa;
        }

        public static void StampaSpese()
        {
            GestioneSpeseContext ctx = new GestioneSpeseContext();

            Console.WriteLine("{0,5}{1,40}{2,20}{3,20}{4,20}", "ID", "Descrizione", "Importo",
                "Utente", "Categoria");
            Console.WriteLine(new String('-', 105));
            foreach (var s in ctx.Spesa.Include(s => s.Categoria))
            {
                Console.WriteLine($"[{s.Id,5}]{s.Descrizione,40}{s.Importo,20}{s.Utente,20}" +
                    $"{s.Categoria.Nome,20}");
            }
            Console.WriteLine(new String('-', 105));
        }

        public static void InserisciNuovaSpesaEF()
        {
            GestioneSpeseContext ctx = new GestioneSpeseContext();

            try
            {
                Spesa spesa = AcquisizioneDatiSpesa();

                ctx.Spesa.Add(spesa);
                ctx.SaveChanges();

                Console.WriteLine("\nInserimento avvenuto con successo");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void InserisciNuovaSpesaADO()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
            string connectionStringSQL = config.GetConnectionString("AcademyG");
            SqlConnection conn = new SqlConnection(connectionStringSQL);

            try
            {
                conn.Open();

                Spesa spesa = AcquisizioneDatiSpesa();

                SqlCommand insertCommand = new SqlCommand();
                insertCommand.CommandText = "insert into spesa values" +
                 "(@data,@categoriaId,@descrizione,@utente,@importo,@approvato)";
                insertCommand.Connection = conn;
                insertCommand.CommandType = System.Data.CommandType.Text;

                insertCommand.Parameters.AddWithValue("@data", spesa.Data);
                insertCommand.Parameters.AddWithValue("@categoriaId", spesa.CategoriaId);
                insertCommand.Parameters.AddWithValue("@descrizione", spesa.Descrizione);
                insertCommand.Parameters.AddWithValue("@utente", spesa.Utente);
                insertCommand.Parameters.AddWithValue("@importo", spesa.Importo);
                insertCommand.Parameters.AddWithValue("@approvato", spesa.Approvato);

                int result = insertCommand.ExecuteNonQuery();

                if (result == 1) Console.WriteLine("Inserimento avvenuto con successo");
                else Console.WriteLine("Inserimento non riuscito");

            }
            catch (SqlException sqlex)
            {
                Console.WriteLine(sqlex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        public static void ApprovaSpeseEsistenti()
        {
            GestioneSpeseContext ctx = new GestioneSpeseContext();

            Console.WriteLine("{0,5}{1,40}{2,20}{3,20}{4,20}", "ID", "Descrizione", "Importo",
                 "Utente", "Categoria");
            Console.WriteLine(new String('-', 105));
            foreach (var s in ctx.Spesa.Include(s => s.Categoria).Where(s => s.Approvato == false))
            {
                Console.WriteLine($"[{s.Id,5}]{s.Descrizione,40}{s.Importo,20}{s.Utente,20}" +
                    $"{s.Categoria.Nome,20}");
            }
            Console.WriteLine(new String('-', 105));

            Console.Write("\nId Spesa da approvare: ");
            int idSpesaDaApprovare = int.Parse(Console.ReadLine());
            var spesaDaApprovare = ctx.Spesa.Find(idSpesaDaApprovare);
            if (spesaDaApprovare != null)
            {
                spesaDaApprovare.Approvato = true;
                ctx.Spesa.Update(spesaDaApprovare);
                ctx.SaveChanges();
                Console.WriteLine("Approvazione avvunuta con successo");
            }
            else Console.WriteLine("Ooops.. Approvazione non riuscita");


        }

        public static void EliminaSpesa()
        {
            GestioneSpeseContext ctx = new GestioneSpeseContext();

            StampaSpese();

            Console.Write("\nId Spesa da cancellare: ");
            int idSpesaDaCancellare = int.Parse(Console.ReadLine());
            var spesaDaCancellare = ctx.Spesa.Find(idSpesaDaCancellare);
            if (spesaDaCancellare != null)
            {
                ctx.Spesa.Remove(spesaDaCancellare);
                ctx.SaveChanges();
                Console.WriteLine("Eliminazione avvunuta con successo");
            }
            else Console.WriteLine("Ooops.. Eliminazione non riuscita");

        }

        public static void ElencoSpeseApprovate()
        {
            GestioneSpeseContext ctx = new GestioneSpeseContext();

            Console.WriteLine("{0,5}{1,40}{2,20}{3,20}{4,20}", "ID", "Descrizione", "Importo",
                  "Utente", "Categoria");
            Console.WriteLine(new String('-', 105));
            foreach (var s in ctx.Spesa.Include(s => s.Categoria).Where(s => s.Approvato == true))
            {
                Console.WriteLine($"[{s.Id,5}]{s.Descrizione,40}{s.Importo,20}{s.Utente,20}" +
                    $"{s.Categoria.Nome,20}");
            }
            Console.WriteLine(new String('-', 105));
        }

        public static void ElencoSpesePerUtente()
        {
            GestioneSpeseContext ctx = new GestioneSpeseContext();
            Console.Write("Utente: ");
            string utente = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("{0,5}{1,40}{2,20}{3,20}{4,20}", "ID", "Descrizione", "Importo",
                 "Utente", "Categoria");
            Console.WriteLine(new String('-', 105));
            foreach (var s in ctx.Spesa.Include(s => s.Categoria).Where(s => s.Utente == utente))
            {
                Console.WriteLine($"[{s.Id,5}]{s.Descrizione,40}{s.Importo,20}{s.Utente,20}" +
                    $"{s.Categoria.Nome,20}");
            }
            Console.WriteLine(new String('-', 105));
          
        }

        public static void TotaleSpesePerCategoria()
        {
            GestioneSpeseContext ctx = new GestioneSpeseContext();
         
            Console.WriteLine("{0,20}{1,20}", "Categoria", "# Spese");
            Console.WriteLine(new String('-', 40));
            foreach (var item in ctx.Categoria.Include(c => c.Spese))
            {
                Console.WriteLine($"{item.Nome,20} " +
                    $"{item.Spese.Count(),20}");
            }
            Console.WriteLine(new String('-', 40));


        }

    }
}
