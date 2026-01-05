using Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Konstruktor.Methoden
{
    public class NVMeDrive
    {
        public static void NVMeDrivesSelection(MyPc mypc)
        {
            string jsonTextDrive = File.ReadAllText("json/NVMe.json");
            JsonArray NVMedrivesarray = JsonNode.Parse(jsonTextDrive).AsArray();
            int anzahldrives = NVMedrivesarray.Count;
            List<NVMeDrives>? drives = JsonSerializer.Deserialize<List<NVMeDrives>>(jsonTextDrive);
            int i = 1;
            bool success = false;
            int anzahl;
            int pick = 0;
            char jumpNVMe;

            Console.WriteLine("Soll eine NVMe hinzugefügt werden?\n  Ja(y) oder Nein(n)?");
            char.TryParse(Console.ReadLine(), out jumpNVMe);

            if(jumpNVMe == 'y')
            {
                Console.WriteLine("Auswahl NVMe-Speicher:");
                Console.WriteLine();
            
                foreach (var drivess in drives)
                {
                    Console.WriteLine($"({i}) {drivess.Name} | Speichergröße: {drivess.Size}MB  | Schreibgeschwindigkeit: {drivess.WriteSpeedMBs}MB/s \n   Lesegeschwindigkeit: {drivess.ReadSpeedMBs}MB/s | Preis: {drivess.Price}€");
                    Console.WriteLine();
                    i++;
                }

                int j = 1;
                bool moredrivesyesno = false;

                do
                {
                    do
                    {
                        success = false;

                        if (success == false)
                        {
                            Console.WriteLine("Auswahl NVMe-Drives: ");
                            int.TryParse(Console.ReadLine(), out pick);

                            if (pick == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("ungültige Zahl. Nochmal auswählen.");
                                Console.ResetColor();
                            }                          

                            else if (pick <= anzahldrives)
                            {
                                success = true;
                            }

                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("ungültige Zahl. Nochmal auswählen.");
                                Console.ResetColor();
                            }

                            int actualpick = pick - 1;
                            var selecteddrive = drives[actualpick];
                            mypc.DriveNVMe.Add(selecteddrive);
                            Console.WriteLine($"{selecteddrive.Name} wurde als NVMe gewählt.");
                            j++;
                        }                     

                    } while (success == false);

                    bool newNVMe = false;

                    do
                    {
                        char numberdriveyesno;
                        Console.WriteLine("Soll noch eine NVMe hiunzugefügt werden?\n  Ja(y) oder Nein(n)?");
                        char.TryParse(Console.ReadLine(), out numberdriveyesno);
                    
                        if (numberdriveyesno == 'y')
                        {
                            Console.WriteLine("Wählen sie eine weitere NVMe aus.");
                            newNVMe = true;
                        }

                        else if (numberdriveyesno == 'n')
                        {
                            moredrivesyesno = true;
                            newNVMe = true;
                        }

                        else
                        {
                            Console.WriteLine("Ungültige Auswahl. Bitte erneut auswählen.");
                        }

                    } while (!newNVMe);

                } while (!moredrivesyesno);

            }            

            Console.WriteLine("Drücken sie eine Taste, um zum nächsten Punkt zu springen.");
            Console.ReadKey();
        }
    }
    public class NVMeDrives                                         ///Die Blaupause für die verscheidenen Festplatten
    {
        public string Name { get; set; }
        public string Connection { get; set; }          //SATA, PCIe...
        public float Size { get; set; }                 //500GB, 1TB...
        public float ReadSpeedMBs { get; set; }
        public float WriteSpeedMBs { get; set; }
        public float Price { get; set; }
        public string[] Categories { get; set; }
    }
}
