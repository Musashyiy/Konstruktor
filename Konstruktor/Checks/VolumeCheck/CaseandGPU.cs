using Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Konstruktor.Checks.VolumeCheck
{
    public class CaseandGPU
    {
        static void CaseandGPUVolume(MyPc mypc)
        {
            bool successpickwidth = false;



            if(mypc.Gpu.Lenght >= mypc.Case.Lenght)
            {
                while (!successpickwidth == false)
                {
                    int pick;
                    Console.WriteLine("Die GPU passt in der Länge nicht in das Gehäuse.\nBitte wähle eine kleinere GPU(1) oder ein größeres Gehäuse(2).");
                    int.TryParse(Console.ReadLine(), out pick);

                    if (pick == 1)
                    {
                        successpickwidth = true;
                        Konstruktor.Methoden.GPUs.GPUSelection(mypc);
                        Konstruktor.Checks.PSUCheck.CheckPSU(mypc);
                        Konstruktor.Checks.VolumeCheck.CaseandGPU.CaseandGPUVolume(mypc);
                    }

                    else if (pick == 2)
                    {
                        successpickwidth = true;
                        Konstruktor.Methoden.Cases.CaseSelection(mypc);
                        Konstruktor.Checks.VolumeCheck.CaseandGPU.CaseandGPUVolume(mypc);
                    }

                    else
                    {
                        Console.WriteLine("Ungültige Eingabe. Bitte erneut auswählen.");
                    }
                }
            }
                        
            if(mypc.Gpu.Width >= mypc.Case.Width)
            {
                while (!successpickwidth == false)
                {
                    int pick;
                    Console.WriteLine("Die GPU passt in der Breite nicht in das Gehäuse.\nBitte wähle eine kleinere GPU(1) oder ein größeres Gehäuse(2).");
                    int.TryParse(Console.ReadLine(), out pick);

                    if(pick == 1)
                    {
                        successpickwidth = true;
                        Konstruktor.Methoden.GPUs.GPUSelection(mypc);
                        Konstruktor.Checks.PSUCheck.CheckPSU(mypc);
                        Konstruktor.Checks.VolumeCheck.CaseandGPU.CaseandGPUVolume(mypc);
                    }

                    else if (pick == 2)
                    {
                        successpickwidth = true;
                        Konstruktor.Methoden.Cases.CaseSelection(mypc);
                        Konstruktor.Checks.VolumeCheck.CaseandGPU.CaseandGPUVolume(mypc);
                    }

                    else
                    {
                        Console.WriteLine("Ungültige Eingabe. Bitte erneut auswählen.");
                    }
                }
            }

            

        }
    }
}
