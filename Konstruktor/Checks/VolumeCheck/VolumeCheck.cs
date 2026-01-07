using Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konstruktor.Checks.VolumeCheck
{
    public class VolumeCheck
    {
        public static void MeasurmentCheck(MyPc mypc)
        {
            Konstruktor.Checks.VolumeCheck.CaseandCoolingVolCheck.CaseandCoolingVolume(mypc);
            Konstruktor.Checks.VolumeCheck.CaseandGPUVolCheck.CaseandGPUVolume(mypc);

        }
    }
}
