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
    public class PSUs
    {
        public static string PSUSelection(MyPc mypc)
        {
            string jsonTextPSU = File.ReadAllText("json/psus.json");
            JsonArray psusarray = JsonNode.Parse(jsonTextPSU).AsArray();
            int anzahlpsu = psusarray.Count;
            List<PSU>? psus = JsonSerializer.Deserialize<List<PSU>>(jsonTextPSU);
            int i = 1;


            Console.WriteLine("PSUs");
            Console.WriteLine();
            foreach (var psuss in psus)
            {
                Console.WriteLine($"({i}) {psuss.Name} | Wattoutput: {psuss.Watt} | Höhe: {psuss.Height}cm | Breite: {psuss.Width}cm \n    Tiefe: {psuss.Depth}cm  |  Preis:{psuss.Price}€");
                Console.WriteLine();
                i++;
            }

            int pick = 0;
            bool success = false;

            do
            {
                if (success == false)
                {
                    Console.WriteLine("Auswahl PSUs: ");
                    int.TryParse(Console.ReadLine(), out pick);

                    if (pick == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("ungültige Zahl. Nochmal auswählen.");
                        Console.ResetColor();
                    }

                    else if (pick <= anzahlpsu)
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
            mypc.Psu = psus[actualpick];
            Console.WriteLine($"{psus[actualpick].Name} wurde als GPU gewählt.");

            Console.WriteLine("Drücken sie eine Taste, um zum nächsten Punkt zu springen.");
            Console.ReadKey();

            return mypc.Psu.Name;
        }
    }
    public class PSU                                            ///Die Blaupause für die verscheidenen PSUs
    {
        public string Name { get; set; }
        public float Watt { get; set; }                 //in Watt
        public float Height { get; set; }               //in cm
        public float Width { get; set; }                //in cm
        public float Depth { get; set; }                //in cm
        public float Price { get; set; }
        public string[] Categories { get; set; }
    }
}
