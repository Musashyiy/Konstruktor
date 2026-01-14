using Components;
using Konstruktor.Checks;
using Konstruktor.Methoden;
using System.Dynamic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;


namespace Konstruktor.Methoden
{
    class Program
    {
        static void Main(string[] args)
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
                    if (mypc.Motherboard.DriveSupport.Contains("PCIe 4.0") || mypc.Motherboard.DriveSupport.Contains("PCIe 5.0"))
                    {
                        NVMeDrive.NVMeDrivesSelection(mypc);
                        Console.Clear();
                        Console.WriteLine("\x1b[3J");
                    }
                    else if (mypc.Motherboard.DriveSupport.Equals(String.Empty))
                    {

                    }
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
            //Console.OutputEncoding = Encoding.UTF8;
            ////Console.SetWindowSize(250, 30);

            //MyPc mypc = new MyPc();            


            //Mainboards.MainboardSelection(mypc);
            //Console.Clear();
            //Console.WriteLine("\x1b[3J");

            //CPUs.CPUSelection(mypc);
            //Console.Clear();
            //Console.WriteLine("\x1b[3J");


            //GPUs.GPUSelection(mypc);
            //Console.Clear();
            //Console.WriteLine("\x1b[3J");


            //RAMs.RAMSelection(mypc);
            //Console.Clear();
            //Console.WriteLine("\x1b[3J");

            //CoolingsSelection.CoolingSelection(mypc);
            //Console.Clear();
            //Console.WriteLine("\x1b[3J");

            //SATADrive.SATADrivesSelection(mypc);
            //Console.Clear();
            //Console.WriteLine("\x1b[3J");

            //if (mypc.Motherboard.DriveSupport.Contains("PCIe 4.0") || mypc.Motherboard.DriveSupport.Contains("PCIe 5.0"))
            //{
            //    NVMeDrive.NVMeDrivesSelection(mypc);
            //    Console.Clear();
            //    Console.WriteLine("\x1b[3J");
            //}

            //Fans.FansSelection(mypc);
            //Console.Clear();
            //Console.WriteLine("\x1b[3J");

            //PSUs.PSUSelection(mypc);
            //Console.Clear();
            //Console.WriteLine("\x1b[3J");

            //Cases.CaseSelection(mypc);
            //Console.Clear();
            //Console.WriteLine("\x1b[3J");

            //Extra.ExtrasSelection(mypc);
            //Console.Clear();
            //Console.WriteLine("\x1b[3J");

            ////Konstruktor.Checks.FormfactorCheck.FormCheck(mypc);
            ////Konstruktor.Checks.SocketCheck.CheckSocket(mypc);
            //PSUCheck.CheckPSU(mypc);
            ////Konstruktor.Checks.RAMCheck.RAMChecking(mypc);
            ////NVMeDriverCheck.NVMeDriveCheck(mypc);
            //Checks.VolumeCheck.VolumeCheck.MeasurmentCheck(mypc);
            //PriceCheck.Pricecheck(mypc);

            Checkout.Checkoutgenerate(mypc);

        }
    }
}

namespace Components
{
    public  class MyPc
    {
        public Case Case { get; set; }
        public PSU Psu { get; set; }
        public CPU Cpu { get; set; }
        public GPU Gpu { get; set; }
        public Motherboard Motherboard { get; set; }
        public RAM Ram { get; set; }
        public List<SATADrives> DriveSATA { get; set; } = new();
        public List<NVMeDrives> DriveNVMe { get; set; } = new();
        public CoolingBlueprint Coolings { get; set; }
        public List<Fan> Fans { get; set; } = new();
        public List<Extras> Extras { get; set; } = new();
        public float Price { get; set; }
    }

    
}