using Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konstruktor
{
    public class PSUCheck
    {
        public static void CheckPSU(MyPc mypc)
        {
            float wattage;
            bool boolcompchange = false;
            int compchange = 0;
            bool success = false;

            float allwattageinput = mypc.Cpu.PowerDraw + mypc.Gpu.WattInput;
            Console.WriteLine($"Die gebrauchte Maximalleistung beträgt: {allwattageinput} Watt");

            do
            {
                if (allwattageinput > mypc.Psu.Watt)
                {
                    Console.WriteLine("Die Mindestanforderungen sind nicht erfüllt.\nBitte wählen sie ein stärkeres Netzteil(1) aus oder eine schwächere GPU(2) bzw. CPU(3).");
                    int.TryParse(Console.ReadLine(), out compchange);

                    if (compchange > 0 && compchange <= 3)
                    {
                        switch (compchange)
                        {
                            case 1:
                                Konstruktor.PSUs.PSUSelection(mypc);
                                break;

                            case 2:
                                Konstruktor.GPUs.GPUSelection(mypc);
                                break;

                            case 3:
                                Konstruktor.CPUs.CPUSelection(mypc);
                                break;

                        }
                        success = true;
                    }

                    else
                    {
                        Console.WriteLine("Ungültige eingabe, bitte erneut auswählen.");
                        break;
                    }
                }

                else if (allwattageinput < mypc.Psu.Watt)
                {
                    Console.WriteLine("Die Mindestanforderungen sind erfüllt");
                    success = true;
                }


            } while (!success);

            return;
        }
    }
}
