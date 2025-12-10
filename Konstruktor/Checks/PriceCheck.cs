using Components;
using Konstruktor.Methoden;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konstruktor.Checks
{
    public class PriceCheck
    {
        public static void Pricecheck(MyPc mypc)
        {
            float sumNVMe = mypc.DriveNVMe.Sum(d => d.Price);
            float sumSATA = mypc.DriveSATA.Sum(e => e.Price);
            float sumExtra = mypc.Extras.Sum(f => f.Price);
            float sumFans = mypc.Fans.Sum(b => b.Price);

            float pricesum =
                mypc.Case.Price +
                mypc.Coolings.Price +
                mypc.Cpu.Price +
                sumExtra +
                sumFans +
                mypc.Gpu.Price +
                mypc.Motherboard.Price +
                sumNVMe +
                sumSATA +
                mypc.Psu.Price +
                mypc.Ram.Price;

                mypc.Price = pricesum ;            
        }
    }
}
