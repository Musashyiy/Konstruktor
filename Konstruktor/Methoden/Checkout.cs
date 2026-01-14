using Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konstruktor.Methoden
{
    public class Checkout
    {
        
        public static void Checkoutgenerate(MyPc mypc)
        {
            // Die Methode braucht noch zur Anpassung die Option, dass mehrere Komponenten hintereinander ausgetauscht werden können
            //  
            // und die CheckoutListe nochmals neu ausgegeben wird, sobald alle Komponenten ausgetauscht worden sind.


            bool checkoutswapgo = false;
            bool swapyn = false;
            char compswap;

            while (!checkoutswapgo)
            {
                Console.WriteLine("Ihr System:");
                Console.WriteLine("(1) Gehäuse: " + mypc.Case.Name + " | " + mypc.Case.Price + "€");
                Console.WriteLine("(2) Netzteil: " + mypc.Psu.Name + " | " + mypc.Psu.Price + "€");
                Console.WriteLine("(3) Motherboard: " + mypc.Motherboard.Name + " | " + mypc.Motherboard.Price + "€");
                Console.WriteLine("(4) CPU: " + mypc.Cpu.Name + " | " + mypc.Cpu.Price + "€");
                Console.WriteLine("(5) Grafikkarte: " + mypc.Gpu.Name + " | " + mypc.Gpu.Price + "€");
                Console.WriteLine("(6) RAM: " + mypc.Ram.Name + " | " + mypc.Ram.Price + "€");
                Console.WriteLine("(7) Kühlung: " + mypc.Coolings.Name + " | " + mypc.Coolings.Price + "€");

                var SATAText = string.Join(", ",
                    mypc.DriveSATA
                        .GroupBy(h => h.Name)
                        .Select(k =>
                        {
                            int count = k.Count();
                            float unitprice = k.First().Price;
                            float totalPrice = count * unitprice;
                            return $"{count}x {k.Key} ({totalPrice}€)";
                        })
                );
                Console.WriteLine($"(8) SATA-Laufwerke: {SATAText}");

                var NVMeText = string.Join(", ",
                    mypc.DriveNVMe
                        .GroupBy(a => a.Name)
                        .Select(a =>
                        {
                            int count = a.Count();
                            float unitprice = a.First().Price;
                            float totalPrice = count * unitprice;
                            return $"{count}x {a.Key} ({totalPrice}€)";
                        })
                );
                Console.WriteLine($"(9) NVMe-Laufwerke: {NVMeText}");

                var fanText = string.Join(", ",
                    mypc.Fans
                        .GroupBy(m => m.Name)
                        .Select(l =>
                        {
                            int count = l.Count();
                            float unitPrice = l.First().Price;
                            float totalPrice = count * unitPrice;
                            return $"{count}x {l.Key} ({totalPrice}€)";
                        })
                );
                Console.WriteLine("(10) Lüfter: " + fanText);

                var extrasText = string.Join(", ",
                    mypc.Extras
                        .GroupBy(e => e.Name)
                        .Select(n =>
                        {
                            int count = n.Count();
                            float unitPrice = n.First().Price;
                            float totalPrice = count * unitPrice;
                            return $"{count}x {n.Key} ({totalPrice}€)";
                        })
                );
                Console.WriteLine("(11) Extras: " + extrasText);

                while (!swapyn)
                {
                    Console.WriteLine("Wollen sie Komponenten austauschen?\n  Ja(y) oder Nein(n)?");
                    char.TryParse(Console.ReadLine(), out compswap);

                    if (compswap == 'y')
                    {
                        Console.WriteLine("Welche Komponente soll ausgetauscht werden?");
                        int swapselect;
                        int.TryParse(Console.ReadLine(), out swapselect);

                        if (swapselect == 1) Konstruktor.Methoden.Cases.CaseSelection(mypc);
                        else if (swapselect == 2) PSUs.PSUSelection(mypc);
                        else if (swapselect == 3)
                        {
                            Mainboards.MainboardSelection(mypc);

                            mypc.DriveSATA.Clear();
                            mypc.DriveNVMe.Clear();
                            mypc.Fans.Clear();
                            mypc.Extras.Clear();

                            CPUs.CPUSelection(mypc);
                            RAMs.RAMSelection(mypc);
                            CoolingsSelection.CoolingSelection(mypc);
                            SATADrive.SATADrivesSelection(mypc);
                            NVMeDrive.NVMeDrivesSelection(mypc);
                            Fans.FansSelection(mypc);
                            Extra.ExtrasSelection(mypc);
                        }
                        else if (swapselect == 4) CPUs.CPUSelection(mypc);
                        else if (swapselect == 5) GPUs.GPUSelection(mypc);
                        else if (swapselect == 6) RAMs.RAMSelection(mypc);
                        else if (swapselect == 7) CoolingsSelection.CoolingSelection(mypc);
                        else if (swapselect == 8) SATADrive.SATADrivesSelection(mypc);
                        else if (swapselect == 9) NVMeDrive.NVMeDrivesSelection(mypc);
                        else if (swapselect == 10) Fans.FansSelection(mypc);
                        else if (swapselect == 11) Extra.ExtrasSelection(mypc);
                        else Console.WriteLine("Ungültige Auswahl. Bitte erneut auswählen.");

                        Console.WriteLine("Die gewünschten Komponenten wurden ausgetauscht.");
                        swapyn = true;
                        checkoutswapgo = true;
                    }
                    else if (compswap == 'n')
                    {
                        Console.WriteLine("Alle Komponenten werden beibehalten.");
                        swapyn = true;
                        checkoutswapgo = true;
                    }
                    else
                    {
                        Console.WriteLine("Ungültige Eingabe. Bitte wählen sie erneut.");
                    }
                }

                Console.WriteLine("--------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Gesamtpreis: " + mypc.Price + "€");
                Console.ResetColor();
            }
        }
    }
}
