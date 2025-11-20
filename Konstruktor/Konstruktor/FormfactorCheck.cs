using Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konstruktor
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
                        Konstruktor.Mainboards.MainboardSelection(mypc);
                        FormCheck(mypc);
                    }

                    else if (selection == 2)
                    {
                        Konstruktor.Cases.CaseSelection(mypc);
                        FormCheck(mypc);
                    }

                    else
                    {
                        Console.WriteLine("Auswahl ungültig. Bitte erneut wählen.");
                    }
                }

                else
                {
                    Console.WriteLine("Gehäuse und Mainboard sind kompatibel");
                    success = true;
                }

            } while (!success) ;
        }
    }
}
