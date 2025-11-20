using Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konstruktor
    {
        public class DriverCheck
        {
            public static void DriveCheck(MyPc mypc)
            {
                bool success = false;

                do
                {
                    if (mypc.Drive.Connection != mypc.Motherboard.DriveSupport)
                    {
                        int selection;

                        Console.WriteLine($"Die Kompatibilität von Mainboard({mypc.Motherboard.DriveSupport}) und Festplatte({mypc.Drive.Connection}) stimmt nicht überein.\nBitte wählen sie ein neues Motherboard(1) oder eine neue Festplatte(2).");
                        int.TryParse(Console.ReadLine(), out selection);

                        if (selection == 1)
                        {
                            Konstruktor.Mainboards.MainboardSelection(mypc);
                            DriveCheck(mypc);
                        }

                        else if (selection == 2)
                        {
                            Konstruktor.Drive.DrivesSelection(mypc);
                            DriveCheck(mypc);
                        }

                        else
                        {
                            Console.WriteLine("Auswahl ungültig. Bitte erneut wählen.");
                            return;
                        }
                    }

                    else
                    {
                        Console.WriteLine("Festplatte und Mainboard sind kompatibel");
                        success = true;
                    }

                } while (!success);
            }
        }
    }



