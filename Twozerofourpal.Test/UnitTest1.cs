using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Twozerofourpal.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestBoardMove()
        {
            Board board = new Board(new int[,] {
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 2, 0, 0 },
                { 0, 2, 0, 0 }});

            board.Move(Way.down);

            Assert.AreEqual(board.Numbers, new int[,] {
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 4, 0, 0 }});
        }

        [TestMethod]
        public void TestBoardCanMove()
        {
            Board board = new Board(new int[,] {
                { 4, 2, 4, 2 },
                { 2, 4, 2, 4 },
                { 4, 2, 4, 2 },
                { 2, 4, 2, 4 }});
        }

        [TestMethod]
        public void TestFlip()
        {
            Board board = new Board(new int[,] {
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 2, 0, 0 },
                { 0, 2, 0, 0 }});

            board.Flip();

            var result = new int[,] {
                { 0, 2, 0, 0 },
                { 0, 2, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 }};

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(board.Numbers[i, j], result[i, j]);
                }
            }
        }
    }
}
