using _1024Core.Service;
using _1024Core.Entity;
using _1024Core.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _1024Test
{
    [TestClass]
    public class CoreServiceTest
    {
        [TestMethod]
        public void ColumnTest()
        {
            Field field = Field3(tile1());

            Assert.AreEqual(4, field.ColumnCount);              
        }


        [TestMethod]
        public void RowTest()
        {
            Field field = Field3(tile1());

            Assert.AreEqual(4, field.RowCount);
        }


        [TestMethod]
        public void GetTileTest()
        {
            Tile[,] tiles = tile1();
            Field field = Field3(tiles);           
            
            field[0, 0] = tile2(2);
            
            Assert.AreEqual(2, field.GetTile(0, 0).Value);
        }


        [TestMethod]
        public void RestartTest()
        {
            Tile[,] tiles = tile1();
            Field field = Field3(tiles);            
            field[0, 2] = tile2(8);
            field[3, 2] = tile2(8);
            field[1, 1] = tile2(8);

            field.Restart();

            int check = 0;
            for (int row = 0; row < field.RowCount; row++)
            {
                for (int column = 0; column < field.ColumnCount; column++)
                {
                    if (field[row, column] != null && field[row, column].Value > 0)
                        check++;
                }
            }

            Assert.AreEqual(0, field.score.ScoreReal);
            Assert.AreEqual(2, check);
        }


        [TestMethod]
        public void MoveTest()
        {
            Tile[,] tiles = tile1();
            Field field = Field3(tiles);

            for (int row = 0; row < field.RowCount; row++)
            {
                for (int column = 0; column < field.ColumnCount; column++)
                {
                    if (field[row, column] != null)
                        field[row, column] = null;
                }
            }

            field[0, 2] = tile2(8);
            field[3, 2] = tile2(8);
            field[1, 1] = tile2(8);

            field.Move(Direction.Left);
            

            Assert.AreEqual(null, field[0, 2]);
            Assert.AreEqual(null, field[3, 2]);
            Assert.AreEqual(null, field[1, 1]);

            Assert.AreEqual(8, field.GetTile(0, 0).Value);
            Assert.AreEqual(8, field.GetTile(0, 0).Value);
            Assert.AreEqual(8, field.GetTile(0, 0).Value);
        }


        [TestMethod]
        public void SumTest()
        {
            Tile[,] tiles = tile1();
            Field field = Field3(tiles);
            field[0, 2] = tile2(8);
            field[1, 2] = tile2(8);

            field.Sum(1, 2, Direction.Up);

            Assert.AreEqual(null, field[1, 2]);           

            Assert.AreEqual(16, field.GetTile(0, 2).Value);
            Assert.AreEqual(16, field.score.ScoreReal);
        }



        [TestMethod]
        public void IsFreeTileTest()
        {
            Tile[,] tiles = tile1();
            Field field = Field3(tiles);

            for (int row = 0; row < field.RowCount; row++)
            {
                for (int column = 0; column < field.ColumnCount; column++)
                {
                    if (field[row, column] != null && field[row, column].Value > 0)
                        field[row, column] = null;
                }
            }

            field[0, 0] = tile2(1);
            field[0, 1] = tile2(1);
            field[0, 2] = tile2(1);
            field[0, 3] = tile2(1);
            field[1, 0] = tile2(1);
            field[1, 1] = tile2(1);
            field[1, 2] = tile2(1);
            field[1, 3] = tile2(1);
            field[2, 0] = tile2(1);
            field[2, 1] = tile2(1);
            field[2, 2] = tile2(1);
            field[2, 3] = tile2(1);
            field[3, 0] = tile2(1);
            field[3, 1] = tile2(1);
            field[3, 2] = tile2(1);
            field[3, 3] = tile2(1);            

            Assert.AreEqual(false, field.IsFreeTile());            
        }



        [TestMethod]
        public void CheckMoveTest()
        {
            Tile[,] tiles = tile1();
            Field field = Field3(tiles);

            for (int row = 0; row < field.RowCount; row++)
            {
                for (int column = 0; column < field.ColumnCount; column++)
                {
                    if (field[row, column] != null && field[row, column].Value > 0)
                        field[row, column] = null;
                }
            }

            field[0, 0] = tile2(1);
            field[0, 1] = tile2(1);
            field[0, 2] = tile2(2);
            field[0, 3] = tile2(4);
            field[1, 0] = tile2(2);
            field[1, 1] = tile2(4);
            field[1, 2] = tile2(8);
            field[1, 3] = tile2(16);
            field[2, 0] = tile2(4);
            field[2, 1] = tile2(8);
            field[2, 2] = tile2(16);
            field[2, 3] = tile2(32);
            field[3, 0] = tile2(8);
            field[3, 1] = tile2(16);
            field[3, 2] = tile2(32);
            field[3, 3] = tile2(64);

            Assert.AreEqual(true, field.CheckMove());
        }



        [TestMethod]
        public void RandomTest()
        {
            Tile[,] tiles = tile1();
            Field field = Field3(tiles);

            field.Restart();
            field.RandomTile();

            int check = 0;
            for (int row = 0; row < field.RowCount; row++)
            {
                for (int column = 0; column < field.ColumnCount; column++)
                {
                    if (field[row, column] != null && field[row, column].Value > 0)
                        check++;
                }
            }

            Assert.AreEqual(3, check);
        }


        private Tile[,] tile1()
        {
            return new Tile[4, 4];
        }

        private Tile tile2(int value)
        {
            return new Tile(value);
        }

        private Field Field3(Tile[,] tiles)
        {                        
            return new Field(4, 4);
        }
    }
}