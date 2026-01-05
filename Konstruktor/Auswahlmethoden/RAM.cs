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
    public class RAMs
    {
        public static string RAMSelection(MyPc mypc)
        {
            string jsonTextRAM = File.ReadAllText("json/rams.json");
            JsonArray ramsarray = JsonNode.Parse(jsonTextRAM).AsArray();
            //int anzahlram = ramsarray.Count;
            List<RAM>? rams = JsonSerializer.Deserialize<List<RAM>>(jsonTextRAM);
            int i = 1;

            var compatiblerams = rams
                .Where(ram => ram.Type == mypc.Motherboard.DDRType)
                .ToList();

            Console.WriteLine("RAM-Riegel:");
            Console.WriteLine();
            foreach (var ramss in compatiblerams)
            {
                Console.WriteLine($"({i}) {ramss.Name} |Speicherkapazität: {ramss.Size} | DDR-Typ: {ramss.Type} | Design: {ramss.Design} \n    Taktgeschwindigkeit: {ramss.ClockSpeed}MHz  |  Preis:{ramss.Price}€");
                Console.WriteLine();
                i++;
            }

            int pick = 0;
            bool success = false;
            int anzahlram = compatiblerams.Count();

            do
            {
                if (success == false)
                {
                    Console.WriteLine("Auswahl RAM: ");
                    int.TryParse(Console.ReadLine(), out pick);

                    if (pick == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("ungültige Zahl. Nochmal auswählen.");
                        Console.ResetColor();
                    }

                    else if (pick <= anzahlram)
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
            mypc.Ram = rams[actualpick];
            Console.WriteLine($"{rams[actualpick].Name} wurde als RAM gewählt.");

            Console.WriteLine("Drücken sie eine Taste, um zum nächsten Punkt zu springen.");
            Console.ReadKey();

            return mypc.Ram.Name;
        }

    }
    public class RAM                                            ///Die Blaupause für die verscheidenen RAM-Speicher
    {
        public string Name { get; set; }
        public float Size { get; set; }                 //4GB-RAM, 16GB-RAM...
        public string Type { get; set; }                //DDR-4, DDR-5...
        public string Design { get; set; }              //DIMM, SO-DIMM, RDIMM...#
        public float ClockSpeed { get; set; }           //3000MHz, 6000MHz...
        public float Price { get; set; }
        public string[] Categories { get; set; }
    }
}
