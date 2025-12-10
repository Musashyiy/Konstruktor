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
    public class Cases
    {
        public static string CaseSelection(MyPc mypc)
        {
            string jsonTextCase = File.ReadAllText("json/cases.json");
            JsonArray casesarray = JsonNode.Parse(jsonTextCase).AsArray();
            int anzahlcases = casesarray.Count;
            List<Case>? cases = JsonSerializer.Deserialize<List<Case>>(jsonTextCase);
            int i = 1;


            Console.WriteLine("Cases");
            Console.WriteLine();
            foreach (var casee in cases)
            {
                Console.WriteLine($"({i}) {casee.Name} | Höhe: {casee.Lenght}cm | Breite: {casee.Width}cm | Tiefe: {casee.Depth}cm \n    Lüfterplätze: {casee.NumberCaseFans} Stück | Formfaktor: {casee.Fit} |\n   Preis: {casee.Price}€ ");
                Console.WriteLine();
                i++;
            }

            int pick = 0;
            bool success = false;

            do
            {
                if (success == false)
                {
                    Console.WriteLine("Auswahl Case:");
                    int.TryParse(Console.ReadLine(), out pick);

                    if (pick == 0)
                    {
                        Console.WriteLine("ungültige Zahl. Nochmal auswählen.");
                    }

                    else if (pick <= anzahlcases)
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
            mypc.Case = cases[actualpick];
            Console.WriteLine($"{cases[actualpick].Name} wurde als Case gewählt.");

            Console.WriteLine("Drücken sie eine Taste, um zum nächsten Punkt zu springen.");
            Console.ReadKey();

            return mypc.Case.Name;
        }


    }
    public class Case                                          ///Die Blaupause für die verscheidenen Cases
    {
        public string Name { get; set; }
        public float Lenght { get; set; }               //in cm
        public float Width { get; set; }                //in cm
        public float Depth { get; set; }                //in cm
        public int NumberCaseFans { get; set; }
        public string Fit { get; set; }                 //ob ATX, mini-STX etc...
        public float Price { get; set; }
        public float MaxCoolerHeight { get; set; }
        public string[] Categories { get; set; }
    }
}