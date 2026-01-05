using Components;
using Konstruktor.Methoden;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konstruktor.Checks
{
    public class FormfactorCheck
    {
        public static void FormCheck(MyPc mypc)
        {
            bool success = false;

            do
            {
                if (mypc.Case.Fit != mypc.Motherboard.Fit)
                {
                    int selection;

                    Console.WriteLine($"Der Formfaktor von Motherboard({mypc.Motherboard.Fit}) und Gehäuse({mypc.Case.Fit}) stimmt nicht überein.\nBitte wählen sie ein neues Motherboard(1) oder ein neues Gehäuse(2).");
                    int.TryParse(Console.ReadLine(), out selection);

                    if (selection == 1)
                    {
                        Mainboards.MainboardSelection(mypc);
                        FormCheck(mypc);
                    }

                    else if (selection == 2)
                    {
                        Cases.CaseSelection(mypc);
                        FormCheck(mypc);
                    }

                    else
                    {
                        Console.WriteLine("Auswahl ungültig. Bitte erneut wählen.");
                    }
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Gehäuse und Mainboard sind kompatibel");
                    Console.ResetColor();
                    success = true;
                }

            } while (!success) ;
        }
    }
}
