using System;
using ConwayLifeLINQ;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConwayLifeLINQTests
{
    [TestClass]
    public class GameLogicTests
    {
        [TestMethod]
        public void FieldGetSetTest()
        {
            var game = new Game();
            game.SetCell(4,5);
            var cell = game.GetCell(4, 5);
            Assert.AreEqual(true,cell);
        }
        [TestMethod]
        public void FieldGetUnsetCellTest()
        {
            var game = new Game();
            game.SetCell(4, 5);
            var cell = game.GetCell(4, 6);
            Assert.AreEqual(false, cell);
        }

        [TestMethod]
        public void CountAliveNeighbWith1NeigbTest()
        {
            var game = new Game();
            game.SetCell(3,3);
            game.SetCell(3,4);
            game.SetCell(3,5);
            var count1 = game.CountAliveNeighb(3,3);
            Assert.AreEqual(1,count1);
        }
        [TestMethod]
        public void CountAliveNeighbWith2NeigbTest()
        {
            var game = new Game();
            game.SetCell(3, 3);
            game.SetCell(3, 4);
            game.SetCell(3, 5);
            var count1 = game.CountAliveNeighb(3, 4);
            Assert.AreEqual(2, count1);
        }
        [TestMethod]
        public void CellsEqualsTest()
        {
            var game = new Game();
            var cellsEquals=Game.CellsEquals(new Tuple<int, int>(3, 2), new Tuple<int, int>(3, 2));
            Assert.IsTrue(cellsEquals);
        }
        [TestMethod]
        public void CellsNotEqualsTest()
        {
            var game = new Game();
            var cellsEquals = Game.CellsEquals(new Tuple<int, int>(3, 4), new Tuple<int, int>(3, 2));
            Assert.IsFalse(cellsEquals);
        }

        [TestMethod]
        public void GetCellNeighbTest()
        {
            var game = new Game();
            var cellNeighb = game.GetCellNeighb(3, 3);
            Assert.IsFalse(cellNeighb.Contains(new Tuple<int, int>(3, 3)));
            Assert.IsTrue(cellNeighb.Contains(new Tuple<int, int>(2, 2)));
            Assert.IsTrue(cellNeighb.Contains(new Tuple<int, int>(4, 4)));
        }
        [TestMethod]
        public void BlinkTest()
        {
            var game = new Game();
            game.SetCell(3, 3);
            game.SetCell(3, 4);
            game.SetCell(3, 5);
            game.DoIteration();
            //var count1 = game.CountAliveNeighb(3, 4);
            Assert.AreEqual(false, game.GetCell(3,3));
            Assert.AreEqual(true, game.GetCell(3,4));
            Assert.AreEqual(false, game.GetCell(3,5));
            Assert.AreEqual(true, game.GetCell(4, 4));
            Assert.AreEqual(true, game.GetCell(2, 4));
            Assert.AreEqual(false, game.GetCell(4, 3));
            Assert.AreEqual(false, game.GetCell(2, 5));
        }
        [TestMethod]
        public void SquareTest()
        {
            var game = new Game();
            game.SetCell(3, 3);
            game.SetCell(3, 4);
            game.SetCell(4, 3);
            game.SetCell(4, 4);
            game.DoIteration();
            //var count1 = game.CountAliveNeighb(3, 4);
            Assert.AreEqual(true, game.GetCell(3, 3));
            Assert.AreEqual(true, game.GetCell(3, 4));
            Assert.AreEqual(true, game.GetCell(4, 4));
            Assert.AreEqual(true, game.GetCell(4, 3));
        }
    }
}
