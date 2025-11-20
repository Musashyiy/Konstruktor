using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Nodes;
using Components;
using Konstruktor;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(250, 30);

            MyPc mypc = new MyPc();

            Console.WriteLine("Gehäuse auswählen:");
            Konstruktor.Cases.CaseSelection(mypc);
            Console.Clear();

            //Console.WriteLine("Netzteil auswählen:");
            //Konstruktor.PSUs.PSUSelection(mypc);
            //Console.Clear();

            //Console.WriteLine("Mainboard auswählen:");
            //Konstruktor.Mainboards.MainboardSelection(mypc);
            //Console.Clear();

            //Konstruktor.FormfactorCheck.FormCheck(mypc);

            //Console.WriteLine("CPU auswählen:");
            //Konstruktor.CPUs.CPUSelection(mypc);
            //Console.Clear();

            //Konstruktor.SocketCheck.CheckSocket(mypc);

            //Console.WriteLine("GPU auswählen:");
            //Konstruktor.GPUs.GPUSelection(mypc);
            //Console.Clear();

            //Konstruktor.PSUCheck.CheckPSU(mypc);

            //Console.WriteLine("RAM-Riegel auswählen:");
            //Konstruktor.RAMs.RAMSelection(mypc);
            //Console.Clear();

            //Konstruktor.RAMCheck.RAMChecking(mypc);

            //Console.WriteLine("Kühlung auswählen:");
            //Konstruktor.Coolings.CoolingsSelection(mypc);
            //Console.Clear();

            //Console.WriteLine("Speicherlaufwerke auswählen:");
            //Konstruktor.Drive.DrivesSelection(mypc);
            //Console.Clear();

            //Konstruktor.DriverCheck.DriveCheck(mypc);

            Console.WriteLine("Lüfter auswählen:");
            Konstruktor.Fans.FansSelection(mypc);
            Console.Clear();

            Console.WriteLine("Extras auswählen:");
            Konstruktor.Extra.ExtrasSelection(mypc);
            Console.Clear();
                                    
            Console.WriteLine("Ihr System:");
            Console.WriteLine("Gehäuse: " + mypc.Case.Name);
            Console.WriteLine("Netzteil: " + mypc.Psu.Name);
            Console.WriteLine("Motherboard: " + mypc.Motherboard.Name);
            Console.WriteLine("CPU: " + mypc.Cpu.Name);
            Console.WriteLine("Grafikkarte: " + mypc.Gpu.Name);
            Console.WriteLine("RAM: " + mypc.Ram.Name);
            Console.WriteLine("Kühlung: " + mypc.Cooling.Name);
            Console.WriteLine("Speicherlaufwerke: " + mypc.Drive.Name);
            Console.WriteLine("Lüfter: " + mypc.Fans.Name);
            Console.WriteLine("Extras: " + mypc.Extras.Name);
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
        public Drives Drive { get; set; }
        public Drives DriveNumber { get; set; }
        public Cooling Cooling { get; set; }
        public Fan Fans  { get; set; } 
        public Fan NumberFans { get; set; }
        public Extras Extras { get; set; }           
    }        
}