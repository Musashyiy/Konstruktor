using Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konstruktor.Methoden
{    
    public interface IComponent
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public void Select(MyPc mypc);
    }    
}

