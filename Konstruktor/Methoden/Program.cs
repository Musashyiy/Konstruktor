using Components;

using Konstruktor.Methoden;
using System.Collections.Generic;
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
        public static void Main(string[] args)
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
                Console.WriteLine("Willkommen zum PC-Konfigurator!\nSuchen sie sich eine Komponente aus, die bearbeitet werden soll.\n(1)Motherboard\n(2)CPU\n(3)GPU\n(4)RAM\n(5)CPU-Kühlung\n(6)SATA-Festplatten\n(7)NVMe-Festplatten\n(8)Lüfter\n(9)Netzteil\n(10)Gehäuse\n(11)Extras");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Es wird empfohen mit dem Motherboard anzufangen.");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("Ihr System:");
                Console.WriteLine("Motherboard: " + (mypc.Motherboard == null ? "- keine ausgewählt -" : $"{mypc.Motherboard.Name}  |  {mypc.Motherboard.Price:0.00}€"));
                Console.WriteLine("CPU: " + (mypc.Cpu == null ? "- keine ausgewählt -" : $"{mypc.Cpu.Name}  |  {mypc.Cpu.Price:0.00}€"));
                Console.WriteLine("Grafikkarte: " + (mypc.Gpu == null ? "- keine ausgewählt -" : $"{mypc.Gpu.Name}  |  {mypc.Gpu.Price:0.00}€"));
                Console.WriteLine("RAM: " + (mypc.Ram == null ? "- keine ausgewählt -" : $"{mypc.Ram.Name}  |  {mypc.Ram.Price:0.00}€"));
                Console.WriteLine("CPU-Kühlung: " + (mypc.Coolings == null ? "- keine ausgewählt -" : $"{mypc.Coolings.Name}  |  {mypc.Coolings.Price:0.00}€"));
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
                Console.WriteLine("Netzteil: " + (mypc.Psu == null ? "- keine ausgewählt -" : $"{mypc.Psu.Name}  |  {mypc.Psu.Price:0.00}€")); ;
                Console.WriteLine("Gehäuse: " + (mypc.Case == null ? "- keine ausgewählt -" : $"{mypc.Case.Name}  |  {mypc.Case.Price:0.00}€"));
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

                bool rightchoose = false;
                while (!rightchoose)
                {
                    int countcomp = components.Count();
                    int compselect;
                    Console.WriteLine();
                    Console.WriteLine("Auswahl:");
                    int.TryParse(Console.ReadLine(), out compselect);

                    if (compselect > countcomp)
                    {
                        Console.WriteLine("Ungültige Eingabe. Nochmals auswählen.");
                    }
                    else
                    {
                        components[compselect - 1].Select(mypc);
                        Console.WriteLine("Wollen sie eine weitere Komponente aussuchen?\n  Ja(y) oder Nein(n)?");
                        char anothercomp;
                        char.TryParse(Console.ReadLine(), out anothercomp);
                        if (anothercomp == 'n') nextcomp = true;
                        rightchoose = true;
                        Console.Clear();
                        Console.WriteLine("\x1b[3J");
                    }
                }
            }

            //Checks.PriceCheck.Pricecheck(mypc);
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
        public List<Fan> Fans120 { get; set; } = new();
        public List<Fan> Fans140 { get; set; } = new();
        public List<Extra> Extras { get; set; } = new();
        public float Price { get; set; }
    }

    
}