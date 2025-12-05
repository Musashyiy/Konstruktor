using Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Konstruktor.Methoden
{
    public class Fans
    {
        public static void FansSelection(MyPc mypc)
        {
            string jsonTextFAN = File.ReadAllText("json/fans.json");
            JsonArray Fansarray = JsonNode.Parse(jsonTextFAN).AsArray();
            int anzahlfans = Fansarray.Count;
            List<Fan>? fans = JsonSerializer.Deserialize<List<Fan>>(jsonTextFAN);
            int i = 1;

            Console.WriteLine("Lüfter");
            Console.WriteLine();
            foreach (var fanss in fans)
            {
                Console.WriteLine($"({i}) {fanss.Name} | Durchmesser: {fanss.Size}mm | Preis: {fanss.Price}€");
                Console.WriteLine();
                i++;
            }

            int pick = 0;
            int amount = 0;
            bool success = false;
            bool successfanamount = false;
            char accept;
            bool otherfansbool = false;
            bool boolnumberfans = false;

            do
            {
                while (success == false)
                {
                    Console.WriteLine("Auswahl Lüftung: ");
                    int.TryParse(Console.ReadLine(), out pick);

                    if (pick == 0)
                    {
                        Console.WriteLine("ungültige Zahl. Nochmal auswählen.");
                    }

                    else if (pick <= anzahlfans)
                    {
                        success = true;
                    }

                    else if (pick > anzahlfans)
                    {
                        Console.WriteLine("ungültige Zahl. Nochmal auswählen.");
                    }
                }
                
                int actualpick = pick - 1;

                string selectedfans = fans[actualpick].Name;
                var theonefanpicked = fans[actualpick];
                int numberfans;

                Console.WriteLine("Wie viele Lüfter sollen von diesem Modell hinzugefügt werden?");
                int.TryParse(Console.ReadLine(), out numberfans);

                
                Console.WriteLine($"{selectedfans} wurde als Lüfter gewählt.");

                for (int j = 1; j <= numberfans; j++)
                {
                    mypc.Fans.Add(theonefanpicked);
                }
                

                do
                {
                    char answerotherfans;
                    Console.WriteLine("Wollen sie noch andere Lüfter auswählen? Ja(y) oder Nein(n).");
                    char.TryParse(Console.ReadLine(), out answerotherfans);

                    if (answerotherfans == 'y')
                    {
                        success = false;
                        otherfansbool = true;
                    }

                    else if (answerotherfans == 'n')
                    {
                        success = true;
                        otherfansbool = true;
                    }

                    else
                    {
                        Console.WriteLine("Ungültige Eingabe. Bitte versuchen sie es erneut.");
                        otherfansbool = false;
                    }

                } while (!otherfansbool);

                

                //FanSelection fs = new FanSelection
                //{
                //    Model = theonefanpicked,
                //    Quantity = numberfans
                //};

                //mypc.Fansselection.Add(fs);

            } while (!success);

                //do
                //{
                //    Console.WriteLine("Wie viele Lüfter werden eingebaut?");
                //    int.TryParse(Console.ReadLine(), out amount);

                //    if (amount <= mypc.Case.NumberCaseFans)
                //    {
                //        Console.WriteLine($"{amount} Lüfter wurden Hinzugefügt.");
                //        successfanamount = true;
                //    }

                //    else
                //    {
                //        Console.WriteLine("Es wurden mehr Lüfter ausgewählt, als das Gehäuse fassen kann.\nSind sie sicher, dass die Auswahl bestehen bleiben soll?\nJa(y) oder Nein(n)?");
                //        char.TryParse(Console.ReadLine(), out accept);

                //        if (accept == 'n')
                //        {
                //            Console.WriteLine("Wählen sie die neue Anzahl der Lüfter aus.");
                //            continue;
                //        }

                //        else if (accept == 'y')
                //        {
                //            Console.WriteLine($"{amount} Lüfter wurden Hinzugefügt.");
                //            successfanamount = true;
                //        }

                //        else
                //        {
                //            Console.WriteLine("Ungültige Auswahl. Bitte zwischen Ja(y) und Nein(n) auswählen.");
                //        }
                //    }

                //} while (!successfanamount);

            Console.Clear();
                        
            Console.WriteLine($"{amount} Lüfter wurden ausgewählt");

            Console.WriteLine("Drücken sie eine Taste, um zum nächsten Punkt zu springen.");
            Console.ReadKey();
                        
        }
    }
    public class Fan                                            ///Die Blaupause für die verscheidenen Lüfter
    {
        public string Name { get; set; }
        public int FanNum { get; set; }
        public float Size { get; set; }                 //120mm, 140mm...
        public float Price { get; set; }
        public string[] Categories { get; set; }
    }
    //public class FanSelection
    //{
    //    public Fan Model { get; set; }
    //    public int Quantity { get; set; }
    //}
}   
    
