using Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konstruktor.Methoden
{    
    interface Component
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public void Select(MyPc mypc);
    }

    public class Case: Component                                         ///Die Blaupause für die verscheidenen Cases
    {
        public string Name { get; set; }
        public float Lenght { get; set; }               //in cm
        public float Width { get; set; }                //in cm
        public float Depth { get; set; }                //in cm
        public int NumberCaseFans { get; set; }         //Custom Größen
        public int NumberSATASlots25 { get; set; }
        public int NumberSATASlots35 { get; set; }
        public float MaxGPULength { get; set; }
        public string Fit { get; set; }                 //ob ATX, mini-STX etc...
        public float Price { get; set; }
        public float MaxCoolerHeight { get; set; }
        public string[] Categories { get; set; }
        public void Select(MyPc mypc)
        {
            Cases.CaseSelection(mypc);
            Console.Clear();
            Console.WriteLine("\x1b[3J");
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
        public void Select(MyPc mypc)
        {
            Cases.CaseSelection(mypc);
            Console.Clear();
            Console.WriteLine("\x1b[3J");
        }
    }
}
