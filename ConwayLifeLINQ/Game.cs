using System;
using System.Collections.Generic;
using System.Linq;

namespace ConwayLifeLINQ
{
    public class Game
    {
        
        private HashSet<Tuple<int, int>> field;
        public Game()
        {
            field=new HashSet<Tuple<int, int>>();
        }
        
        public bool GetCell(int x, int y)
        {
            return field.Any(tuple => tuple.Item1 == x && tuple.Item2 == y);
        }

        public void SetCell(int x, int y)
        {
            field.Add(new Tuple<int, int>(x, y));
        }
        
        public void ShowFieldLINQ()
        {
            Console.Clear();
            field.Select(cell =>
            {
                Console.SetCursorPosition(cell.Item1, cell.Item2);
                Console.Write('*');
                return true;
            }).ToArray();
        }

        public void DoIteration()
        {
            field=new HashSet<Tuple<int, int>>(field.SelectMany(cell=>GetCellNeighb(cell.Item1,cell.Item2)).Where(cell=>CountAliveNeighb(cell.Item1,cell.Item2)==3 || (CountAliveNeighb(cell.Item1,cell.Item2)==2 && field.Contains(cell))));
        }

        public List<Tuple<int, int>> GetCellNeighb(int x,int y)
        {
            return Enumerable.Range(x - 1, 3)
                .SelectMany
                (nx => Enumerable
                    .Range(y - 1, 3)
                    .Select(ny => new Tuple<int, int>(nx, ny)))
            .Where(tuple => !CellsEquals(new Tuple<int, int>(x, y), tuple)).ToList();
        }

        public int CountAliveNeighb(int x, int y)
        {
            return field.Count(tuple => Math.Abs(tuple.Item1 - x) <= 1 && Math.Abs(tuple.Item2 - y) <= 1 && !CellsEquals(new Tuple<int, int>(x,y), tuple));
        }

        public static bool CellsEquals(Tuple<int, int> cell1, Tuple<int, int> cell2)
        {
            return (cell1.Item1 == cell2.Item1 && cell1.Item2 == cell2.Item2);
        }
    }
}