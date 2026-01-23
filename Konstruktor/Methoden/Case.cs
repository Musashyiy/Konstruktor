using Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Konstruktor.Methoden
{
    public class Case : IComponent                                         ///Die Blaupause für die verscheidenen Cases
    {
        public string Name { get; set; }
        public float Lenght { get; set; }               //in cm
        public float Width { get; set; }                //in cm
        public float Depth { get; set; }                //in cm
        public int NumberCaseFans120mm { get; set; }
        public int NumberCaseFans140mm { get; set; }
        public int NumberSATASlots25 { get; set; }
        public int NumberSATASlots35 { get; set; }
        public float MaxGPULength { get; set; }
        public string Fit { get; set; }                 //ob ATX, mini-STX etc...
        public float Price { get; set; }
        public float MaxCoolerHeight { get; set; }
        public string[] Categories { get; set; }
        public void Select(MyPc mypc)
        {
            Console.Clear();
            string jsonTextCase = File.ReadAllText("json/cases.json");
            JsonArray casesarray = JsonNode.Parse(jsonTextCase).AsArray();
            int anzahlcases;
            List<Case>? cases = JsonSerializer.Deserialize<List<Case>>(jsonTextCase);
            int i = 1;

            

            if(mypc.Motherboard.Fit == null)
            {
                Console.WriteLine("Cases");
                Console.WriteLine();
                foreach (var casee in cases)
                {
                    Console.WriteLine($"({i}) {casee.Name} | Höhe: {casee.Lenght}cm | Breite: {casee.Width}cm | Tiefe: {casee.Depth}cm \n    120mm-Lüfter: {casee.NumberCaseFans120mm} Stück | 140mm-Lüfter: {casee.NumberCaseFans140mm} Stück | Formfaktor: {casee.Fit} | Maximale Kühlerhöhe: {casee.MaxCoolerHeight}cm | Kategorien: {string.Join(", ", casee.Categories)} | Preis: {casee.Price}€");
                    Console.WriteLine();
                    i++;
                }
                anzahlcases = cases.Count();
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
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("ungültige Zahl. Nochmal auswählen.");
                            Console.ResetColor();
                        }

                        else if (pick <= anzahlcases)
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
                mypc.Case = cases[actualpick];
                int anzahlfans = mypc.Fans120.Count() + mypc.Fans140.Count();
                int anzahlfanslotsincase = mypc.Case.NumberCaseFans120mm + mypc.Case.NumberCaseFans140mm;
                Console.WriteLine($"{cases[actualpick].Name} wurde als Case gewählt.");
                int select120140;
                bool toomuch120140 = false;
                

                if (anzahlfans > anzahlfanslotsincase)
                {
                    while (!toomuch120140)
                    {
                        if (mypc.Fans120.Count() > mypc.Case.NumberCaseFans120mm || mypc.Fans140.Count() > mypc.Case.NumberCaseFans140mm)
                        {                            
                            Console.WriteLine($"{mypc.Fans120.Count()}x 120mm-Lüfter sind ausgewählt und ({mypc.Case.NumberCaseFans120mm}x 120mm-Lüfter passen ins Gehäuse) \n{mypc.Fans140.Count()}x 140mm-Lüfter sind ausgewählt und ({mypc.Case.NumberCaseFans120mm}x 120mm-Lüfter passen ins Gehäuse)\n(1) Wähle alle Lüfter und die Anzahl nochmals aus\n(2) Wähle nur neue 120mm-Lüfter aus\n(3) Wähle nur neue 140mm-Lüfter aus\n(4) Die jetzige Auswahl bleibt bestehen (egal ob es zu viele Lüfter sind)");
                            int.TryParse(Console.ReadLine(), out select120140);
                            if (select120140 == 1)
                            {
                                mypc.Fans120.Clear();
                                mypc.Fans140.Clear();
                                IComponent component = new Fan();
                                component.Select(mypc);
                                toomuch120140 = true;
                            }
                            else if (select120140 == 2)
                            {
                                mypc.Fans120.Clear();                                
                                IComponent component = new Fan();
                                component.Select(mypc);
                                toomuch120140 = true;
                            }
                            else if (select120140 == 3)
                            {
                                mypc.Fans140.Clear();
                                IComponent component = new Fan();
                                component.Select(mypc);
                                toomuch120140 = true;
                            }
                            else if (select120140 == 4)
                            {
                                mypc.Fans120.Clear();
                                IComponent component = new Fan();
                                component.Select(mypc);
                                toomuch120140 = true;
                            }
                            else
                            {
                                Console.WriteLine("Auswahl ungültig. Bitte erneut auswählen.");
                            }
                        }                        
                    }

                    //bool numberok = false;
                    //do
                    //{
                    //    Console.WriteLine($"Es wurden {anzahlfans} Lüfter ausgewählt. Das sind mehr als das ausgewählte Gehäuse fassen kann. Wollen sie die Lüfter beibehalten(y) oder ändern(n)?");
                    //    char numbertoomuchfans;
                    //    char.TryParse(Console.ReadLine(), out numbertoomuchfans);

                    //    if (numbertoomuchfans == 'y')
                    //    {
                    //        mypc.Fans120.Clear();
                    //        mypc.Fans140.Clear();
                    //        //Fan();                        Hier muss noch die Selct Methode für die Fans eingabeut werden.
                    //        numberok = true;
                    //    }

                    //    else if (numbertoomuchfans == 'n')
                    //    {
                    //        Console.WriteLine("Die Auswahl der Lüfter bleibt bestehen.");
                    //        numberok = true;
                    //    }

                    //    else
                    //    {
                    //        Console.WriteLine("Ungültige Eingabe. Bitte wählen sie erneut aus.");
                    //    }

                    //} while (!numberok);
                }

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Drücken sie eine Taste, um zum nächsten Punkt zu springen.");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("\x1b[3J");
            }

            else
            {
                var compatiblecases = cases
                    .Where(casse => casse.Fit == mypc.Motherboard.Fit)
                    .ToList();

                Console.WriteLine("Cases");
                Console.WriteLine();
                foreach (var casee in compatiblecases)
                {
                    Console.WriteLine($"({i}) {casee.Name} | Höhe: {casee.Lenght}cm | Breite: {casee.Width}cm | Tiefe: {casee.Depth}cm \n    120mm-Lüfterplätze: {casee.NumberCaseFans120mm} Stück | 140mm-Lüfterplätze: {casee.NumberCaseFans140mm} Stück | Formfaktor: {casee.Fit} | Maximale Kühlerhöhe: {casee.MaxCoolerHeight}cm |\n    Kategorien: {string.Join(", ", casee.Categories)} | Preis: {casee.Price}€");
                    Console.WriteLine();
                    i++;
                }

                int numfansincase = mypc.Fans.Count();
                anzahlcases = compatiblecases.Count();
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
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("ungültige Zahl. Nochmal auswählen.");
                            Console.ResetColor();
                        }

                        else if (pick <= anzahlcases)
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
                mypc.Case = cases[actualpick];
                int anzahlfans = mypc.Fans.Count();
                Console.WriteLine($"{cases[actualpick].Name} wurde als Case gewählt.");


                if (mypc.)
                {

                }

                //if (anzahlfans > mypc.Case.NumberCaseFans)
                //{
                //    bool numberok = false;

                //    do
                //    {
                //        Console.WriteLine($"Es wurden {anzahlfans} Lüfter ausgewählt. Das sind mehr als das ausgewählte Gehäuse fassen kann. Wollen sie die Lüfter beibehalten(y) oder ändern(n)?");
                //        char numbertoomuchfans;
                //        char.TryParse(Console.ReadLine(), out numbertoomuchfans);

                //        if (numbertoomuchfans == 'y')
                //        {
                //            mypc.Fans.Clear();
                //            //Fan(mypc);
                //            numberok = true;
                //        }

                //        else if (numbertoomuchfans == 'n')
                //        {
                //            Console.WriteLine("Die Auswahl der Lüfter bleibt bestehen.");
                //            numberok = true;
                //        }

                //        else
                //        {
                //            Console.WriteLine("Ungültige Eingabe. Bitte wählen sie erneut aus.");
                //        }

                //    } while (!numberok);
                //}
                



                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Drücken sie eine Taste, um zum nächsten Punkt zu springen.");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("\x1b[3J");
            }

            
        }
    }
}