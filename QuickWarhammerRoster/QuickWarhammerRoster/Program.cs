using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickWarhammerRoster
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Warhammer 40k Quick Roster Maker, press any key to continue");
            Console.ReadLine();
            ForceOrg.requirementSetter();//triggers the whole shebang                 
            Console.ReadLine();            

        }
    }
}
