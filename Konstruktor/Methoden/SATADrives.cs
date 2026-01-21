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
    
    

    public class SATADrives : IComponent                                         ///Die Blaupause für die verscheidenen Festplatten
    {
        public string Name { get; set; }
        public string Connection { get; set; }          //SATA, PCIe...
        public float Size { get; set; }                 //500GB, 1TB...
        public float ReadSpeedMBs { get; set; }
        public float WriteSpeedMBs { get; set; }
        public float Price { get; set; }
        public string[] Categories { get; set; }
        public void Select(MyPc mypc)
        {
            Console.Clear();
            string jsonTextDrive = File.ReadAllText("json/SATA.json");
            JsonArray SATAdrivesarray = JsonNode.Parse(jsonTextDrive).AsArray();
            int anzahldrives = SATAdrivesarray.Count;
            List<SATADrives>? drives = JsonSerializer.Deserialize<List<SATADrives>>(jsonTextDrive);
            int i = 1;
            bool success = false;
            int anzahl;
            int pick = 0;
            char jumpSATA;
            bool SATAyn = false;
            int numberplacesSATA;
            bool moredrivesyesno = false;
            bool SATAnummax = false;

            do
            {
                Console.WriteLine("Soll eine SATA-Festplatte hinzugefügt werden?\n  Ja(y) oder Nein(n)?");
                char.TryParse(Console.ReadLine(), out jumpSATA);

                if (jumpSATA == 'y')
                {
                    if (mypc.Motherboard != null)
                    {
                        Console.WriteLine("Auswahl SATA-Speicher:");
                        Console.WriteLine($"Sie können maximal {mypc.Motherboard.SATAplaces} SATA-Festplatten auswählen.");
                        Console.WriteLine();
                        numberplacesSATA = mypc.Motherboard.SATAplaces;

                        foreach (var drivess in drives)
                        {
                            Console.WriteLine($"({i}) {drivess.Name} | Speichergröße: {drivess.Size}MB | Schreibgeschwindigkeit: {drivess.WriteSpeedMBs}MB/s \n   Lesegeschwindigkeit: {drivess.ReadSpeedMBs}MB/s | Kategorien: {string.Join(", ", drivess.Categories)} | Preis: {drivess.Price}€");
                            Console.WriteLine();
                            i++;
                        }   
                    }

                    else
                    {
                        numberplacesSATA = 10;
                        Console.WriteLine("Sie haben noch kein Motherboard ausgewählt, deswegen wird ihre Auswahl auf 10 begrenz");
                    }

                    do
                    {
                        char numberdriveyesno = 'n';

                        for (int h = 1; h <= numberplacesSATA; h++)
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
                                    
                                    if (h == numberplacesSATA)
                                    {
                                        SATAnummax = true;
                                        Console.WriteLine("Die maximale Anzahl an SATA-Festplatten wurde erreicht.");
                                        break;
                                    }
                                                                      
                                    
                                    int actualpick = pick - 1;
                                    var selecteddrive = drives[actualpick];
                                    mypc.DriveSATA.Add(selecteddrive);
                                    Console.WriteLine($"{selecteddrive.Name} wurde als SATA gewählt.");
                                    
                                }

                            } while (success == false);

                            bool newSATA = false;                            

                            while (!newSATA || numberplacesSATA == 0)
                            {

                                Console.WriteLine("Soll eine weitere Festplatte hinzugefügt werden?\n   Ja(y) oder Nein(n)?");
                                char.TryParse(Console.ReadLine(), out numberdriveyesno);

                                if (numberdriveyesno == 'y')
                                {
                                    numberplacesSATA = numberplacesSATA - 1;
                                    Console.WriteLine($"Sie können noch {numberplacesSATA} SATA-Festplatten auswählen.");
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
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("Ungültige Auswahl. Bitte erneut auswählen.");
                                    Console.ResetColor();
                                }
                            }

                            if (numberdriveyesno == 'n' || numberplacesSATA == 0)
                            {
                                break;
                            }
                        }

                        if (numberplacesSATA == 0 || numberdriveyesno == 'n')
                        {
                            Console.WriteLine("Es werden/können keine weiteren Festplatten mehr ausgewählt werden.");
                            break;
                        }

                    } while (!moredrivesyesno);

                    SATAyn = true;
                }

                else if (jumpSATA == 'n')
                {
                    Console.WriteLine("Es wird keine SATA-Festplatte hinzugefügt.");
                    SATAyn = true;
                }

                else
                {
                    Console.WriteLine("Ungültige Eingabe. Bitte nochmals wählen.");
                }

            } while (!SATAyn);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Drücken sie eine Taste, um zum nächsten Punkt zu springen.");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\x1b[3J");
        }
    } 
}
