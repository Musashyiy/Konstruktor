using Components;

using Konstruktor.Methoden;
using System.ComponentModel;
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
            MyPc mypc = new MyPc();
            bool nextcomp = false;
            string SATAText;
            string NVMeText;
            string fanText;
            string extrasText;
            while (!nextcomp)
            {
                Console.OutputEncoding = Encoding.UTF8;
                //Console.SetWindowSize(250, 30);
                List<IComponent> components = new List<IComponent>();
                components.Add(new Motherboard());
                components.Add(new CPU());
                components.Add(new GPU());
                components.Add(new RAM());
                components.Add(new CoolingBlueprint());
                components.Add(new SATADrives());                
                components.Add(new NVMeDrive());                              
                components.Add(new Fan());
                components.Add(new PSU());
                components.Add(new Case());
                components.Add(new Extra());
                Console.WriteLine("Willkommen zum PC-Konfigurator!\nSuchen sie sich eine Komponente aus, die bearbeitet werden soll.\n(1)Motherboad\n(2)CPU\n(3)GPU\n(4)RAM\n(5)CPU-Kühlung\n(6)SATA-Festplatten\n(7)NVMe-Festplatten\n(8)Lüfter\n(9)Netzteil\n(10)Gehäuse\n(11)Extras");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Es wird empfohen mit dem Motherboard anzufangen.");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("Ihr System:");
                Console.WriteLine("Gehäuse: " + (mypc.Case == null ? "- keine ausgewählt -" : $"{mypc.Case.Name}  |  {mypc.Case.Price:0.00}€"));
                Console.WriteLine("Netzteil: " + (mypc.Psu == null ? "- keine ausgewählt -" : $"{mypc.Psu.Name}  |  {mypc.Psu.Price:0.00}€")); ;
                Console.WriteLine("Motherboard: " + (mypc.Motherboard == null ? "- keine ausgewählt -" : $"{mypc.Motherboard.Name}  |  {mypc.Motherboard.Price:0.00}€"));
                Console.WriteLine("CPU: " + (mypc.Cpu == null ? "- keine ausgewählt -" : $"{mypc.Cpu.Name}  |  {mypc.Cpu.Price:0.00}€"));
                Console.WriteLine("Grafikkarte: " + (mypc.Gpu == null ? "- keine ausgewählt -" : $"{mypc.Gpu.Name}  |  {mypc.Gpu.Price:0.00}€"));
                Console.WriteLine("RAM: " + (mypc.Ram == null ? "- keine ausgewählt -" : $"{mypc.Ram.Name}  |  {mypc.Ram.Price:0.00}€"));
                Console.WriteLine("Kühlung: " + (mypc.Coolings == null ? "- keine ausgewählt -" : $"{mypc.Coolings.Name}  |  {mypc.Coolings.Price:0.00}€"));

                if (mypc.DriveSATA == null || mypc.DriveSATA.Count == 0)
                {
                    SATAText = "— keine ausgewählt —";
                }
                else
                {
                    SATAText = string.Join(", ",
                        mypc.DriveSATA
                            .GroupBy(h => h.Name)
                            .Select(k =>
                                $"{k.Count()}x {k.Key} ({k.Count() * k.First().Price}€)"
                            )
                    );
                }

                Console.WriteLine($"SATA-Laufwerke: {SATAText}");

                if (mypc.DriveNVMe == null || mypc.DriveNVMe.Count == 0)
                {
                    NVMeText = "— keine ausgewählt —";
                }
                else
                {
                    NVMeText = string.Join(", ",
                        mypc.DriveNVMe
                            .GroupBy(a => a.Name)
                            .Select(a =>
                                $"{a.Count()}x {a.Key} ({a.Count() * a.First().Price}€)"
                            )
                    );
                }
                Console.WriteLine($"NVMe-Laufwerke: {NVMeText}");

                if (mypc.Fans == null || mypc.Fans.Count == 0)
                {
                    fanText = "— keine ausgewählt —";
                }
                else
                {
                    fanText = string.Join(", ",
                        mypc.Fans
                            .GroupBy(m => m.Name)
                            .Select(l =>
                                $"{l.Count()}x {l.Key} ({l.Count() * l.First().Price}€)"
                            )
                    );
                }
                Console.WriteLine("Lüfter: " + fanText);

                if (mypc.Extras == null || mypc.Extras.Count == 0)
                {
                    extrasText = "— keine ausgewählt —";
                }
                else
                {
                    extrasText = string.Join(", ",
                        mypc.Extras
                            .GroupBy(e => e.Name)
                            .Select(n =>
                                $"{n.Count()}x {n.Key} ({n.Count() * n.First().Price}€)"
                            )
                    );
                }
                Console.WriteLine("Extras: " + extrasText);

                int compselect;
                int.TryParse(Console.ReadLine(), out compselect);
                components[compselect - 1].Select(mypc);
                Console.WriteLine("Wollen sie eine weitere Komponente aussuchen?\n  Ja(y) oder Nein(n)?");
                char anothercomp;
                char.TryParse(Console.ReadLine(), out anothercomp);
                if (anothercomp == 'n') nextcomp = true;
                Console.Clear();
            }
            //Checks.PriceCheck.Pricecheck(mypc);
            //Console.WriteLine($"Gesamtsumme des Systems: {mypc.Price}€");

            

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

            //Checkout.Checkoutgenerate(mypc);

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
        public List<NVMeDrive> DriveNVMe { get; set; } = new();
        public CoolingBlueprint Coolings { get; set; }
        public List<Fan> Fans { get; set; } = new();
        public List<Extra> Extras { get; set; } = new();
        public float Price { get; set; }
    }

    
}