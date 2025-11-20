using Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konstruktor
{
    public class RAMCheck
    {
        public static void RAMChecking(MyPc mypc)
        {
            bool success = false;

            do
            {
                int selection;

                if (mypc.Ram.Type != mypc.Motherboard.DDRType)
                {
                    Console.WriteLine($"Eines der Komponenten muss augetauscht werden, da die Kompatibilität zwischen RAM ({mypc.Ram.Type}) und Mainboard ({mypc.Motherboard.DDRType}) nicht gegeben ist.\nBitte wähle aus, ob RAM(1) oder Mainboard(2) getauscht werden sollen.");
                    int.TryParse(Console.ReadLine(), out selection);

                    if (selection == 1)
                    {
                        Konstruktor.RAMs.RAMSelection(mypc);
                        RAMChecking(mypc);
                    }

                    else if (selection == 2)
                    {
                        Konstruktor.Mainboards.MainboardSelection(mypc);
                        RAMChecking(mypc);
                    }

                    else
                    {
                        Console.WriteLine("Ungültige Auswahl. Bitte wähle erneut.");
                        return;
                    }
                }

                else
                {
                    Console.WriteLine("RAM und Mainboard sind Kompatiebel.");
                    success = true;
                }

            } while (!success);
        }
    }
}
