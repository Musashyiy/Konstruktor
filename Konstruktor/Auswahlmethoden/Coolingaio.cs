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
    public class AioCoolings
    {
        public static void AioCoolingsSelection(MyPc mypc)
        {
            string jsonTextCoolingaio = File.ReadAllText("json/coolingsaio.json");
            JsonArray coolingsaioarray = JsonNode.Parse(jsonTextCoolingaio).AsArray();
            int anzahlcooling = coolingsaioarray.Count;
            List<CoolingBlueprint>? coolingsaio = JsonSerializer.Deserialize<List<CoolingBlueprint>>(jsonTextCoolingaio);
            int i = 1;

            Console.WriteLine("Coolings");
            Console.WriteLine();
            foreach (var coolingss in coolingsaio)
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
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("ungültige Zahl. Nochmal auswählen.");
                        Console.ResetColor();
                    }

                    else if (pick <= anzahlcooling)
                    {
                        success = true;
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("ungültige Zahl. Nochmal auswählen.");
                        Console.ResetColor();
                    }
                }
            } while (success == false);

            int actualpick = pick - 1;
            mypc.Coolings = coolingsaio[actualpick];
            Console.WriteLine($"{coolingsaio[actualpick].Name} wurde als Kühlung ausgewählt.");

            Console.WriteLine("Drücken sie eine Taste, um zum nächsten Punkt zu springen.");
            Console.ReadKey();                                  
        }        
    }

    public class CoolingBlueprint                                        ///Die Blaupause für die verscheidenen Kühlungen
    {
        public string Name { get; set; }
        public string Form { get; set; }                    //AiO, Aircolling....
        public float Price { get; set; }
        public List<string> Sockets { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public float Lenght { get; set; }
        public List<string> Categories { get; set; }
    }

}