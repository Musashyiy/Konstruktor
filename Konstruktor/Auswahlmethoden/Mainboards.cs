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
    public class Mainboards
    {
        public static string MainboardSelection(MyPc mypc)
        {
            string jsonTextMB = File.ReadAllText("json/motherboards.json");
            JsonArray motherboardsarray = JsonNode.Parse(jsonTextMB).AsArray();
            int anzahlmb = motherboardsarray.Count;
            List<Motherboard>? motherboards = JsonSerializer.Deserialize<List<Motherboard>>(jsonTextMB);
            int i = 1;


            Console.WriteLine("Motherboards");
            Console.WriteLine();
            foreach (var motherbordss in motherboards)
            {
                Console.WriteLine($"({i}) {motherbordss.Name} | Formfaktor: {motherbordss.Fit} | Sockel: {motherbordss.Socket} | DDR-Typ: {motherbordss.DDRType} \n |Festplattensupport: {string.Join(", ", motherbordss.DriveSupport)} |   Preis: {motherbordss.Price}€");
                Console.WriteLine();
                i++;
            }

            int pick = 0;
            bool success = false;

            do
            {
                if (success == false)
                {
                    Console.WriteLine("Auswahl Motherboard: ");
                    int.TryParse(Console.ReadLine(), out pick);

                    if (pick == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("ungültige Zahl. Nochmal auswählen.");
                        Console.ResetColor();
                    }

                    else if (pick <= anzahlmb)
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
            mypc.Motherboard = motherboards[actualpick];
            Console.WriteLine($"{motherboards[actualpick].Name} wurde als Motherboard gewählt.");

            Console.WriteLine("Drücken sie eine Taste, um zum nächsten Punkt zu springen.");
            Console.ReadKey();

            return mypc.Motherboard.Name;
        }
    }
    public class Motherboard                                    ///Die Blaupause für die verscheidenen Motherboards
    {
        public string Name { get; set; }
        public string Fit { get; set; }                 //ATX, mini-ATX etc...
        public string Socket { get; set; }              //AM5, AM4, Z890...
        public float Price { get; set; }
        public string DDRType { get; set; }             //DDR-4, DDR-5, DDR-5 RDIMM...
        public List <string> DriveSupport { get; set; }
        public List <string> NVMeSlots { get; set; }
        public string[] Categories { get; set; }
    }
}
