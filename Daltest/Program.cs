using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testdal;
using ProjectDatabaseLib;

namespace Daltest
{
    class Program
    {
        static void Main(string[] args)
        {
            DalInter c = new DalImp();
            Location s = c.GetCoordinates("gg");
            Console.WriteLine(s.Latitude);
        }
    }
}
