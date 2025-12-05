using Components;
using Konstruktor.Methoden;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konstruktor.Checks
{
    public class SATADriverCheck
    {
        public static void SATADriveCheck(MyPc mypc)
        {
            bool success = false;
            bool incopatible = mypc.DriveSATA
            .Any(drive => !mypc.Motherboard.DriveSupport.Contains(drive.Connection));

            do
            {
                if (incopatible)
                {
                    int selection;

                    Console.WriteLine($"Die Kompatibilität von Mainboard({mypc.Motherboard.DriveSupport}) und Festplatte({mypc.DriveSATA}) stimmt nicht überein.\nBitte wählen sie ein neues Motherboard(1) oder eine neue Festplatte(2).");
                    int.TryParse(Console.ReadLine(), out selection);

                    if (selection == 1)
                    {
                        Mainboards.MainboardSelection(mypc);
                        SATADriveCheck(mypc);
                    }

                    else if (selection == 2)
                    {
                        SATADrive.SATADrivesSelection(mypc);
                        SATADriveCheck(mypc);
                    }

                    else
                    {
                        Console.WriteLine("Auswahl ungültig. Bitte erneut wählen.");
                        return;
                    }
                }

                else
                {
                    Console.WriteLine("SATA-Festplatte und Mainboard sind kompatibel");
                    success = true;
                }

            } while (!success);
        }
    }
}
    



