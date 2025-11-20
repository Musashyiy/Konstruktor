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
    internal class GPUs
    {
        public static string GPUSelection(MyPc mypc)
        {
            string jsonTextGPU = File.ReadAllText("gpus.json");
            JsonArray gpusarray = JsonNode.Parse(jsonTextGPU).AsArray();
            int anzahlgpu = gpusarray.Count;
            List<GPU>? gpus = JsonSerializer.Deserialize<List<GPU>>(jsonTextGPU);
            int i = 1;


            Console.WriteLine("GPUs");
            Console.WriteLine();
            foreach (var gpuss in gpus)
            {
                Console.WriteLine($"({i}) {gpuss.Name} | Watt-Input: {gpuss.WattInput}Watt | VRAM-Kapatizität: {gpuss.VRAMcapacity} | VDDR-Typ: {gpuss.VRAMtype} \n    Preis: {gpuss.Price} Euro");
                Console.WriteLine();
                i++;
            }

            int pick = 0;
            bool success = false;

            do
            {
                if (success == false)
                {
                    Console.WriteLine("Auswahl GPUs: ");
                    int.TryParse((Console.ReadLine()), out pick);

                    if (pick == 0)
                    {
                        Console.WriteLine("ungültige Zahl. Nochmal auswählen.");
                    }

                    else if (pick <= anzahlgpu)
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
            mypc.Gpu = gpus[actualpick];
            Console.WriteLine($"{gpus[actualpick].Name} wurde als GPU gewählt.");

            Console.WriteLine("Drücken sie eine Taste, um zum nächsten Punkt zu springen.");
            Console.ReadKey();

            return mypc.Gpu.Name;
        }
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
}
