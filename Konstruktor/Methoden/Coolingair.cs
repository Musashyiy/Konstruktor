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
            Console.Clear();
            string jsonTextCoolingair = File.ReadAllText("json/coolingsair.json");
            JsonArray coolingairsarray = JsonNode.Parse(jsonTextCoolingair).AsArray();
            List<CoolingBlueprint>? coolingsair = JsonSerializer.Deserialize<List<CoolingBlueprint>>(jsonTextCoolingair);
            int i = 1;
            int anzahlcoolingair;
            

            if (mypc.Motherboard == null)
            {

                string? socketToUse = null;
                if (mypc.Motherboard != null && !string.IsNullOrWhiteSpace(mypc.Motherboard.Socket))
                {
                    socketToUse = mypc.Motherboard.Socket;
                }
                else if (mypc.Cpu != null && !string.IsNullOrWhiteSpace(mypc.Cpu.Socket))
                {
                    socketToUse = mypc.Cpu.Socket;
                }

                var compatibleaios = (socketToUse == null)
                    ? coolingsair.ToList()
                    : coolingsair.Where(aio => aio.Sockets.Contains(socketToUse)).ToList();

                Console.WriteLine("Luftkühlungen:");

                foreach (var coolingss in coolingsair)
                {
                    Console.WriteLine($"({i}) {coolingss.Name} | Form: {coolingss.Form} | Sockelkompartibilität: {string.Join(", ", coolingss.Sockets)} | Maße: Höhe {coolingss.Height}cm x Breite {coolingss.Width}cm x Länge {coolingss.Lenght}cm | Kategorien: {string.Join(", ", coolingss.Categories)} | Preis: {coolingss.Price}€");
                    Console.WriteLine();
                    i++;
                }
                anzahlcoolingair = coolingsair.Count;

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
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("ungültige Zahl. Nochmal auswählen.");
                            Console.ResetColor();
                        }

                        else if (pick <= anzahlcoolingair)
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

                mypc.Coolings = coolingsair[actualpick];
                Console.WriteLine($"{coolingsair[actualpick].Name} wurde als Kühlung ausgewählt.");

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Drücken sie eine Taste, um zum nächsten Punkt zu springen.");
                Console.ResetColor();
                Console.ReadKey();
            }

            else
            {
                var compatibleair = coolingsair
                    .Where(air => air.Sockets.Contains(mypc.Motherboard.Socket))
                    .ToList();

                Console.WriteLine("Luft-Kühlung");
                Console.WriteLine();
                foreach(var coolingss in compatibleair)
                {
                    Console.WriteLine($"({i}) {coolingss.Name} | Form: {coolingss.Form} | Sockelkompartibilität: {string.Join(", ", coolingss.Sockets)} | Maße: Höhe {coolingss.Height}cm x Breite {coolingss.Width}cm x Länge {coolingss.Lenght}cm | Kategorien: {string.Join(", ", coolingss.Categories)} | Preis: {coolingss.Price}€");
                    Console.WriteLine();
                    i++;
                }
                anzahlcoolingair = compatibleair.Count;
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
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("ungültige Zahl. Nochmal auswählen.");
                            Console.ResetColor();
                        }

                        else if (pick <= anzahlcoolingair)
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

                mypc.Coolings = compatibleair[actualpick];
                Console.WriteLine($"{compatibleair[actualpick].Name} wurde als Kühlung ausgewählt.");

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Drücken sie eine Taste, um zum nächsten Punkt zu springen.");
                Console.ResetColor();
                Console.ReadKey();
            }
        }        
    } 
}

