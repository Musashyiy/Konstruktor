using Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Konstruktor
{
    public class Fans
    {
        public static string FansSelection(MyPc mypc)
        {
            string jsonTextFAN = File.ReadAllText("fans.json");
            JsonArray Fansarray = JsonNode.Parse(jsonTextFAN).AsArray();
            int anzahlfans = Fansarray.Count;
            List<Fan>? fans = JsonSerializer.Deserialize<List<Fan>>(jsonTextFAN);
            int i = 1;


            Console.WriteLine("Lüfter");
            Console.WriteLine();
            foreach (var fanss in fans)
            {
                Console.WriteLine($"({i}) {fanss.Name} | Durchmesser: {fanss.Size}mm | Preis: {fanss.Price} Euro");
                Console.WriteLine();
                i++;
            }

            int pick = 0;
            int amount = 0;
            bool success = false;
            bool success1 = false;
            char accept;

            do
            {
                if (success == false)
                {
                    Console.WriteLine("Auswahl Lüftung: ");
                    int.TryParse((Console.ReadLine()), out pick);

                    if (pick == 0)
                    {
                        Console.WriteLine("ungültige Zahl. Nochmal auswählen.");
                    }

                    else if (pick <= anzahlfans)
                    {
                        success = true;
                    }

                    else
                    {
                        Console.WriteLine("ungültige Zahl. Nochmal auswählen.");
                    }
                }
            } while (success == false);

            do
            {
                Console.WriteLine("Wie viele Lüfter werden eingebaut?");            
                int.TryParse((Console.ReadLine()), out amount);

                if (amount <= mypc.Case.NumberCaseFans)
                {
                    Console.WriteLine($"{amount} Lüfter wurden Hinzugefügt.");
                    success = true;
                }

                else
                {
                    Console.WriteLine("Es wurden mehr Lüfter ausgewählt, als das Gehäuse fassen kann.\nSind sie sicher, dass die Auswahl bestehen bleiben soll?\nJa(y) oder Nein(n)?");
                    char.TryParse(Console.ReadLine(), out accept);

                    if (accept == 'n')
                    {
                        Console.WriteLine("Wählen sie die neue Anzahl der Lüfter aus.");
                        continue;
                    }

                    else if (accept == 'y')
                    {
                        Console.WriteLine($"{amount} Lüfter wurden Hinzugefügt.");
                        success = true;
                    }

                    else
                    {
                        Console.WriteLine("Ungültige Auswahl. Bitte zwischen Ja(y) und Nein(n) auswählen.");
                    }
                }

            } while (!success1);

            Console.Clear();

            int actualpick = pick - 1;
            mypc.Fans = fans[actualpick];
            mypc.NumberFans = fans[amount];
            Console.WriteLine($"{fans[actualpick].Name} wurde als RAM gewählt.");
            Console.WriteLine($"{amount} Lüfter wurden ausgewählt");

            Console.WriteLine("Drücken sie eine Taste, um zum nächsten Punkt zu springen.");
            Console.ReadKey();

            return mypc.Fans.Name;
        }
    }
    public class Fan                                            ///Die Blaupause für die verscheidenen Fans
    {
        public string Name { get; set; }
        public float Size { get; set; }                 //120mm, 140mm...
        public float Price { get; set; }
        public string[] Categories { get; set; }
    }
}
