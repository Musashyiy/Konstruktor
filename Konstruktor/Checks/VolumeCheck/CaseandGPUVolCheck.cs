using Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Konstruktor.Checks.VolumeCheck
{
    public class CaseandGPUVolCheck
    {
        public static void CaseandGPUVolume(MyPc mypc)
        {
            bool successpickwidth = false;

            if(mypc.Gpu.Lenght >= mypc.Case.Lenght)
            {
                while (!successpickwidth == false)
                {
                    int pick;
                    Console.WriteLine($"{mypc.Case.Lenght}cm ist die maximale Länge, die die Grafikkarte haben darf. Diese Grafikkarte ist {mypc.Gpu.Lenght}cm lang.\n  Bitte wähle eine kürzere GPU(1) oder ein größeres Gehäuse(2).");
                    int.TryParse(Console.ReadLine(), out pick);

                    if (pick == 1)
                    {
                        successpickwidth = true;
                        Konstruktor.Methoden.GPUs.GPUSelection(mypc);
                        Konstruktor.Checks.PSUCheck.CheckPSU(mypc);
                        Konstruktor.Checks.VolumeCheck.CaseandGPUVolCheck.CaseandGPUVolume(mypc);
                    }

                    else if (pick == 2)
                    {
                        successpickwidth = true;
                        Konstruktor.Methoden.Cases.CaseSelection(mypc);
                        Konstruktor.Checks.VolumeCheck.CaseandGPUVolCheck.CaseandGPUVolume(mypc);
                    }

                    else
                    {
                        Console.WriteLine("Ungültige Eingabe. Bitte erneut auswählen.");
                    }
                }
            }            

            if (mypc.Gpu.Width >= mypc.Case.Width)
            {
                while (!successpickwidth == false)
                {
                    int pick;
                    Console.WriteLine($"{mypc.Case.Width}cm ist die maximale Breite, die die Grafikkarte haben darf. Diese Grafikkarte ist {mypc.Gpu.Width}cm breit.\n  Bitte wähle eine kleinere GPU(1) oder ein größeres Gehäuse(2).");
                    int.TryParse(Console.ReadLine(), out pick);

                    if (pick == 1)
                    {
                        successpickwidth = true;
                        Konstruktor.Methoden.GPUs.GPUSelection(mypc);
                        Konstruktor.Checks.PSUCheck.CheckPSU(mypc);
                        Konstruktor.Checks.VolumeCheck.CaseandGPUVolCheck.CaseandGPUVolume(mypc);
                    }

                    else if (pick == 2)
                    {
                        successpickwidth = true;
                        Konstruktor.Methoden.Cases.CaseSelection(mypc);
                        Konstruktor.Checks.VolumeCheck.CaseandGPUVolCheck.CaseandGPUVolume(mypc);
                    }

                    else
                    {
                        Console.WriteLine("Ungültige Eingabe. Bitte erneut auswählen.");
                    }
                }
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"Die GPU passt in das Gehäuse.\n  GPU länge und breite: {mypc.Gpu.Lenght}cm x {mypc.Gpu.Width}cm\n  Gehäuse länge und breite: {mypc.Case.Lenght}cm x {mypc.Case.Width}cm");
                Console.ResetColor();
            }

        }
    }
}
