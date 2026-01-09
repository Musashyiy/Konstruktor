using Components;
using Konstruktor.Methoden;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konstruktor.Methoden
{
    public class CoolingsSelection
    {

        public static void CoolingSelection(MyPc mypc)
        {
            Console.WriteLine("Wollen sie eine Luftkühlung(1) oder eine Wasserkühlung(2)?");
            int aioair;
            bool aioorair = false;

            do
            {
                int.TryParse(Console.ReadLine(), out aioair);

                if (aioair == 1)
                {
                    AirCooling.AirCoolingsSelection(mypc);
                    aioorair = true;
                }

                else if (aioair == 2)
                {
                    AioCoolings.AioCoolingsSelection(mypc);
                    aioorair = true;
                }

                else
                {
                    Console.WriteLine("Ungültige Eingabe. Bitte erneut auswählen.");
                }

            } while (!aioorair);
        }
    }
}
