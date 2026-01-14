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
            bool NVMeys = false;

            do
            {

                Console.WriteLine("Soll eine NVMe hinzugefügt werden?\n  Ja(y) oder Nein(n)?");
                char.TryParse(Console.ReadLine(), out jumpNVMe);

                if(jumpNVMe == 'y')
                {
                    Console.WriteLine("Auswahl NVMe-Speicher:");
                    Console.WriteLine($"Sie können maximal {mypc.Motherboard.NVMeplaces} NVMe-Festplatten auswählen.");
                    Console.WriteLine();
                    int numberplacesNVMe = mypc.Motherboard.NVMeplaces;


                    foreach (var drivess in drives)
                    {
                        Console.WriteLine($"({i}) {drivess.Name} | Speichergröße: {drivess.Size}MB  | Schreibgeschwindigkeit: {drivess.WriteSpeedMBs}MB/s \n   Lesegeschwindigkeit: {drivess.ReadSpeedMBs}MB/s | Kategorien: {string.Join(", ", drivess.Categories)} | Preis: {drivess.Price}€");
                        Console.WriteLine();
                        i++;
                    }

                    
                    bool moredrivesyesno = false; 
                    
                    do
                    {
                        char numberdriveyesno = 'n';

                        for (int h = 1 ; h <=  numberplacesNVMe; h++)
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
                                }                     

                            } while (success == false);

                            bool newNVMe = false;

                            if (h == numberplacesNVMe)
                            {
                                newNVMe = true;
                            }

                            while (!newNVMe || numberplacesNVMe == 0)
                            {
                                
                                
                                Console.WriteLine("Soll noch eine NVMe hiunzugefügt werden?\n  Ja(y) oder Nein(n)?");
                                char.TryParse(Console.ReadLine(), out numberdriveyesno);
                    
                                if (numberdriveyesno == 'y')
                                {
                                    numberplacesNVMe = numberplacesNVMe - 1;
                                    Console.WriteLine($"Sie können noch {numberplacesNVMe} NVMe-Festplatten auswählen.");
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
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("ungültige Zahl. Nochmal auswählen.");
                                    Console.ResetColor();
                                }

                            }

                            if (numberdriveyesno == 'n' || numberplacesNVMe == 0)
                            {
                                break;
                            }
                        }

                        if (numberdriveyesno == 'n' || numberplacesNVMe == 0)
                        {
                            Console.WriteLine("Es werden/können keine weiteren Festplatten mehr ausgew#hlt werden.");
                            break;
                        }                        

                    } while (!moredrivesyesno);

                    NVMeys = true;
                }

                else if (jumpNVMe == 'n')
                {
                    Console.WriteLine("Es werden keine weiteren NVMe-Festplatten hiunzugefügt.");
                    NVMeys = true;
                }

                else
                {
                    Console.WriteLine("Ungültige Auswahl. Bitte wählen sie nochmal.");
                }

            } while (!NVMeys);                

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Drücken sie eine Taste, um zum nächsten Punkt zu springen.");
            Console.ResetColor();
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
