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

        public int score = 0;
        public int maxScore = 0;

        public int[,] Numbers = new int[4, 4];

        private bool[,] _IsCombined = new bool[4, 4];
        

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
            while (Numbers[y, x] != 0);

            Numbers[y, x] = new int[] { 2, 2, 4 }[r.Next(0, 3)];
            Console.WriteLine("({0}, {1})에 블럭 {2} 추가됨", x, y, Numbers[y, x]);
        }


        ///<summary>
        ///움직일 수 없을 때 false를 반환합니다.
        ///</summary>
        public bool Move(Way way)
        {
            bool isMove = false;
            _IsCombined = new bool[4, 4]{
                { false,false,false,false},
                { false,false,false,false},
                { false,false,false,false},
                { false,false,false,false}
            };

            #region CopyTempArray
            int[,] tempNum = new int[4, 4];
            for (int y = 0; y < 4; y++)
                for (int x = 0; x < 4; x++)
                {
                    tempNum[y, x] = Numbers[y, x];
                }
            #endregion

            #region CHECK
            if (way == Way.check)
            {
                Console.WriteLine("Check 진입!");

                bool[,] tempCom = new bool[4, 4];

                #region CopyTempArray
                for (int y = 0; y < 4; y++)
                    for (int x = 0; x < 4; x++)
                    {
                        tempNum[y, x] = Numbers[y, x];
                    }
                #endregion

                bool result =
                Move(Way.left | Way.check) ||
                Move(Way.right | Way.check) ||
                Move(Way.down | Way.check) ||
                Move(Way.up | Way.check);

                #region CopyMainArray
                for (int y = 0; y < 4; y++)
                    for (int x = 0; x < 4; x++)
                    {
                        Numbers[y, x] = tempNum[y, x];
                    }
                #endregion
                Console.WriteLine("Check 끝남 : result : {0}", result);
                return result;
            }
            #endregion

            #region LEFT
            if (way.HasFlag(Way.left))
            {
                for (int y = 0; y < 4; y++)
                {
                    int x = 0;
                    while (x < 3)
                    {
                        if (Numbers[y, x] == 0) x++;
                        else
                        {
                            for (int i = x + 1; i < 4; i++)
                            {
                                if (Numbers[y, i] == 0) continue;
                                if (Numbers[y, x] == Numbers[y, i] && !_IsCombined[y, x])
                                {
                                    Console.WriteLine("({0}, {1}) == ({2}, {3})", i, y, x, y);
                                    Numbers[y, x] *= 2;
                                    Numbers[y, i] = 0;
                                    _IsCombined[y, x] = true;
                                    isMove = true;
                                    if (!way.HasFlag(Way.check))
                                    {
                                        maxScore = maxScore > Numbers[y, x] ? maxScore : Numbers[y, x];
                                        score += Numbers[y, x];
                                    }
                                }
                                if (Numbers[y, x] != Numbers[y, i])
                                {
                                    break;
                                }
                            }
                            x++;
                        }
                    }
                }
                for (int y = 0; y < 4; y++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        if (Numbers[y, x] != 0) continue;
                        for (int i = x + 1; i < 4; i++)
                        {
                            if (Numbers[y, i] != 0)
                            {
                                Console.WriteLine("({0}, {1}) -> ({2}, {3}) : value : {4}", i, y, x, y, Numbers[y, i]);
                                Numbers[y, x] = Numbers[y, i];
                                Numbers[y, i] = 0;
                                isMove = true;
                                break;
                            }
                        }
                    }
                }
                if (way.HasFlag(Way.right)) { RotateRight(); RotateRight(); }
                else if (way.HasFlag(Way.down)) { RotateRight(); RotateRight(); RotateRight(); }
                else if (way.HasFlag(Way.up)) { RotateRight(); }
                if (way.HasFlag(Way.check))
                { 
                    #region CopyMainArray
                    for (int y = 0; y < 4; y++)
                        for (int x = 0; x < 4; x++)
                        {
                            Numbers[y, x] = tempNum[y, x];
                        }
                    #endregion
                }
                return isMove;
            }
            #endregion
            #region RIGHT
            else if (way.HasFlag(Way.right))
            {
                RotateRight(); RotateRight();
                return Move(way | Way.left | Way.right);
            }
            #endregion
            #region DOWN
            else if (way.HasFlag(Way.down))
            {
                RotateRight();
                return Move(way | Way.left | Way.down);
            }
            #endregion
            #region UP
            else if (way.HasFlag(Way.up))
            {
                RotateRight(); RotateRight(); RotateRight();
                return Move(way | Way.left | Way.up);
            }
            #endregion

            return isMove;

        }

        public void RotateRight()
        {
            int[,] temp = new int[4, 4];
            bool[,] tempCom = new bool[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    temp[j, 3 - i] = Numbers[i, j];
                    tempCom[j, 3 - i] = _IsCombined[i, j];
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    _IsCombined[i, j] = tempCom[i, j];
                    Numbers[i, j] = temp[i, j];
                }
            }
        }

        /// <summary>
        /// 안씀 ㅋ 다 RotateRight로 대체
        /// </summary>
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