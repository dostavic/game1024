using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1024Core.Core
{
    [Serializable]
    public class Field
    {
        private Tile[,] tiles;
        static readonly Random random = new();
        public Score score;
        private DateTime startTime;        

        private bool isMove;
        private bool isSum;

        public int RowCount { get; }

        public int ColumnCount { get; }

        public Field(int rowCount, int columnCount)
        {
            RowCount = rowCount;
            ColumnCount = columnCount;
            tiles = new Tile[rowCount, columnCount];            
            Initalize();
            startTime = DateTime.Now;
        }

        public Tile GetTile(int row, int column)
        {
            return tiles[row, column];
        }

        public Tile this[int row, int column]
        {
            set { tiles[row, column] = value; }
            get { return tiles[row, column]; }
        }

        private void Initalize()
        {
            for (int i = 0; i < 2; i++)
                RandomTile();
            //tiles[1, 0] = new(1);
            //tiles[2, 0] = new(4);
            //tiles[2, 1] = new(1);
            //tiles[3, 0] = new(1);
            //tiles[3, 1] = new(2);
            //tiles[3, 2] = new(4);
        }

        public void Restart()
        {
            tiles = new Tile[RowCount, ColumnCount];
            score.ScoreReal = 0;
            Initalize();
        }

        public void Move(Direction direction)
        {
            //Type moved = typeof(Class1.DirectionEnum);
            isMove = false;
            isSum = false;
            switch (direction)
            {
                case Direction.Left:
                    for(int colunm = 1; colunm < ColumnCount; ++colunm)
                    {
                        for(int row = 0; row < RowCount; ++row)
                        {                            
                            int check = colunm;
                            while(check > 0 && GetTile(row, check - 1) == null)
                            {
                                tiles[row, check - 1] = tiles[row, check];                                
                                tiles[row, check] = null;
                                check--;
                                if (GetTile(row, check) != null)
                                    isMove = true;                                
                            }                            
                            Sum(row, check, Direction.Left);
                        }                        
                    }                    
                    break;
                case Direction.Right:
                    for (int colunm = 2; colunm >= 0; --colunm)
                    {
                        for (int row = 0; row < RowCount; ++row)
                        {
                            int check = colunm;
                            while(check < ColumnCount - 1 && GetTile(row, check + 1) == null)
                            {
                                tiles[row, check + 1] = tiles[row, check];                                
                                tiles[row, check] = null;
                                check++;
                                if (GetTile(row, check) != null)
                                    isMove = true;
                            }                            
                            Sum(row, check, Direction.Right);
                        }
                    }
                    break;
                case Direction.Up:
                    for (int row = 1; row < RowCount; ++row)
                    {
                        for (int column = 0; column < ColumnCount; ++column)
                        {
                            int check = row;
                            while (check > 0 && GetTile(check - 1, column) == null)
                            {
                                tiles[check - 1, column] = tiles[check, column];                                
                                tiles[check, column] = null;
                                check--;
                                if (GetTile(check, column) != null)
                                    isMove = true;
                            }                            
                            Sum(check, column, Direction.Up);
                        }
                    }
                    break;
                case Direction.Down:
                    for (int row = 2; row >= 0; --row)
                    {
                        for (int column = 0; column < ColumnCount; ++column)
                        {
                            int check = row;
                            while (check < RowCount - 1 && GetTile(check + 1, column) == null)
                            {
                                tiles[check + 1, column] = tiles[check, column];
                                tiles[check, column] = null;
                                check++;
                                if(GetTile(check, column) != null)
                                    isMove = true;
                            }                            
                            Sum(check, column, Direction.Down);
                        }
                    }
                    break;
                default: return;                    
            }
            if(isMove || isSum)
                RandomTile();
            EmptyCalculate();
            //Console.WriteLine($"SCORE: {score.ScoreReal}");
            NewScore();        
            IsLost();
        }

        public void Sum(int row, int column, Direction direction)
        {
            if (GetTile(row, column) != null)
            {
                if ((direction == Direction.Left && column > 0 && column < ColumnCount
                    || (direction == Direction.Right && column >= 0 && column < ColumnCount - 1))
                    && GetTile(row, column + (int)direction).Value == GetTile(row, column).Value 
                    && !GetTile(row, column).IsCalculate && !GetTile(row, column + (int)direction).IsCalculate)
                {
                    tiles[row, column + (int)direction].Value *= 2;
                    tiles[row, column] = null;
                    isSum = true;
                    tiles[row, column + (int)direction].IsCalculate = true;
                    score.ScoreReal += tiles[row, column + (int)direction].Value;
                }
                else if ((direction == Direction.Up && row > 0 && row < RowCount
                  || (direction == Direction.Down && row >= 0 && row < RowCount - 1))
                  && GetTile(row + (int)direction / 2, column).Value == GetTile(row, column).Value 
                  && !GetTile(row, column).IsCalculate && !GetTile(row + (int)direction / 2, column).IsCalculate)
                {
                    tiles[row + (int)direction / 2, column].Value *= 2;
                    tiles[row, column] = null;
                    isSum = true;
                    tiles[row + (int)direction / 2, column].IsCalculate = true;
                    score.ScoreReal += tiles[row + (int)direction / 2, column].Value;
                }
                //else
                //    isSum = false;
            }
        }

        public void RandomTile()
        {
            if (IsFreeTile())
            {                                
                List<Tile> emptyTiles = new();
                for (int row = 0; row < RowCount; row++)
                {
                    for (int column = 0; column < ColumnCount; column++)
                    {
                        if (GetTile(row, column) == null)
                            emptyTiles.Add(tiles[row, column]);
                    }
                }
                int randomIndex = random.Next(0, emptyTiles.Count);                
                int check = -1;
                for (int row = 0; row < RowCount; row++)
                {
                    for(int column = 0; column < ColumnCount; column++)
                    {
                        if (tiles[row, column] == null)
                            check++;
                        if (check == randomIndex)
                        {
                            if (random.NextDouble() > 0.1)                                                            
                                tiles[row, column] = new Tile(1);                            
                            else                           
                                tiles[row, column] = new Tile(2);                            
                            return;
                        }
                    }
                }
            }
        }

        public bool IsLost()
        {
            if (!IsFreeTile() && !CheckMove())
                return true;
            else
            {
                return false;
            }
        }

        public bool IsFreeTile()
        {
            for(int row = 0; row < RowCount; row++)
            {
                for(int column = 0; column < ColumnCount; column++)
                {
                    if (GetTile(row, column) == null)
                        return true;
                }
            }
            return false;
        }

        public void EmptyCalculate()
        {
            for(int row = 0; row < RowCount; row++)
            {
                for(int column = 0; column < ColumnCount; column++)
                {
                    if (GetTile(row, column) != null)
                        tiles[row, column].IsCalculate = false;
                }
            }
        }

        public void NewScore()
        {
            if(score.ScoreReal >= score.ScoreMax)
                score.ScoreMax = score.ScoreReal;
        }

        public bool CheckMove()
        {
            for(int row = 0; row < RowCount; row++)
            {
                for(int column = 0; column < ColumnCount; column++)
                {
                    if (GetTile(row, column) != null
                        && (row + 1 < 4 && GetTile(row + 1, column) != null
                        && GetTile(row, column).Value == GetTile(row + 1, column).Value)
                        || (row - 1 >= 0 && GetTile(row - 1, column) != null
                        && GetTile(row, column).Value == GetTile(row - 1, column).Value) 
                        || (column + 1 < 4 && GetTile(row, column + 1) != null
                        && GetTile(row, column).Value == GetTile(row, column + 1).Value)
                        || (column - 1 >= 0 && GetTile(row, column - 1) != null
                        && GetTile(row, column).Value == GetTile(row, column - 1).Value))
                        return true;
                }
            }
            return false;
        }

        public int GetTime()
        {
            return (DateTime.Now - startTime).Seconds;
        }

        public bool IsWin()
        {
            for (int row = 0; row < RowCount; row++)
            {
                for (int column = 0; column < ColumnCount; column++)
                {
                    if (GetTile(row, column) != null && GetTile(row, column).Value == 1024)
                        return true;
                }
            }
            return false;
        }
    }
}
