using Components;
using System;
using System.Collections.Generic;
using System.Linq;
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


            Console.WriteLine("Wie viele NVMe-Festplatten wollen sie einbauen? Bei 0 werden keine weiteren hinzugefügt.");
            int.TryParse(Console.ReadLine(), out anzahl);

            if (anzahl != 0)
            {
                Console.WriteLine("NVMe-Speicher");
                Console.WriteLine();
            
                foreach (var drivess in drives)
                {
                    Console.WriteLine($"({i}) {drivess.Name} | Speichergröße: {drivess.Size} Euro | Preis: {drivess.Price}€");
                    Console.WriteLine();
                    i++;
                }
                int j = 1;

                while (j <= anzahl)
                {
                    do
                    {                    
                        if (success == false)
                        {
                            Console.WriteLine("Auswahl NVMe-Drives: ");
                            int.TryParse(Console.ReadLine(), out pick);

                            if (pick == 0)
                            {
                                Console.WriteLine("ungültige Zahl. Nochmal auswählen.");
                            }

                            else if (j < anzahl)
                            {
                                Console.WriteLine($"Wahl Nummer {j} wurde getroffen.");
                            }

                            else if (pick <= anzahldrives)
                            {
                                success = true;
                            }

                            else
                            {
                                Console.WriteLine("ungültige Zahl. Nochmal auswählen.");
                            }

                            int actualpick = pick - 1;
                            var selecteddrive = drives[actualpick];
                            mypc.DriveNVMe.Add(selecteddrive);
                            Console.WriteLine($"{selecteddrive.Name} wurde als NVMe gewählt.");
                            j++;
                        }
                     

                    } while (success == false);

                    Console.WriteLine("Drücken sie eine Taste, um zum nächsten Punkt zu springen.");
                    Console.ReadKey();

                }





            }
        }
    }
    public class NVMeDrives                                         ///Die Blaupause für die verscheidenen Festplatten
    {
        public string Name { get; set; }
        public string Connection { get; set; }          //SATA, PCIe...
        public float Size { get; set; }                 //500GB, 1TB...
        public float Price { get; set; }
        public string[] Categories { get; set; }
    }
}
