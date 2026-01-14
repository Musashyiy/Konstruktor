using Components;
using Konstruktor.Methoden;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konstruktor.Auswahlmethoden
{
    public class newProgram
    {
        public static void newProg(MyPc mypc)
        {

            Console.OutputEncoding = Encoding.UTF8;
            //Console.SetWindowSize(250, 30);

            MyPc mypc = new MyPc();

            bool ready = false;
            while (!ready)
            {
                Console.WriteLine("Willkommen!\nWelche Komponenten wollen sie bearbeiten?\n(1)Motherboard\n(2)CPU\n(3)GPU\n(4)RAM\n(5)CPU-Kühlung\n(6)SATA-Festplatte\n(7)NVMe-Festplatte\n(8)Lüfter\n(9)Netzteil\n(10)Gehäuse\n(11)Extras\n(12)Oder sie sind fertig mit der Auswahl");
                int compselect;
                int.TryParse(Console.ReadLine(), out compselect);

                if (compselect == 1)
                {
                    Mainboards.MainboardSelection(mypc);
                    Console.Clear();
                    Console.WriteLine("\x1b[3J");
                }
                else if (compselect == 2)
                {
                    CPUs.CPUSelection(mypc);
                    Console.Clear();
                    Console.WriteLine("\x1b[3J");
                }
                else if (compselect == 3)
                {
                    GPUs.GPUSelection(mypc);
                    Console.Clear();
                    Console.WriteLine("\x1b[3J");
                }
                else if (compselect == 4)
                {
                    RAMs.RAMSelection(mypc);
                    Console.Clear();
                    Console.WriteLine("\x1b[3J");
                }
                else if (compselect == 5)
                {
                    CoolingsSelection.CoolingSelection(mypc);
                    Console.Clear();
                    Console.WriteLine("\x1b[3J");
                }
                else if (compselect == 6)
                {
                    SATADrive.SATADrivesSelection(mypc);
                    Console.Clear();
                    Console.WriteLine("\x1b[3J");
                }
                else if (compselect == 7)
                {
                    NVMeDrive.NVMeDrivesSelection(mypc);
                    Console.Clear();
                    Console.WriteLine("\x1b[3J");
                }
                else if (compselect == 8)
                {
                    Fans.FansSelection(mypc);
                    Console.Clear();
                    Console.WriteLine("\x1b[3J");
                }
                else if (compselect == 9)
                {
                    PSUs.PSUSelection(mypc);
                    Console.Clear();
                    Console.WriteLine("\x1b[3J");
                }
                else if (compselect == 10)
                {
                    Cases.CaseSelection(mypc);
                    Console.Clear();
                    Console.WriteLine("\x1b[3J");
                }
                else if (compselect == 11)
                {
                    PSUs.PSUSelection(mypc);
                    Console.Clear();
                    Console.WriteLine("\x1b[3J");
                }
                else if (compselect == 12)
                {
                    Extra.ExtrasSelection(mypc);
                    Console.Clear();
                    Console.WriteLine("\x1b[3J");
                }
                else
                {
                    ready = true;
                    Console.WriteLine("Alle Komponenten wurden gespeichert.");
                }
            }
        }
    }
}
