using System.Dynamic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Nodes;
using Components;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(250, 30);

            
            string jsonTextCPU = File.ReadAllText("cpus.json");
            string jsonTextPSU = File.ReadAllText("psus.json");
            string jsonTextGPU = File.ReadAllText("gpus.json");
            string jsonTextMotherboard = File.ReadAllText("motherboards.json");
            string jsonTextRAM = File.ReadAllText("rams.json");
            string jsonTextCooling = File.ReadAllText("coolings.json");
            string jsonTextFAN = File.ReadAllText("fans.json");
            string jsonTextExtra = File.ReadAllText("extras.json");
            string jsonTextDrive = File.ReadAllText("drives.json");


            List<CPU>? cpus = JsonSerializer.Deserialize<List<CPU>>(jsonTextCPU);
            
            List<PSU>? psus = JsonSerializer.Deserialize<List<PSU>>(jsonTextPSU);
            List<GPU>? gpus = JsonSerializer.Deserialize<List<GPU>>(jsonTextGPU);
            List<Motherboard>? motherboards = JsonSerializer.Deserialize<List<Motherboard>>(jsonTextMotherboard);
            List<RAM>? rams = JsonSerializer.Deserialize<List<RAM>>(jsonTextRAM);
            List<Cooling>? coolings = JsonSerializer.Deserialize<List<Cooling>>(jsonTextCooling);
            List<Fan>? fans = JsonSerializer.Deserialize<List<Fan>>(jsonTextFAN);
            List<Extras>? extras = JsonSerializer.Deserialize<List<Extras>>(jsonTextExtra);
            List<Drives>? drives = JsonSerializer.Deserialize<List<Drives>>(jsonTextDrive);

            Console.WriteLine("Welches Mainboard ist gewünscht?");
            CaseSelection();
        }

        static void CaseSelection()
        {
            string jsonTextCase = File.ReadAllText("cases.json");
            JsonArray casesarray = JsonNode.Parse(jsonTextCase).AsArray();
            int anzahlcases = casesarray.Count;
            List<Case>? cases = JsonSerializer.Deserialize<List<Case>>(jsonTextCase);
            int i = 1;

            Console.WriteLine("Cases");
            Console.WriteLine();
            foreach (var casee in cases)
            {
                Console.WriteLine($"({i}) {casee.Name} | Höhe: {casee.Height}cm | Breite: {casee.Width}cm | Tiefe: {casee.Depth}cm \n    Lüfterpläte: {casee.NumberCaseFans} Stück | Formfaktor: {casee.Fit} | Preis: {casee.Price} Euro ");
                Console.WriteLine();
                i++;
            }

            int pick = 0;
            bool success = false;

            do
            {
                if (success == false)
                {
                    Console.WriteLine("Auswahl Case:");
                    int.TryParse((Console.ReadLine()), out pick);

                    if (pick <= anzahlcases)
                    {
                        success = true;
                    }

                    else
                    {
                        Console.WriteLine("ungültige Zahl. Nochmal auswählen.");
                    }
                }
            } while (success == false);


            Console.WriteLine("");


        }
    }
}

namespace Components
{
    public class Case                                          ///Die Blaupause für die verscheidenen Cases
    {
        public string Name { get; set; }
        public float Height { get; set; }               //in cm
        public float Width { get; set; }                //in cm
        public float Depth { get; set; }                //in cm
        public int NumberCaseFans { get; set; }
        public string Fit { get; set; }                 //ob ATX, mini-STX etc...
        public float Price { get; set; }
        public string[] Categories { get; set; }
    }

    public class PSU                                            ///Die Blaupause für die verscheidenen PSUs
    {
        public string Name { get; set; }
        public float Watt { get; set; }                 //in Watt
        public float Height { get; set; }               //in cm
        public float Width { get; set; }                //in cm
        public float Depth { get; set; }                //in cm
        public float Price { get; set; }
        public string[] Categories { get; set; }
    }

    public class CPU                                            ///Die Blaupause für die verscheidenen CPUs
    {
        public string Name { get; set; }
        public string Socket { get; set; }              //AM5, AM4, Z890...
        public float L3Cache { get; set; }              //128MB, 256MB...
        public float ClockSpeed { get; set; }           //4,1GHz...
        public float Price { get; set; }
        public string[] Categories { get; set; }
    }

    public class GPU                                            ///Die Blaupause für die verscheidenen GPUs
    {
        public string Name { get; set; }
        public float WattInput { get; set; }
        public float VRAMcapacity { get; set; }         //6GB, 8GB, 12GB...
        public string VRAMtype { get; set; }            //GDDR6, GDDR6x, GDDR7...
        public float Price { get; set; }
        public string[] Categories { get; set; }
    }

