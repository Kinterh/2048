using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twozerofourpal
{
    public class Board
    {
        Random r = new Random();

        public int[,] Numbers = new int[4, 4];

        public bool[,] IsCombined = new bool[4, 4];


        // 처음 생성됬을 경우 0으로 채움
        public Board() : this(new int[,]  {
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 }})
        { }

        public Board(int[,] numbers)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Numbers[i, j] = numbers[i, j];
                }
            }
        }

        public void AddBlock()
        {
            int x = -1, y = -1;

            do
            {
                x = r.Next(0, 4); y = r.Next(0, 4);
            }
            while (Numbers[x, y] != 0);

            Numbers[x, y] = new int[] { 2, 2, 4 }[r.Next(0, 3)];
        }

        ///<summary>
        ///움직일 수 없을 때 false를 반환합니다.
        ///</summary>
        public bool Move(Way way)
        {
            bool isMove = false;

            if (way == Way.check)
            {
                return
                Move(Way.left | Way.check) ||
                Move(Way.right | Way.check) ||
                Move(Way.down | Way.check) ||
                Move(Way.up | Way.check);
            }

            if (way.HasFlag(Way.left))
            {
                for (int y = 0; y < 4; y++)
                {
                    int x = 0;
                    while (x < 3)
                    {
                        for (int i = x + 1; i < 4; i++)
                        {
                            if (Numbers[i, y] == 0 ) continue;
                            if (Numbers[x, y] == 0) { x++; continue; }
                            if (Numbers[i, y] != Numbers[x, y])
                            {
                                x++;
                                continue;
                            }
                            if (!(IsCombined[x,y]||IsCombined[i,y])&&(Numbers[i, y] == Numbers[x, y]))
                            {
                                IsCombined[x, y] = IsCombined[i, y] = true;
                                Numbers[i, y] = 0;
                                i++;
                                Numbers[x, y] *= 2;
                                isMove = true;
                            }
                        }
                    }
                }
                if(isMove)
                {
                    for(int y=0;y<4;y++)
                    {
                        for(int x=0;x<4;x++)
                        {
                            if(Numbers[x,y]==0)
                            {
                                for(int i=x+1;i<4;i++)
                                {
                                    if(Numbers[i,y]!=0)
                                    {
                                        Numbers[x, y] = Numbers[i, y];
                                        Numbers[i, y] = 0;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                if (way.HasFlag(Way.right)) Flip();
                else if (way.HasFlag(Way.down)) RotateRight();
                else if (way.HasFlag(Way.up)) { Flip(); RotateRight(); }
                return isMove;
            }
            else if (way.HasFlag(Way.right))
            {
                Flip();
                return Move(Way.left | Way.right);
            }
            else if (way.HasFlag(Way.down))
            {
                RotateRight();
                return Move(Way.left | Way.down);
            }
            else if (way.HasFlag(Way.up))
            {
                RotateRight();
                Flip();
                Move(Way.left | Way.up);
            }

            return false;
        }

        public void RotateRight()
        {
            int[,] temp = new int[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    temp[j, 3 - i] = Numbers[i, j];
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Numbers[i, j] = temp[i, j];
                }
            }
        }

        public void Flip()
        {
            int[,] temp = new int[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    temp[3 - i, j] = Numbers[i, j];
                    temp[i, j] = Numbers[3 - i, j];
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Numbers[i, j] = temp[i, j];
                }
            }
        }
    }
}
