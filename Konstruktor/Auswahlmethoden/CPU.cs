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
    public class CPUs
    {
        public static string CPUSelection(MyPc mypc)
        {
            string jsonTextCPU = File.ReadAllText("json/cpus.json");
            JsonArray cpusarray = JsonNode.Parse(jsonTextCPU).AsArray();
            int anzahlcpu = cpusarray.Count;
            List<CPU>? cpus = JsonSerializer.Deserialize<List<CPU>>(jsonTextCPU);
            int i = 1;


            Console.WriteLine("CPUs");
            Console.WriteLine();
            foreach (var cpuss in cpus)
            {
                Console.WriteLine($"({i}) {cpuss.Name} | Sockel: {cpuss.Socket} | L3-Cache: {cpuss.L3Cache} | Taktung: {cpuss.ClockSpeed}GHz \n    Leistungsaufnahme: {cpuss.PowerDraw} | Preis: {cpuss.Price}€");
                Console.WriteLine();
                i++;
            }

            int pick = 0;
            bool success = false;

            do
            {
                if (success == false)
                {
                    Console.WriteLine("Auswahl CPUs: ");
                    int.TryParse(Console.ReadLine(), out pick);

                    if (pick == 0)
                    {
                        Console.WriteLine("ungültige Zahl. Nochmal auswählen.");
                    }

                    else if (pick <= anzahlcpu)
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
            mypc.Cpu = cpus[actualpick];
            Console.WriteLine($"{cpus[actualpick].Name} wurde als CPU gewählt.");

            Console.WriteLine("Drücken sie eine Taste, um zum nächsten Punkt zu springen.");
            Console.ReadKey();

            return mypc.Cpu.Name;
        }        
    }
    public class CPU                                            ///Die Blaupause für die verscheidenen CPUs
    {
        public string Name { get; set; }
        public string Socket { get; set; }              //AM5, AM4, Z890...
        public float L3Cache { get; set; }              //128MB, 256MB...
        public float ClockSpeed { get; set; }           //4,1GHz...
        public float PowerDraw { get; set; }
        public float Price { get; set; }
        public string[] Categories { get; set; }
    }
}