    public class Motherboard                                    ///Die Blaupause für die verscheidenen Motherboards
    {
        public string Name { get; set; }
        public string Fit { get; set; }                 //ob ATX, mini-STX etc...
        public string Socket { get; set; }              //AM5, AM4, Z890...
        public float Price { get; set; }
        public string DDRType { get; set; }             //DDR-4, DDR-5, DDR-5 RDIMM...
        public string[] Categories { get; set; }
    }

    public class RAM                                            ///Die Blaupause für die verscheidenen RAM-Speicher
    {
        public string Name { get; set; }
        public float Size { get; set; }                 //4GB-RAM, 16GB-RAM...
        public string Type { get; set; }                //DDR-4, DDR-5...
        public string Design { get; set; }              //DIMM, SO-DIMM, RDIMM...#
        public float ClockSpeed { get; set; }           //3000MHz, 6000MHz...
        public float Price { get; set; }
        public string[] Categories { get; set; }
    }

    public class Drives                                         ///Die Blaupause für die verscheidenen Festplatten
    {
        public string Name { get; set; }
        public string Connection { get; set; }          //SATA, PCIe...
        public float Size { get; set; }                 //500GB, 1TB...
        public string FormFactor { set; get; }          //12,5", NVME...
        public float Price { get; set; }
        public string[] Categories { get; set; }
    }

    public class Cooling                                        ///Die Blaupause für die verscheidenen Kühlungen
    {
        public string Name { get; set; }
        public string Form { get; set; }                //AiO, Aircolling....
        public float Price { get; set; }
        public string[] Categories { get; set; }
    }

    public class Fan                                            ///Die Blaupause für die verscheidenen Fans
    {
        public string Name { get; set; }
        public float Size { get; set; }                 //120mm, 140mm...
        public float Price { get; set; }
        public string[] Categories { get; set; }
    }

    public class Extras                                         ///Die zubuchbaren Extras
    {
        public string Name { get; set; }                //RGB-Module, Verkabelungen
        public string Description { get; set; }
        public float Price { get; set; }
        public string[] Categories { get; set; }    
    }

    
}


//Console.WriteLine("CPUs");
//foreach (var cpu in cpus)
//{
//    Console.WriteLine($"{cpu.Name} | Sockel: {cpu.Socket} | Cache: {cpu.L3Cache} MB | Takt: {cpu.ClockSpeed} GHz | Preis: {cpu.Price} €");
//    Console.WriteLine();
//}
//Console.WriteLine();

//Console.WriteLine("Cases");

//for(int i = 1; i =  )
//{
//    foreach (var Case in cases)
//    {
//    Console.WriteLine($"{Case.Name} | Höhe: {Case.Height}cm | Breite: {Case.Width}cm | Tiefe: {Case.Depth}cm | Lüfterplätze: {Case.NumberCaseFans} \n Formfaktor: {Case.Fit} | Material: {Case.Material} | Anschlüsse: {Case.Interfaces} | Preis: {Case.Price}€");
//    Console.WriteLine();
//    }
//}

//Console.WriteLine();

//Console.WriteLine("PSUs");
//foreach (var psu in psus)
//{
//    Console.WriteLine($"{psu.Name} | Leistung: {psu.Watt} Watt | Höhe: {psu.Height}cm | Breite: {psu.Width}cm | Tiefe: {psu.Depth}cm | Preis: {psu.Price}€");
//    Console.WriteLine();
//}

//Console.WriteLine("GPUs");
//foreach (var gpu in gpus)
//{
//    Console.WriteLine($"{gpu.Name} | Leistung: {gpu.Watt} Watt | Höhe: {gpu.Height}cm | Breite: {psu.Width}cm | Tiefe: {psu.Depth}cm | Preis: {psu.Price}€");
//    Console.WriteLine();
//}

//    Console.WriteLine("Welchen zweck soll der PC erfüllen?\n Gaming(1), Rendering(2), Server(3), Office(4)");
//    bool success = false;
//    int pick = 0;

//    do
//    {
//        if (success == false)
//        {
//            int.TryParse((Console.ReadLine()), out pick);

//            if (pick <= 4)
//            {
//                success = true;
//            }

//            else
//            {
//                Console.WriteLine("ungültige Zahl. Nochmal auswählen.");
//            }
//        }
//    } while (success == false);

//    if (pick == 1)
//    {
//        Console.WriteLine("GAMING");
//        Console.WriteLine("Was für ein Gehäuse wollen sie haben?");

//        foreach( var pccases in cases )
//        {                    
//            Console.WriteLine( pccases.Categories );
//        }
//    }

//    else if (pick == 2)
//    {

//    }

//    else if (pick == 3)
//    {

//    }

//    else if (pick == 4)
//    {

//    }

//    Console.WriteLine("Fertig!");