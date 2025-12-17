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
    public class SATADrive
    {
        public static void SATADrivesSelection(MyPc mypc)
        {
            string jsonTextDrive = File.ReadAllText("json/SATA.json");
            JsonArray SATAdrivesarray = JsonNode.Parse(jsonTextDrive).AsArray();
            int anzahldrives = SATAdrivesarray.Count;
            List<SATADrives>? drives = JsonSerializer.Deserialize<List<SATADrives>>(jsonTextDrive);
            int i = 1;
            bool success = false;
            int anzahl;
            int pick = 0;

            
            Console.WriteLine("Wie viele SATA-Festplatten wollen sie einbauen? Bei 0 werden keine weiteren hinzugefügt.");
            int.TryParse(Console.ReadLine(), out anzahl);

            Console.WriteLine("SATA-Speicher");
            Console.WriteLine();

            if (anzahl != 0)
            {
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
                            Console.WriteLine("Auswahl SATA-Drives: ");
                            int.TryParse(Console.ReadLine(), out pick);

                            if (pick == 0)
                            {
                                Console.WriteLine("Es werden keine weiteren Laufwerke hinzugefügt.");
                                success = true;
                                break;
                            }

                            else if (j < anzahl)
                            {

                            }

                            else if (pick <= anzahldrives)
                            {
                                success = true;
                            }

                            else if (pick > anzahldrives)
                            {
                                Console.WriteLine("ungültige Zahl. Nochmal auswählen.");
                            }

                            int actualpick = pick - 1;
                            var selecteddrive = drives[actualpick];
                            mypc.DriveSATA.Add(selecteddrive);
                            Console.WriteLine($"{selecteddrive.Name} wurde als SATA gewählt.");
                            j++;
                        }

                    } while (success == false);
                }


            }
                Console.WriteLine("Drücken sie eine Taste, um zum nächsten Punkt zu springen.");
                Console.ReadKey();
        }
    }
    public class SATADrives                                         ///Die Blaupause für die verscheidenen Festplatten
    {
        public string Name { get; set; }
        public string Connection { get; set; }          //SATA, PCIe...
        public float Size { get; set; }                 //500GB, 1TB...
        public float Price { get; set; }
        public string[] Categories { get; set; }
    }
}
