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
<<<<<<<< HEAD:Konstruktor/Auswahlmethoden/Coolingaio.cs
    public class AiOCooling
    {
        public static void AioCoolingsSelection(MyPc mypc)
        {
            string jsonTextCoolingaio = File.ReadAllText("json/coolingsaio.json");
            JsonArray coolingsaioarray = JsonNode.Parse(jsonTextCoolingaio).AsArray();
            int anzahlcoolingaio = coolingsaioarray.Count;
            List<CoolingBlueprint>? coolingsaio = JsonSerializer.Deserialize<List<CoolingBlueprint>>(jsonTextCoolingaio);

            int i = 1;
         
            Console.WriteLine("Wasser-Kühlung");
            Console.WriteLine();

            foreach (var coolingss in coolingsaio)
            {
                Console.WriteLine($"({i}) {coolingss.Name} | Form: {coolingss.Form} | Sockelkompartibilität: {string.Join(", ", coolingss.Sockets)} | Maße: Höhe {coolingss.Height}cm x Breite {coolingss.Width}cm x Länge {coolingss.Lenght}cm | Preis: {coolingss.Price}€");
========
    public class Coolings
    {
        public static string CoolingsSelection(MyPc mypc)
        {
            string jsonTextCooling = File.ReadAllText("json/coolings.json");
            JsonArray coolingsarray = JsonNode.Parse(jsonTextCooling).AsArray();
            int anzahlcooling = coolingsarray.Count;
            List<Cooling>? coolings = JsonSerializer.Deserialize<List<Cooling>>(jsonTextCooling);
            int i = 1;


            Console.WriteLine("Coolings");
            Console.WriteLine();
            foreach (var coolingss in coolings)
            {
                Console.WriteLine($"({i}) {coolingss.Name} | Form: {coolingss.Form} | Sockelkompartibilität: {string.Join(", ", coolingss.Sockets)} | Preis: {coolingss.Price}€");
>>>>>>>> 8a36a486597839ee8a94795cc5827d9861c0e147:Konstruktor/Auswahlmethoden/Cooling.cs
                Console.WriteLine();
                i++;
            }

            int pick = 0;
<<<<<<<< HEAD:Konstruktor/Auswahlmethoden/Coolingaio.cs
            bool success = false;            
========
            bool success = false;
>>>>>>>> 8a36a486597839ee8a94795cc5827d9861c0e147:Konstruktor/Auswahlmethoden/Cooling.cs

            do
            {
                if (success == false)
                {
                    Console.WriteLine("Auswahl Kühlung: ");
                    int.TryParse(Console.ReadLine(), out pick);

                    if (pick == 0)
                    {
                        Console.WriteLine("ungültige Zahl. Nochmal auswählen.");
                    }

<<<<<<<< HEAD:Konstruktor/Auswahlmethoden/Coolingaio.cs
                    else if (pick <= anzahlcoolingaio)
========
                    else if (pick <= anzahlcooling)
>>>>>>>> 8a36a486597839ee8a94795cc5827d9861c0e147:Konstruktor/Auswahlmethoden/Cooling.cs
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
<<<<<<<< HEAD:Konstruktor/Auswahlmethoden/Coolingaio.cs
            mypc.Coolings = coolingsaio[actualpick];
            Console.WriteLine($"{coolingsaio[actualpick].Name} wurde als Kühlung ausgewählt.");

            Console.WriteLine("Drücken sie eine Taste, um zum nächsten Punkt zu springen.");
            Console.ReadKey();                                  
        }
        
    }

    public class CoolingBlueprint                                        ///Die Blaupause für die verscheidenen Kühlungen
    {
        public string Name { get; set; }
        public string Form { get; set; }                    //AiO, Aircolling....
        public float Price { get; set; }
        public List<string> Sockets { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public float Lenght { get; set; }
        public List<string> Categories { get; set; }
    }

}

========
            mypc.Cooling = coolings[actualpick];
            Console.WriteLine($"{coolings[actualpick].Name} wurde als Kühlung ausgewählt.");

            Console.WriteLine("Drücken sie eine Taste, um zum nächsten Punkt zu springen.");
            Console.ReadKey();

            return mypc.Cooling.Name;
        }
    }
    public class Cooling                                        ///Die Blaupause für die verscheidenen Kühlungen
    {
        public string Name { get; set; }
        public string Form { get; set; }                //AiO, Aircolling....
        public float Price { get; set; }
        public List<string> Sockets { get; set; }
        public List<string> Categories { get; set; }
    }
}
>>>>>>>> 8a36a486597839ee8a94795cc5827d9861c0e147:Konstruktor/Auswahlmethoden/Cooling.cs
