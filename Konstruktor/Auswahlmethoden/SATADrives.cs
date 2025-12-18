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
            char jumpSATA;

            Console.WriteLine("Soll eine SATA-Festplatte hinzugefügt werden?\n  Ja(y) oder Nein(n)?");
            char.TryParse(Console.ReadLine(), out jumpSATA);

            if(jumpSATA == 'y')
            {
                Console.WriteLine("Auswahl SATA-Speicher:");
                Console.WriteLine();

                foreach (var drivess in drives)
                {
                    Console.WriteLine($"({i}) {drivess.Name} | Speichergröße: {drivess.Size}MB | Schreibgeschwindigkeit: {drivess.WriteSpeedMBs}MB/s \n   Lesegeschwindigkeit: {drivess.ReadSpeedMBs}MB/s | Preis: {drivess.Price}€");
                    Console.WriteLine();
                    i++;
                }

                bool moredrivesyesno = false;
                int j = 1;                

                do
                {

                    do
                    {
                        success = false;


                        if (success == false)
                        {
                            Console.WriteLine("Auswahl SATA-Drives: ");
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
                            mypc.DriveSATA.Add(selecteddrive);
                            Console.WriteLine($"{selecteddrive.Name} wurde als SATA gewählt.");
                            j++;
                        }

                    } while (success == false);

                    bool newSATA = false;

                    do
                    {
                        Console.WriteLine("Soll eine weitere Festplatte hinzugefügt werden?\n   Ja(y) oder Nein(n)?");
                        char numberdriveyesno;
                        char.TryParse(Console.ReadLine(), out numberdriveyesno);

                        if (numberdriveyesno == 'y')
                        {
                            Console.WriteLine("Wählen sie eine weitere SATA-Festplatte aus.");
                            newSATA = true;
                        }

                        else if (numberdriveyesno == 'n')
                        {
                            moredrivesyesno = true;
                            newSATA = true;
                        }

                        else
                        {
                            Console.WriteLine("Ungültige Auswahl. Bitte erneut auswählen.");
                        }

                    } while (!newSATA);

                } while (!moredrivesyesno);
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
        public float ReadSpeedMBs { get; set; }
        public float WriteSpeedMBs { get; set; }
        public float Price { get; set; }
        public string[] Categories { get; set; }
    }
}
