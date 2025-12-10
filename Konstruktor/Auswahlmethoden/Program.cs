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

            Console.WriteLine("Gehäuse auswählen:");
            Konstruktor.Methoden.Cases.CaseSelection(mypc);
            Console.Clear();

            Console.WriteLine("Netzteil auswählen:");
            Konstruktor.Methoden.PSUs.PSUSelection(mypc);
            Console.Clear();

            Console.WriteLine("Mainboard auswählen:");
            Mainboards.MainboardSelection(mypc);
            Console.Clear();

            Konstruktor.Checks.FormfactorCheck.FormCheck(mypc);

            Console.WriteLine("CPU auswählen:");
            Konstruktor.Methoden.CPUs.CPUSelection(mypc);
            Console.Clear();

            Konstruktor.Checks.SocketCheck.CheckSocket(mypc);

            Console.WriteLine("GPU auswählen:");
            Konstruktor.Methoden.GPUs.GPUSelection(mypc);
            Console.Clear();

            Konstruktor.Checks.PSUCheck.CheckPSU(mypc);

            Console.WriteLine("RAM-Riegel auswählen:");
            Konstruktor.Methoden.RAMs.RAMSelection(mypc);
            Console.Clear();

            Konstruktor.Checks.RAMCheck.RAMChecking(mypc);

            Console.WriteLine("Kühlung auswählen:");
            Console.WriteLine( "Wollen sie eine Luftkühlung(1) oder eine Wasserkühlung(2)?");
            int aioair;
            bool aioorair = false;
            int.TryParse(Console.ReadLine(), out aioair);

            do
            {
                if (aioair == 1)
                {
                    Konstruktor.Methoden.AirCooling.AirCoolingsSelection(mypc);
                    aioorair = true;
                }

                else if (aioair == 2)
            {
                    Konstruktor.Methoden.AioCoolings.AioCoolingsSelection(mypc);
                    aioorair = true;
                }

                else
                {
                    Console.WriteLine("Ungültige Eingabe. Bitte erneut auswählen.");
            }

            } while (!aioorair);


            Console.WriteLine("SATA-Speicherlaufwerke auswählen:");
            SATADrive.SATADrivesSelection(mypc);
            Console.Clear();

            if (mypc.Motherboard.DriveSupport.Contains("PCIe 4.0"))
            {
                Console.WriteLine("NVMe-Speicherlaufwerke auswählen:");
                NVMeDrive.NVMeDrivesSelection(mypc);
                Console.Clear();
            }

            NVMeDriverCheck.NVMeDriveCheck(mypc);

            Console.WriteLine("Lüfter auswählen:");
            Konstruktor.Methoden.Fans.FansSelection(mypc);
            Console.Clear();

            Console.WriteLine("Extras auswählen:");
            Konstruktor.Methoden.Extra.ExtrasSelection(mypc);
            Console.Clear();

            //Konstruktor.Checks.VolumeCheck.MeasurmentCheck(mypc);

            Konstruktor.Checks.PriceCheck.Pricecheck(mypc);

            Console.WriteLine("Ihr System:");
            Console.WriteLine("Gehäuse: " + mypc.Case.Name);
            Console.WriteLine("Netzteil: " + mypc.Psu.Name);
            Console.WriteLine("Motherboard: " + mypc.Motherboard.Name);
            Console.WriteLine("CPU: " + mypc.Cpu.Name);
            Console.WriteLine("Grafikkarte: " + mypc.Gpu.Name);
            Console.WriteLine("RAM: " + mypc.Ram.Name);
            Console.WriteLine("Kühlung: " + mypc.Coolings.Name);
            Console.WriteLine("SATA-Laufwerke: " + string.Join(", ", mypc.DriveSATA.Select(d => d.Name)));
            Console.WriteLine("NVMe-Laufwerke: " + string.Join(", ", mypc.DriveNVMe.Select(f => f.Name)));

            var fanText = string.Join(", ",
                mypc.Fans
                    .GroupBy(m => m.Name)
                    .Select(n => $"{n.Count()}x {n.Key}"));

            Console.WriteLine("Lüfter: " + fanText);

            Console.WriteLine("Extras: " + string.Join(", ", mypc.Extras.Select(d => d.Name)));
            Console.WriteLine();
            Console.WriteLine("Gesamtpreis: " + mypc.Price + "€");
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