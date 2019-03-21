using BinaryCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int lengthOfWay = 50;
            int soldiersCount = 10;
            var controller = new Controller(lengthOfWay, soldiersCount );
            controller.CalculateVariants();

        }
    }
}
