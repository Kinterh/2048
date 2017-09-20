using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// 유루유리~ 하지마루욧 

namespace Twozerofourpal
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            // 시작할 때 보드 두개 
            board.AddBlock();
            board.AddBlock();

            while (true)
            {
                var result = false;
                var input = Console.ReadKey().Key;
                while (!result)
                {
                    switch (input)
                    {
                        case ConsoleKey.LeftArrow:
                            result = board.Move(Way.left);
                            break;
                        case ConsoleKey.RightArrow:
                            result = board.Move(Way.right);
                            break;
                        case ConsoleKey.DownArrow:
                            result = board.Move(Way.down);
                            break;
                        case ConsoleKey.UpArrow:
                            result = board.Move(Way.up);
                            break;
                    }
                }
                if (!board.Move(Way.check))
                {
                    Gameober();
                    break;
                }
            }
        }

        static void Gameober()
        {

        }
    }
}
