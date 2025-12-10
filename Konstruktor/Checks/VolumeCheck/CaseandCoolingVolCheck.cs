using Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konstruktor.Checks.VolumeCheck
{
    public class CaseandCoolingVolCheck
    {
        public static void CaseandCoolingVolume(MyPc mypc)
        {

            //Air Cooling Check

            if (mypc.Coolings.Form == "Air" || mypc.Coolings.Form == "Passive")
            {
                if(mypc.Case.MaxCoolerHeight <= mypc.Coolings.Height)
                {
                    Console.WriteLine("Die Kühlung passt in das Gehäuse.");
                }

                else if(mypc.Case.MaxCoolerHeight > mypc.Coolings.Height)
                {
                    Console.WriteLine("Die Külhung passt nicht in das Gehäuse.\nBitte suchen sie sich entweder ein neues Gehäuse(1) oder eine neue Kühlung(2) aus.");
                    int coolingorcase;
                    int.TryParse(Console.ReadLine(), out coolingorcase);
                    bool success = false;

                    do
                    {
                        if (coolingorcase == 1)
                        {
                            Konstruktor.Methoden.Cases.CaseSelection(mypc);
                            Konstruktor.Checks.VolumeCheck.CaseandCoolingVolCheck.CaseandCoolingVolume(mypc);
                        }

                        else if (coolingorcase == 2)
                        {
                            Konstruktor.Methoden.AirCooling.AirCoolingsSelection(mypc);
                            Konstruktor.Checks.VolumeCheck.CaseandCoolingVolCheck.CaseandCoolingVolume(mypc);
                        }

                        else
                        {
                            Console.WriteLine("Ungültige eingabe. Bitte erneut auswählen.");
                        }

                    } while (!success);                        
                }
            }

            else if (mypc.Coolings.Form == "AiO")
            {

            }
        }
    }
}
