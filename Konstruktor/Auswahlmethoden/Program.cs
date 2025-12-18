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

            //Konstruktor.Methoden.Cases.CaseSelection(mypc);
            //Console.Clear();
            //Console.WriteLine("\x1b[3J");

            //Konstruktor.Methoden.PSUs.PSUSelection(mypc);
            //Console.Clear();
            //Console.WriteLine("\x1b[3J");

            //Mainboards.MainboardSelection(mypc);
            //Console.Clear();
            //Console.WriteLine("\x1b[3J");

            //Konstruktor.Checks.FormfactorCheck.FormCheck(mypc);

            //Konstruktor.Methoden.CPUs.CPUSelection(mypc);
            //Console.Clear();
            //Console.WriteLine("\x1b[3J");

            //Konstruktor.Checks.SocketCheck.CheckSocket(mypc);

            //Konstruktor.Methoden.GPUs.GPUSelection(mypc);
            //Console.Clear();
            //Console.WriteLine("\x1b[3J");

            //Konstruktor.Checks.PSUCheck.CheckPSU(mypc);

            //Konstruktor.Methoden.RAMs.RAMSelection(mypc);
            //Console.Clear();
            //Console.WriteLine("\x1b[3J");

            //Konstruktor.Checks.RAMCheck.RAMChecking(mypc);

            //Console.WriteLine("Wollen sie eine Luftkühlung(1) oder eine Wasserkühlung(2)?");
            //int aioair;
            //bool aioorair = false;
            //int.TryParse(Console.ReadLine(), out aioair);

            //do
            //{
            //    if (aioair == 1)
            //    {
            //        Konstruktor.Methoden.AirCooling.AirCoolingsSelection(mypc);
            //        aioorair = true;
            //    }

            //    else if (aioair == 2)
            //    {
            //        Konstruktor.Methoden.AioCoolings.AioCoolingsSelection(mypc);
            //        aioorair = true;
            //    }

            //    else
            //    {
            //        Console.WriteLine("Ungültige Eingabe. Bitte erneut auswählen.");
            //    }

            //} while (!aioorair);
            //Console.Clear();
            //Console.WriteLine("\x1b[3J");

            SATADrive.SATADrivesSelection(mypc);
            Console.Clear();
            Console.WriteLine("\x1b[3J");

            //if (mypc.Motherboard.DriveSupport.Contains("PCIe 4.0"))
            //{

            //    NVMeDrive.NVMeDrivesSelection(mypc);
            //    Console.Clear();
            //    Console.WriteLine("\x1b[3J");
            //}

            //NVMeDriverCheck.NVMeDriveCheck(mypc);

            //Konstruktor.Methoden.Fans.FansSelection(mypc);
            //Console.Clear();
            //Console.WriteLine("\x1b[3J");

            //Konstruktor.Methoden.Extra.ExtrasSelection(mypc);
            //Console.Clear();
            //Console.WriteLine("\x1b[3J");

            //Konstruktor.Checks.PriceCheck.Pricecheck(mypc);

            Console.WriteLine("Ihr System:");
            //Console.WriteLine("Gehäuse: " + mypc.Case.Name + " | " + mypc.Case.Price + "€");
            //Console.WriteLine("Netzteil: " + mypc.Psu.Name + " | " + mypc.Psu.Price + "€");
            //Console.WriteLine("Motherboard: " + mypc.Motherboard.Name + " | " + mypc.Motherboard.Price + "€");
            //Console.WriteLine("CPU: " + mypc.Cpu.Name + " | " + mypc.Cpu.Price + "€");
            //Console.WriteLine("Grafikkarte: " + mypc.Gpu.Name + " | " + mypc.Gpu.Price + "€");
            //Console.WriteLine("RAM: " + mypc.Ram.Name + " | " + mypc.Ram.Price + "€");
            //Console.WriteLine("Kühlung: " + mypc.Coolings.Name + " | " + mypc.Coolings.Price + "€");
            Console.WriteLine("SATA-Laufwerke: " + string.Join(", ", mypc.DriveSATA.Select(d => d.Name)) + "| " + string.Join("€, ", mypc.DriveSATA.Select(b => b.Price)));
            //Console.WriteLine("NVMe-Laufwerke: " + string.Join(", ", mypc.DriveNVMe.Select(f => f.Name)) + "| " + string.Join("€, ", mypc.DriveNVMe.Select(p => p.Price)));
            //var fanText = string.Join(", ",
            //    mypc.Fans
            //        .GroupBy(m => m.Name)
            //        .Select(n =>
            //        {
            //            int count = n.Count();
            //            float unitPrice = n.First().Price;
            //            float totalPrice = count * unitPrice;

            //            return $"{count}x {n.Key} ({totalPrice}€)";
            //        })
            //);
            //Console.WriteLine("Lüfter: " + fanText);
            //Console.WriteLine("Extras: " + string.Join(", ", mypc.Extras.Select(d => d.Name)) + "| " + string.Join("€, ", mypc.Extras.Select(o => o.Price)));
            //Console.WriteLine("--------------------------------------------------------------");
            //Console.ForegroundColor = ConsoleColor.DarkGreen;
            //Console.WriteLine("Gesamtpreis: " + mypc.Price + "€");
            //Console.ResetColor();
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