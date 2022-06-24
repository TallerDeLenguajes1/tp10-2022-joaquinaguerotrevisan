using System.Text.Json;
using System.IO;
using System.Net;
using System.Collections.Generic;

namespace TP10
{
    class Program
    {
        static void Main(string[] args)
        {
            Functions.GetCivilization();
        }

    }

    static class Functions
    {
        public static void GetCivilization()
        {
            var url = $"https://age-of-empires-2-api.herokuapp.com/api/v1/civilizations";
            var request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            Root Lista = new Root();

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;

                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            Lista = JsonSerializer.Deserialize<Root>(responseBody);

                            foreach (Civilization Civ in Lista.civilizations)
                            {
                                Console.WriteLine("[" + Civ.id + "] " + Civ.name);
                            }

                            ShowCivilization(Lista);
                            
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("No se pudo acceder a la API...");
            }
        }

        private static void ShowCivilization(Root Lista)
        {
            Console.WriteLine("\n - Elija una civilizacion (id):");
            int? IdCiv = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(" [" + Lista.civilizations.Find(x => x.id == IdCiv).id + "] " + Lista.civilizations.Find(x => x.id == IdCiv).name + ":\n     " + Lista.civilizations.Find(x => x.id == IdCiv).expansion + "\n     " + Lista.civilizations.Find(x => x.id == IdCiv).army_type + "\n     " + Lista.civilizations.Find(x => x.id == IdCiv).team_bonus );
            

        }
    }
    
}