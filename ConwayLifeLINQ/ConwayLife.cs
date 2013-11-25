using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwayLifeLINQ
{
    static class ConwayLife
    {
        static void Main(string[] args)
        {
            GameLogic.RunGame(new HashSet<Tuple<int, int>>()
            {
                new Tuple<int, int>(3,3),
                new Tuple<int, int>(3,4),
                new Tuple<int, int>(3,5),
                new Tuple<int, int>(6,6),
                new Tuple<int, int>(6,7),
                new Tuple<int, int>(7,6),
                new Tuple<int, int>(7,7),
            });
            
        }

    }
}
