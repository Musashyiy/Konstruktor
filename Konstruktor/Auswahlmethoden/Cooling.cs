using Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Konstruktor.Methoden
{
    public class Coolings
    {
        public static string CoolingsSelection(MyPc mypc)
        {
            string jsonTextCooling = File.ReadAllText("json/coolings.json");
            JsonArray coolingsarray = JsonNode.Parse(jsonTextCooling).AsArray();
            int anzahlcooling = coolingsarray.Count;
            List<Cooling>? coolings = JsonSerializer.Deserialize<List<Cooling>>(jsonTextCooling);
            int i = 1;


            Console.WriteLine("Coolings");
            Console.WriteLine();
            foreach (var coolingss in coolings)
            {
                Console.WriteLine($"({i}) {coolingss.Name} | Form: {coolingss.Form} | Sockelkompartibilität: {string.Join(", ", coolingss.Sockets)} | Preis: {coolingss.Price}€");
                Console.WriteLine();
                i++;
            }

            int pick = 0;
            bool success = false;

            do
            {
                if (success == false)
                {
                    Console.WriteLine("Auswahl Kühlung: ");
                    int.TryParse(Console.ReadLine(), out pick);

                    if (pick == 0)
                    {
                        Console.WriteLine("ungültige Zahl. Nochmal auswählen.");
                    }

                    else if (pick <= anzahlcooling)
                    {
                        success = true;
                    }

                    else
                    {
                        Console.WriteLine("ungültige Zahl. Nochmal auswählen.");
                    }
                }
            } while (success == false);

            int actualpick = pick - 1;
            mypc.Cooling = coolings[actualpick];
            Console.WriteLine($"{coolings[actualpick].Name} wurde als Kühlung ausgewählt.");

            Console.WriteLine("Drücken sie eine Taste, um zum nächsten Punkt zu springen.");
            Console.ReadKey();

            return mypc.Cooling.Name;
        }
    }
    public class Cooling                                        ///Die Blaupause für die verscheidenen Kühlungen
    {
        public string Name { get; set; }
        public string Form { get; set; }                //AiO, Aircolling....
        public float Price { get; set; }
        public List<string> Sockets { get; set; }
        public List<string> Categories { get; set; }
    }
}
