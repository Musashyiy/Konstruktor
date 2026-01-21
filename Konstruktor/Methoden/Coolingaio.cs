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
    public class AioCooling
    {
        public static void AioCoolingsSelection(MyPc mypc)
        {
            Console.Clear();
            string jsonTextCoolingaio = File.ReadAllText("json/coolingsaio.json");
            JsonArray coolingsaioarray = JsonNode.Parse(jsonTextCoolingaio).AsArray();
            int anzahlcooling;
            List<CoolingBlueprint>? coolingsaio = JsonSerializer.Deserialize<List<CoolingBlueprint>>(jsonTextCoolingaio);
            int i = 1;
            
            if (mypc.Motherboard == null)
            {
                foreach (var coolingss in coolingsaio)
                {
                    Console.WriteLine($"({i}) {coolingss.Name} | Form: {coolingss.Form} | Sockelkompartibilität: {string.Join(", ", coolingss.Sockets)} | Maße: Höhe {coolingss.Height}cm x Breite {coolingss.Width}cm x Länge {coolingss.Lenght}cm | Kategorien: {string.Join(", ", coolingss.Categories)} | Preis: {coolingss.Price}€");
                    Console.WriteLine();
                    i++;
                }

                anzahlcooling = coolingsaio.Count();
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

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Drücken sie eine Taste, um zum nächsten Punkt zu springen.");
                Console.ResetColor();
                Console.ReadKey();
            }

            else
            {
                var compatibleaios = coolingsaio
                    .Where(aio => aio.Sockets.Contains(mypc.Motherboard.Socket) || aio.Sockets.Contains(mypc.Cpu.Socket))
                    .ToList();

                Console.WriteLine("Coolings");
                Console.WriteLine();
                foreach (var coolingss in compatibleaios)
                {
                    Console.WriteLine($"({i}) {coolingss.Name} | Form: {coolingss.Form} | Sockelkompartibilität: {string.Join(", ", coolingss.Sockets)} | Kategorien: {string.Join(", ", coolingss.Categories)} | Preis: {coolingss.Price}€");
                    Console.WriteLine();
                    i++;
                }
                anzahlcooling = compatibleaios.Count();
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
                mypc.Coolings = compatibleaios[actualpick];
                Console.WriteLine($"{compatibleaios[actualpick].Name} wurde als Kühlung ausgewählt.");

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Drücken sie eine Taste, um zum nächsten Punkt zu springen.");
                Console.ResetColor();
                Console.ReadKey();
            }

                                                  
        }        
    }
}