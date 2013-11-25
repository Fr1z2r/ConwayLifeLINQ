using System;
using System.Collections.Generic;
using System.Linq;

namespace ConwayLifeLINQ
{
    public static class GameLogic
    {
        public static void RunGame(HashSet<Tuple<int, int>> field)
        {
                ShowFieldLINQ(field);
                RunGame( DoIteration(field));
        }

        private static void ShowFieldLINQ(IEnumerable<Tuple<int, int>> field)
        {
            Console.Clear();
            field.Select(cell =>
            {
                Console.SetCursorPosition(cell.Item1, cell.Item2);
                Console.Write('*');
                return true;
            }).ToArray();
            Console.ReadKey();
        }

        public static HashSet<Tuple<int, int>> DoIteration(HashSet<Tuple<int, int>> field)
        {
            return new HashSet<Tuple<int, int>>(field.SelectMany(cell => GetCellNeighb(cell.Item1, cell.Item2)).Where(cell => CountAliveNeighb(field, cell.Item1, cell.Item2) == 3 || (CountAliveNeighb(field,cell.Item1, cell.Item2) == 2 && field.Contains(cell))));
        }

        public static IEnumerable<Tuple<int, int>> GetCellNeighb(int x,int y)
        {
            return Enumerable.Range(x - 1, 3)
                .SelectMany
                (nx => Enumerable
                    .Range(y - 1, 3)
                    .Select(ny => new Tuple<int, int>(nx, ny)))
            .Where(tuple => !CellsEquals(new Tuple<int, int>(x, y), tuple)).ToList();
        }

        public static int CountAliveNeighb(IEnumerable<Tuple<int, int>> field,int x, int y)
        {
            return field.Count(tuple => Math.Abs(tuple.Item1 - x) <= 1 && Math.Abs(tuple.Item2 - y) <= 1 && !CellsEquals(new Tuple<int, int>(x,y), tuple));
        }

        public static bool CellsEquals(Tuple<int, int> cell1, Tuple<int, int> cell2)
        {
            return (cell1.Item1 == cell2.Item1 && cell1.Item2 == cell2.Item2);
        }
    }
}