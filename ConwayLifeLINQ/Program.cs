using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwayLifeLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.SetCell(3,3);
            game.SetCell(3,4);
            game.SetCell(3,5);
            game.SetCell(6,6);
            game.SetCell(6,7);
            game.SetCell(7,6);
            game.SetCell(7,7);

            Enumerable.Range(1, Int32.MaxValue).Aggregate((i, i1) =>
            {
                game.ShowFieldLINQ();
                game.DoIteration();
                Console.ReadKey();
                return 0;
            });
            
        }

    }
}
