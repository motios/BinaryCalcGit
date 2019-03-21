using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryCalculator.Entities
{
    public class Soldier
    {
        public int Position{get; set;}
        public Soldier NextSoldier { get; set; } = null;

        public bool IsPositionChanged { get; set; } = false;

        public Soldier() { }
    }
}
