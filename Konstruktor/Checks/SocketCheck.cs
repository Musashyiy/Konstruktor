//using Components;
//using Konstruktor.Methoden;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Konstruktor.Checks
//{
//    public class SocketCheck
//    {
//        public static void CheckSocket(MyPc mypc)
//        {
//            bool success = false;
//            while (!success)
//            {
//                int selection;

//                if (mypc.Cpu.Socket != mypc.Motherboard.Socket)
//                {
//                    Console.WriteLine($"Die Sockel von CPU({mypc.Cpu.Socket}) und Motherboard ({mypc.Motherboard.Socket}) sind nicht kompatibel.\nWelchen Komponent sollen getauscht werden? CPU(1) oder Motherboard(2)?");
//                    int.TryParse(Console.ReadLine(), out selection);

//                    if (selection == 1)
//                    {
//                        CPUs.CPUSelection(mypc);
//                        CheckSocket(mypc);
//                    }

//                    else if (selection == 2)
//                    {
//                        Mainboards.MainboardSelection(mypc);
//                        CheckSocket(mypc);
//                    }

//                    else
//                    {
//                        Console.WriteLine("Auswahl ungültig. Bitte erneut auswählen.");
//                        continue;
//                    }
//                }

//                else
//                {
//                    Console.ForegroundColor = ConsoleColor.DarkGreen;
//                    Console.WriteLine("CPU und Motherboard sind kompatibel.");
//                    Console.ResetColor();
//                    success = true;
//                }
//            }            
//        }
//    }
//}
