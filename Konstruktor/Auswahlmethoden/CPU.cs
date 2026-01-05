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
        public static void CPUSelection(MyPc mypc)
        {
            string jsonTextCPU = File.ReadAllText("json/cpus.json");
            JsonArray cpusarray = JsonNode.Parse(jsonTextCPU).AsArray();
            //int anzahlcpu = cpusarray.Count;
            List<CPU>? cpus = JsonSerializer.Deserialize<List<CPU>>(jsonTextCPU);
            int i = 1;

            var compatiblecpus = cpus
                .Where(cpu => cpu.Socket == mypc.Motherboard.Socket)
                .ToList();
            
                Console.WriteLine("CPUs");
                Console.WriteLine();
                foreach (var cpuss in compatiblecpus)
                {
                    Console.WriteLine($"({i}) {cpuss.Name} | Kernanzahl: {cpuss.Cores} | Sockel: {cpuss.Socket} | L3-Cache: {cpuss.L3Cache} MB  \n  Taktung: {cpuss.ClockSpeed}GHz | Leistungsaufnahme: {cpuss.PowerDraw} Watt | Kategorien: {string.Join(", ", cpuss.Categories)} | Preis: {cpuss.Price}€");
                    Console.WriteLine();
                    i++;
                }

            int pick = 0;
            bool success = false;
            int anzahlcpu = compatiblecpus.Count;

            do
            {
                if (success == false)
                {
                    Console.WriteLine("Auswahl CPUs: ");
                    int.TryParse(Console.ReadLine(), out pick);

                    if (pick == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("ungültige Zahl. Nochmal auswählen.");
                        Console.ResetColor();
                    }

                    else if (pick <= anzahlcpu)
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
            mypc.Cpu = cpus[actualpick];
            Console.WriteLine($"{cpus[actualpick].Name} wurde als CPU gewählt.");

            Console.WriteLine("Drücken sie eine Taste, um zum nächsten Punkt zu springen.");
            Console.ReadKey();            
        }        
    }
    public class CPU                                            ///Die Blaupause für die verscheidenen CPUs
    {
        public string Name { get; set; }
        public string Socket { get; set; }              //AM5, AM4, Z890...
        public float L3Cache { get; set; }              //128MB, 256MB...
        public float ClockSpeed { get; set; }           //4,1GHz...
        public float PowerDraw { get; set; }
        public int Cores { get; set; }
        public float Price { get; set; }
        public string[] Categories { get; set; }
    }
}
