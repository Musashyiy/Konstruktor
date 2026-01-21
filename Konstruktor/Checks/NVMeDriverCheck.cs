//using Components;
//using Konstruktor.Methoden;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Konstruktor.Checks
//{
//    public class NVMeDriverCheck
//    {
//        public static void NVMeDriveCheck(MyPc mypc)
//        {
//            bool success = false;
//            bool incopatible = mypc.DriveNVMe
//            .Any(drive => !mypc.Motherboard.DriveSupport.Contains(drive.Connection));
//            var drivenamestext = string.Join(". ", mypc.DriveNVMe.Select(d => d.Name));
//            var mainboardnametext = string.Join(", ", mypc.Motherboard.DriveSupport);

//            do
//            {
//                if (incopatible)
//                {
//                    int selection;

//                    Console.WriteLine($"Die Kompatibilität von Mainboard({mainboardnametext}) und Festplatte({drivenamestext}) stimmt nicht überein.\nBitte wählen sie ein neues Motherboard(1) oder eine neue Festplatte(2).");
//                    int.TryParse(Console.ReadLine(), out selection);

//                    if (selection == 1)
//                    {
//                        Console.Clear();
//                        mypc.DriveNVMe.Clear();
//                        Mainboards.MainboardSelection(mypc);
//                        NVMeDriveCheck(mypc);
//                    }

//                    else if (selection == 2)
//                    {
//                        Console.Clear();
//                        NVMeDrive.NVMeDrivesSelection(mypc);
//                        NVMeDriveCheck(mypc);
//                    }

//                    else
//                    {
//                        Console.WriteLine("Auswahl ungültig. Bitte erneut wählen.");
//                        return;
//                    }
//                }

//                else
//                {
//                    Console.ForegroundColor = ConsoleColor.DarkGreen;
//                    Console.WriteLine("Festplatte und Mainboard sind kompatibel");
//                    Console.ResetColor();
//                    success = true;
//                }

//            } while (!success);
//        }
//    }
//}
    



