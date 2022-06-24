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
            Functions.GetEstructuras();
        }

    }

    static class Functions
    {
        public static void GetEstructuras()
        {
            var url = $"https://age-of-empires-2-api.herokuapp.com/api/v1/structures";
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

                            foreach (Structure Struc in Lista.structures)
                            {
                                Console.WriteLine("[" + Struc.id + "] " + Struc.name + ": " + Struc.description);
                            }

                            ShowEstructuras(Lista);
                            
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("No se pudo acceder a la API...");
            }
        }

        private static void ShowEstructuras(Root Lista)
        {
            Console.WriteLine("\n - Elija una Strucilizacion (id):");
            int? IdStruc = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(" [" + Lista.structures.Find(x => x.id == IdStruc).id + "] " + Lista.structures.Find(x => x.id == IdStruc).name + ":\n     " + Lista.structures.Find(x => x.id == IdStruc).expansion + "\n     " + Lista.structures.Find(x => x.id == IdStruc).age + "\n     " + Lista.structures.Find(x => x.id == IdStruc).build_time + "\n     " + Lista.structures.Find(x => x.id == IdStruc).hit_points + "\n     " + Lista.structures.Find(x => x.id == IdStruc).line_of_sight );
            

        }
    }
    
}