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

            Konstruktor.Checks.FormfactorCheck.FormCheck(mypc);

            Konstruktor.Methoden.CPUs.CPUSelection(mypc);
            Console.Clear();
            Console.WriteLine("\x1b[3J");

            Konstruktor.Checks.SocketCheck.CheckSocket(mypc);

            Konstruktor.Methoden.GPUs.GPUSelection(mypc);
            Console.Clear();
            Console.WriteLine("\x1b[3J");

            Konstruktor.Checks.PSUCheck.CheckPSU(mypc);

            Konstruktor.Methoden.RAMs.RAMSelection(mypc);
            Console.Clear();
            Console.WriteLine("\x1b[3J");

            Konstruktor.Checks.RAMCheck.RAMChecking(mypc);

            Console.WriteLine("Wollen sie eine Luftkühlung(1) oder eine Wasserkühlung(2)?");
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
            Console.Clear();
            Console.WriteLine("\x1b[3J");

            SATADrive.SATADrivesSelection(mypc);
            Console.Clear();
            Console.WriteLine("\x1b[3J");

            if (mypc.Motherboard.DriveSupport.Contains("PCIe 4.0"))
            {

                NVMeDrive.NVMeDrivesSelection(mypc);
                Console.Clear();
                Console.WriteLine("\x1b[3J");
            }

            NVMeDriverCheck.NVMeDriveCheck(mypc);

            Konstruktor.Methoden.Fans.FansSelection(mypc);
            Console.Clear();
            Console.WriteLine("\x1b[3J");

            Konstruktor.Methoden.PSUs.PSUSelection(mypc);
            Console.Clear();
            Console.WriteLine("\x1b[3J");

            Konstruktor.Methoden.Cases.CaseSelection(mypc);
            Console.Clear();
            Console.WriteLine("\x1b[3J");

            Konstruktor.Methoden.Extra.ExtrasSelection(mypc);
            Console.Clear();
            Console.WriteLine("\x1b[3J");

            Konstruktor.Checks.FormfactorCheck.FormCheck(mypc);
            Konstruktor.Checks.SocketCheck.CheckSocket(mypc);
            Konstruktor.Checks.PSUCheck.CheckPSU(mypc);
            Konstruktor.Checks.RAMCheck.RAMChecking(mypc);
            NVMeDriverCheck.NVMeDriveCheck(mypc);
            Konstruktor.Checks.PriceCheck.Pricecheck(mypc);

            Console.WriteLine("Ihr System:");
            Console.WriteLine("Gehäuse: " + mypc.Case.Name + " | " + mypc.Case.Price + "€");
            Console.WriteLine("Netzteil: " + mypc.Psu.Name + " | " + mypc.Psu.Price + "€");
            Console.WriteLine("Motherboard: " + mypc.Motherboard.Name + " | " + mypc.Motherboard.Price + "€");
            Console.WriteLine("CPU: " + mypc.Cpu.Name + " | " + mypc.Cpu.Price + "€");
            Console.WriteLine("Grafikkarte: " + mypc.Gpu.Name + " | " + mypc.Gpu.Price + "€");
            Console.WriteLine("RAM: " + mypc.Ram.Name + " | " + mypc.Ram.Price + "€");
            Console.WriteLine("Kühlung: " + mypc.Coolings.Name + " | " + mypc.Coolings.Price + "€");            

            var SATAText = string.Join(", ",
                mypc.DriveSATA
                    .GroupBy(h => h.Name)
                    .Select(k =>
                    {
                        int count = k.Count();
                        float unitprice = k.First().Price;
                        float totalPrice = count * unitprice;

                        return $"{count}x {k.Key} ({totalPrice}€)";
                    })
            );
            Console.WriteLine($"SATA-Laufwerke: {SATAText}");

            var NVMeText = string.Join(", ",
                mypc.DriveNVMe
                    .GroupBy(a => a.Name)
                    .Select(a =>
                    {
                        int count = a.Count();
                        float unitprice = a.First().Price;
                        float totalPrice = count * unitprice;

                        return $"{count}x {a.Key} ({totalPrice}€)";
                    })
            );
            Console.WriteLine($"NVMe-Laufwerke: {NVMeText}");

            var fanText = string.Join(", ",
                mypc.Fans
                    .GroupBy(m => m.Name)
                    .Select(l =>
                    {
                        int count = l.Count();
                        float unitPrice = l.First().Price;
                        float totalPrice = count * unitPrice;

                        return $"{count}x {l.Key} ({totalPrice}€)";
                    })
            );
            Console.WriteLine("Lüfter: " + fanText);

            var extrasText = string.Join(", ",
                mypc.Extras
                    .GroupBy(e => e.Name)
                    .Select(n =>
                    {
                        int count = n.Count();
                        float unitPrice = n.First().Price;
                        float totalPrice = count * unitPrice;

                        return $"{count}x {n.Key} ({totalPrice}€)";
                    })
            );
            Console.WriteLine("Lüfter: " +  extrasText);

            Console.WriteLine("--------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Gesamtpreis: " + mypc.Price + "€");
            Console.ResetColor();
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