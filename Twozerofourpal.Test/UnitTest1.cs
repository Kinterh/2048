using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Twozerofourpal.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestBoardMoveLeft()
        {
            Board board = new Board(new int[,] {
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 4, 0, 2 },
                { 0, 8, 0, 0 }}
            );

            board.Move(Way.left);

            var result = new int[,] {
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 4, 2, 0, 0 },
                { 8, 0, 0, 0 }};

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(board.Numbers[i, j], result[i, j]);
                }
            }
        }

        [TestMethod]
        public void TestBoardMoveRight()
        {
            Board board = new Board(new int[,] {
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 4, 0, 2 },
                { 0, 8, 0, 0 }});

            board.Move(Way.right);

            var result = new int[,] {
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 4, 2 },
                { 0, 0, 0, 8 }};

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(board.Numbers[i, j], result[i, j]);
                }
            }
        }

        [TestMethod]
        public void TestBoardMoveUp()
        {
            Board board = new Board(new int[,] {
                { 0, 0, 0, 0 },
                { 2, 2, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 }});

            board.Move(Way.up);

            var result = new int[,] {
                { 2, 2, 0, 0 },
                { 0, 0, 0, 0 },
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

        [TestMethod]
        public void TestBoardMoveDown()
        {
            Board board = new Board(new int[,] {
                { 0, 4, 0, 0 },
                { 0, 8, 0, 0 },
                { 0, 0, 0, 2 },
                { 0, 0, 0, 0 }});

            board.Move(Way.down);

            var result = new int[,] {
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 4, 0, 0 },
                { 0, 8, 0, 2 }};

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(board.Numbers[i, j], result[i, j]);
                }
            }
        }

        [TestMethod]
        public void TestBoardCombine()
        {
            Board board = new Board(new int[,]
            {
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 2, 0, 0 },
                { 0, 2, 0, 0 }
            });
            board.Move(Way.left);
            board.Move(Way.up);
            var result = new int[,] {
                { 4, 0, 0, 0 },
                { 0, 0, 0, 0 },
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

        [TestMethod]
        public void TestBoardCanMove()
        {
            Board board = new Board(new int[,] {
                { 4, 2, 4, 2 },
                { 2, 4, 2, 4 },
                { 4, 2, 4, 2 },
                { 2, 4, 2, 4 }});
            bool result = false;
            Assert.AreEqual(board.Move(Way.check), result);
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

        [TestMethod]
        public void TestRotateRight()
        {
            Board board = new Board(new int[,] {
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 2, 0, 0 },
                { 0, 2, 0, 0 }});

            board.RotateRight();

            var result = new int[,] {
                { 0, 0, 0, 0 },
                { 2, 2, 0, 0 },
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
