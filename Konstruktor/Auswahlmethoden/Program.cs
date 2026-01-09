using Components;
using Konstruktor.Checks;
using Konstruktor.Methoden;
using System.Dynamic;
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


            Mainboards.MainboardSelection(mypc);
            Console.Clear();
            Console.WriteLine("\x1b[3J");

            CPUs.CPUSelection(mypc);
            Console.Clear();
            Console.WriteLine("\x1b[3J");


            GPUs.GPUSelection(mypc);
            Console.Clear();
            Console.WriteLine("\x1b[3J");


            RAMs.RAMSelection(mypc);
            Console.Clear();
            Console.WriteLine("\x1b[3J");

            CoolingsSelection.CoolingSelection(mypc);
            Console.Clear();
            Console.WriteLine("\x1b[3J");

            SATADrive.SATADrivesSelection(mypc);
            Console.Clear();
            Console.WriteLine("\x1b[3J");

            if (mypc.Motherboard.DriveSupport.Contains("PCIe 4.0") || mypc.Motherboard.DriveSupport.Contains("PCIe 5.0"))
            {
                NVMeDrive.NVMeDrivesSelection(mypc);
                Console.Clear();
                Console.WriteLine("\x1b[3J");
            }

            Fans.FansSelection(mypc);
            Console.Clear();
            Console.WriteLine("\x1b[3J");

            PSUs.PSUSelection(mypc);
            Console.Clear();
            Console.WriteLine("\x1b[3J");

            Cases.CaseSelection(mypc);
            Console.Clear();
            Console.WriteLine("\x1b[3J");

            Extra.ExtrasSelection(mypc);
            Console.Clear();
            Console.WriteLine("\x1b[3J");

            //Konstruktor.Checks.FormfactorCheck.FormCheck(mypc);
            //Konstruktor.Checks.SocketCheck.CheckSocket(mypc);
            PSUCheck.CheckPSU(mypc);
            //Konstruktor.Checks.RAMCheck.RAMChecking(mypc);
            //NVMeDriverCheck.NVMeDriveCheck(mypc);
            Checks.VolumeCheck.VolumeCheck.MeasurmentCheck(mypc);
            PriceCheck.Pricecheck(mypc);

            Checkout.Checkoutgenerate(mypc);    

        }
    }
}

namespace Components
{
    public class MyPc
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