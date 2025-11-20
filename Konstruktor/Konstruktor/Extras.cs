using Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Konstruktor
{
    public class Extra
    {
        public static string ExtrasSelection(MyPc mypc)
        {
            string jsonTextExtra = File.ReadAllText("extras.json");
            JsonArray Extrasarray = JsonNode.Parse(jsonTextExtra).AsArray();
            int anzahlextras = Extrasarray.Count;
            List<Extras>? extras = JsonSerializer.Deserialize<List<Extras>>(jsonTextExtra);
            int i = 1;


            Console.WriteLine("Extras");
            Console.WriteLine();
            foreach (var extrass in extras)
            {
                Console.WriteLine($"({i}) {extrass.Name} | Durchmesser: {extrass.Description} | Preis: {extrass.Price} Euro");
                Console.WriteLine();
                i++;
            }

            int pick = 0;
            bool success = false;

            do
            {
                if (success == false)
                {
                    Console.WriteLine("Auswahl Extras: ");
                    int.TryParse((Console.ReadLine()), out pick);

                    if (pick == 0)
                    {
                        Console.WriteLine("ungültige Zahl. Nochmal auswählen.");
                    }

                    else if (pick <= anzahlextras)
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
            mypc.Extras = extras[actualpick];
            Console.WriteLine($"{extras[actualpick].Name} wurde als RAM gewählt.");

            Console.WriteLine("Drücken sie eine Taste, um zum nächsten Punkt zu springen.");
            Console.ReadKey();

            return mypc.Extras.Name;
        }
    }
    public class Extras                                         ///Die zubuchbaren Extras
    {
        public string Name { get; set; }                //RGB-Module, Verkabelungen
        public string Description { get; set; }
        public float Price { get; set; }
        public string[] Categories { get; set; }
    }
}
