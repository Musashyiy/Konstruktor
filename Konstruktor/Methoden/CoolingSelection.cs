using Components;
using Konstruktor.Methoden;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konstruktor.Methoden
{
    public class CoolingBlueprint : IComponent                                        ///Die Blaupause für die verscheidenen Kühlungen
    {
        public string Name { get; set; }
        public string Form { get; set; }                    //AiO, Aircolling....
        public float Price { get; set; }
        public List<string> Sockets { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public float Lenght { get; set; }
        public List<string> Categories { get; set; }
        public void Select(MyPc mypc)
        {
            Console.WriteLine("Wollen sie eine Luftkühlung(1) oder eine Wasserkühlung(2)?");
            int aioair;
            bool aioorair = false;

            do
            {
                int.TryParse(Console.ReadLine(), out aioair);

                if (aioair == 1)
                {
                    AirCooling.AirCoolingsSelection(mypc);
                    aioorair = true;
                }

                else if (aioair == 2)
                {
                    AioCooling.AioCoolingsSelection(mypc);
                    aioorair = true;
                }

                else
                {
                    Console.WriteLine("Ungültige Eingabe. Bitte erneut auswählen.");
                }

            } while (!aioorair);
            Console.Clear();
            Console.WriteLine("\x1b[3J");
        }
    }          
}
