using System;
using System.Collections.Generic;
using System.Linq;
using ConwayLifeLINQ;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConwayLifeLINQTests
{
    
    [TestClass]
    public class GameLogicTests
    {
        [TestMethod]
        public void CountAliveNeighbWith1NeigbTest()
        {
            var count1 = GameLogic.CountAliveNeighb(new HashSet<Tuple<int, int>>()
            {
                new Tuple<int, int>(3,3),
                new Tuple<int, int>(3,4),
                new Tuple<int, int>(3,5),
            }, 3,3);
            Assert.AreEqual(1,count1);
        }
        
        [TestMethod]
        public void CountAliveNeighbWith2NeigbTest()
        {
            var count1 = GameLogic.CountAliveNeighb(new HashSet<Tuple<int, int>>()
            {
                new Tuple<int, int>(3,3),
                new Tuple<int, int>(3,4),
                new Tuple<int, int>(3,5),
            }, 3, 4);
            Assert.AreEqual(2, count1);
        }
        [TestMethod]
        public void CellsEqualsTest()
        {
            //var game = new GameLogic();
            var cellsEquals=GameLogic.CellsEquals(new Tuple<int, int>(3, 2), new Tuple<int, int>(3, 2));
            Assert.IsTrue(cellsEquals);
        }
        [TestMethod]
        public void CellsNotEqualsTest()
        {
            //var game = new GameLogic();
            var cellsEquals = GameLogic.CellsEquals(new Tuple<int, int>(3, 4), new Tuple<int, int>(3, 2));
            Assert.IsFalse(cellsEquals);
        }

        [TestMethod]
        public void GetCellNeighbTest()
        {
            //var game = new GameLogic();
            var cellNeighb = GameLogic.GetCellNeighb(3, 3);
            Assert.IsFalse(cellNeighb.Contains(new Tuple<int, int>(3, 3)));
            Assert.IsTrue(cellNeighb.Contains(new Tuple<int, int>(2, 2)));
            Assert.IsTrue(cellNeighb.Contains(new Tuple<int, int>(4, 4)));
        }
        [TestMethod]
        public void BlinkTest()
        {

            var field = GameLogic.DoIteration(new HashSet<Tuple<int, int>>()
            {
                new Tuple<int, int>(3,3),
                new Tuple<int, int>(3,4),
                new Tuple<int, int>(3,5),
            });
            //var count1 = game.CountAliveNeighb(3, 4);
            Assert.AreEqual(false, field.Contains(new Tuple<int, int>(3, 3)));
            Assert.AreEqual(true, field.Contains(new Tuple<int, int>(3, 4)));
            Assert.AreEqual(false, field.Contains(new Tuple<int, int>(3, 5)));
            Assert.AreEqual(true, field.Contains(new Tuple<int, int>(4, 4)));
            Assert.AreEqual(true, field.Contains(new Tuple<int, int>(2, 4)));
            Assert.AreEqual(false, field.Contains(new Tuple<int, int>(4, 3)));
            Assert.AreEqual(false, field.Contains(new Tuple<int, int>(2, 5)));
        }
        [TestMethod]
        public void SquareTest()
        {
            var field = GameLogic.DoIteration(new HashSet<Tuple<int, int>>()
            {
                new Tuple<int, int>(3,3),
                new Tuple<int, int>(3,4),
                new Tuple<int, int>(4,3),
                new Tuple<int, int>(4,4),
            });
            //var count1 = game.CountAliveNeighb(3, 4);
            Assert.AreEqual(true, field.Contains(new Tuple<int, int>(3, 3)));
            Assert.AreEqual(true, field.Contains(new Tuple<int, int>(3, 4)));
            Assert.AreEqual(true, field.Contains(new Tuple<int, int>(4, 3)));
            Assert.AreEqual(true, field.Contains(new Tuple<int, int>(4, 4)));
        }
        
    }
     
}
