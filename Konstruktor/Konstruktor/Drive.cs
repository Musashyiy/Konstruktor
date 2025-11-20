using Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Konstruktor
{
    public class Drive
    {
        public static string DrivesSelection(MyPc mypc)
        {
            string jsonTextDrive = File.ReadAllText("drives.json");
            JsonArray Drivesarray = JsonNode.Parse(jsonTextDrive).AsArray();
            int anzahldrives = Drivesarray.Count;
            List<Drives>? drives = JsonSerializer.Deserialize<List<Drives>>(jsonTextDrive);
            int i = 1;


            Console.WriteLine("Speicher");
            Console.WriteLine();
            foreach (var drivess in drives)
            {
                Console.WriteLine($"({i}) {drivess.Name} | Speichergröße: {drivess.Size} Euro | Konnektor:{string.Join(", ", drivess.Connection)} | Preis: {drivess.Price} Euro");
                Console.WriteLine();
                i++;
            }

            int pick = 0;
            bool success = false;

            do
            {
                if (success == false)
                {
                    Console.WriteLine("Auswahl Drives: ");
                    int.TryParse((Console.ReadLine()), out pick);

                    if (pick == 0)
                    {
                        Console.WriteLine("ungültige Zahl. Nochmal auswählen.");
                    }

                    else if (pick <= anzahldrives)
                    {
                        success = true;
                    }

                    else
                    {
                        Console.WriteLine("ungültige Zahl. Nochmal auswählen.");
                    }
                }
            } while (success == false);

            int actualpick = pick - 1;
            mypc.Drive = drives[actualpick];
            Console.WriteLine($"{drives[actualpick].Name} wurde als RAM gewählt.");

            Console.WriteLine("Drücken sie eine Taste, um zum nächsten Punkt zu springen.");
            Console.ReadKey();

            return mypc.Drive.Name;
        }
    }
    public class Drives                                         ///Die Blaupause für die verscheidenen Festplatten
    {
        public string Name { get; set; }
        public List<string> Connection { get; set; }          //SATA, PCIe...
        public float Size { get; set; }                 //500GB, 1TB...
        public float Price { get; set; }
        public string[] Categories { get; set; }
    }
}
