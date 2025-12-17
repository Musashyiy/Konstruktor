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
    public class AirCooling
    {
        public static void AirCoolingsSelection(MyPc mypc)
        {
            string jsonTextCoolingair = File.ReadAllText("json/coolingsair.json");
            JsonArray coolingairsarray = JsonNode.Parse(jsonTextCoolingair).AsArray();
            int anzahlcoolingair = coolingairsarray.Count;
            List<CoolingBlueprint>? coolingsair = JsonSerializer.Deserialize<List<CoolingBlueprint>>(jsonTextCoolingair);

            int i = 1;
                     
            Console.WriteLine("Luft-Kühlung");
            Console.WriteLine();

            foreach (var coolingss in coolingsair)
            {
                Console.WriteLine($"({i}) {coolingss.Name} | Form: {coolingss.Form} | Sockelkompartibilität: {string.Join(", ", coolingss.Sockets)} | Maße: Höhe {coolingss.Height}cm x Breite {coolingss.Width}cm x Länge {coolingss.Lenght}cm | Preis: {coolingss.Price}€");
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

                    else if (pick <= anzahlcoolingair)
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
            
            mypc.Coolings = coolingsair[actualpick];
            Console.WriteLine($"{coolingsair[actualpick].Name} wurde als Kühlung ausgewählt.");

            Console.WriteLine("Drücken sie eine Taste, um zum nächsten Punkt zu springen.");
            Console.ReadKey();            
        }        
    } 
}

