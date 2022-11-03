using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1024Core.Core;
using _1024Core.Service;
using _1024Core.Entity;

namespace _1024Console._Console
{
    public class ConsoleUI
    {
        private readonly Field field;
        private readonly IScoreService serviceScore = new ScoreServiceFile();        
        private readonly IScoreServiceDB serviceScore2 = new ScoreServiceEF();
        private readonly ICommentSevice commentSevice = new CommentServiceFile();
        private readonly ICommentSeviceDB commentSevice2 = new CommentServiceEF();
        private string name;
        private bool isPress;

        public ConsoleUI(Field field)
        {            
            this.field = field;
        }

        public void Play()
        {                                   
            //PrintTopScores();            
            //Thread.Sleep(5000);
            do
            {
                if (!isPress)
                {
                    PrintField();
                    PrintTime();
                }
                ProcessInput();
            } while (!field.IsLost());
            
            PrintField();            
            Console.WriteLine("Game over");
            Name();
            ProcessInput();
        }

        private void PrintField()
        {
            Console.SetCursorPosition(0, 6);
            Console.Clear();
            Console.WriteLine($"Score: {field.score.ScoreReal}\tMax score: {field.score.ScoreMax}");
            for (int row = 0; row < field.RowCount; row++)
            {
                for (int column = 0; column < field.ColumnCount; column++)
                {                    
                    if (field.GetTile(row, column) != null)
                    {
                        Console.ForegroundColor = PrintColor(field, row, column);
                        Console.Write("{0,5}", field[row, column].Value, Console.ForegroundColor);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                        Console.Write("{0,5}", 'X');
                }
                Console.WriteLine();
            }                       
        }

        private void ProcessInput()
        {            
            //Console.CursorVisible = false;
            ConsoleKey key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if(!isPress)
                        field.Move(Direction.Up);
                    break;
                case ConsoleKey.DownArrow:
                    if (!isPress)
                        field.Move(Direction.Down);
                    break;
                case ConsoleKey.LeftArrow:
                    if (!isPress)
                        field.Move(Direction.Left);
                    break;
                case ConsoleKey.RightArrow:
                    if (!isPress)
                        field.Move(Direction.Right);
                    break;
                case ConsoleKey.R:
                    if (!isPress)
                        field.Restart();
                    break;
                case ConsoleKey.Escape:                    
                    Environment.Exit(0);
                    break;
                case ConsoleKey.T:
                    PrintTopScores();
                    isPress = true;
                    break;
                case ConsoleKey.C:
                    Comment();
                    isPress = true;
                    break;
                case ConsoleKey.W:
                    PrintComment();
                    isPress = true;
                    break;
                default:
                    isPress = false;
                    break;
            }            
        }

        public ConsoleColor PrintColor(Field field, int row, int column)
        {
            int value = field.GetTile(row, column).Value;
            switch (value)
            {
                case 1:
                    return ConsoleColor.Green;                    
                case 2:
                    return ConsoleColor.Red;
                case 4:
                    return ConsoleColor.Yellow;
                case 8:
                    return ConsoleColor.Magenta;
                case 16:
                    return ConsoleColor.Cyan;
                case 32:
                    return ConsoleColor.Blue;
                case 64:
                    return ConsoleColor.DarkGreen;
                case 128:
                    return ConsoleColor.DarkRed;
                case 256:
                    return ConsoleColor.DarkYellow;
                case 512:
                    return ConsoleColor.DarkMagenta;
                case 1024:
                    return ConsoleColor.DarkCyan;
                case 2048:
                    return ConsoleColor.DarkBlue;
                default:
                    return ConsoleColor.White;
            }
        }

        private void PrintTopScores()
        {
            Console.WriteLine("Name player:\tScore:");            
            foreach ( PlayerScoreDB score in serviceScore2.GetTopScores(3))
            {
                Console.WriteLine($"{score.Player}\t\t{score.Points}");
            }
        }

        private void Name()
        {
            if (name == null)
            {
                Console.Write("Name: ");
                name = Console.ReadLine();
            }
            //serviceScore.AddScore(new PlayerScore
            Console.Write("Name: ");
            name = Console.ReadLine();
            serviceScore2.AddScore(new PlayerScoreDB
            {
                Player = name,
                Points = field.score.ScoreMax,
                PlayedAt = DateTime.Now
            });
            PrintTopScores();
        }

        private void PrintTime()
        {
            Console.WriteLine($"Time: {field.GetTime()}");
            Console.WriteLine();
            //Console.SetCursorPosition(0, 5);
            //Console.Clear();
        }

        private void Comment()
        {
            Console.Write("Name: ");
            name = Console.ReadLine();
            string commentName;
            commentName = Console.ReadLine();
            int rat = -1;
            Console.Write($"Rating (0 - 5):  ");
            while(rat < 0 || rat > 5)
                rat = Convert.ToInt32(Console.ReadLine());
            commentSevice2.AddComment(new CommentDB
            {
                Player = name,
                Points = rat,
                dateTime = DateTime.Now,
                _Comment = commentName
            });
            PrintComment();
        }

        private void PrintComment()
        {
            Console.SetCursorPosition(0, 8);
            Console.WriteLine("Comments: ");
            foreach(CommentDB comment in commentSevice2.GetComments())
            {
                Console.WriteLine($"{comment.Player}   Rating: {comment.Points}/5");
                Console.WriteLine($"{comment._Comment}\n");               
            }
            //Thread.Sleep(5000);
        }
    }
}
