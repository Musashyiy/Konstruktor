using Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Konstruktor.Methoden
{
    public class Extra
    {
        public static void ExtrasSelection(MyPc mypc)
        {
            string jsonTextExtra = File.ReadAllText("json/extras.json");
            JsonArray Extrasarray = JsonNode.Parse(jsonTextExtra).AsArray();
            int anzahlextras = Extrasarray.Count;
            List<Extras>? extras = JsonSerializer.Deserialize<List<Extras>>(jsonTextExtra);
            int i = 1;
          
            foreach (var extrass in extras)
            {
                Console.WriteLine($"({i}) {extrass.Name} | Durchmesser: {extrass.Description} | Preis: {extrass.Price}€");
                Console.WriteLine();
                i++;
            }

            int pick = 0;
            bool success = false;
            bool moreextras = false;
            int j = 1;

            do
            {
                success = false;
                do
                {
                    if (success == false)
                    {
                        Console.WriteLine("Auswahl Extras: ");
                        int.TryParse(Console.ReadLine(), out pick);

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

                char yesnomoreextras;
                int actualpick = pick - 1;
                var selectedextra = extras[actualpick];
                Console.WriteLine($"{selectedextra.Name} wurde als Extra gewählt.");

                mypc.Extras.Add(selectedextra);
                bool smallnoextras = false;

                while (!smallnoextras)
                {
                    Console.WriteLine("Sollen mehr Extras hinzugefügt werden? Ja(y) oder Nein(n)?");
                    char.TryParse(Console.ReadLine(), out yesnomoreextras);

                    if (yesnomoreextras == 'n')
                    {
                        moreextras = true;
                        smallnoextras = true;
                    }

                    else if (yesnomoreextras == 'y')
                    {
                        smallnoextras = true;
                    }

                    else
                    {
                        Console.WriteLine("Ungültige eingabe. Bitte erneut auswählen.");
                    }
                }
                
            } while (!moreextras);

            Console.WriteLine("Als Extras wurden Ausgewählt: " + string.Join(", ", mypc.Extras.Select(d => d.Name)));
            Console.WriteLine("Drücken sie eine Taste, um zum nächsten Punkt zu springen.");
            Console.ReadKey();
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
