// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_study001
{
    internal class Class1
    {

        static int[] map = new int[100];
        static int[] player = new int[2];
        static string[] name = new string[2];
        static bool[] flags = new bool[2];

        static void Main()
        {
            InitailMap();
            GameShow();

            draw();
            #region 输入玩家名字
            Console.WriteLine("请输入玩家1的姓名");
            name[0] = Console.ReadLine();
            while (name[0] == "")
            {
                Console.WriteLine("玩家的姓名不能为空");
                name[0] = Console.ReadLine();
            }
            Console.WriteLine("请输入玩家2的姓名");
            name[1] = Console.ReadLine();
            while (name[1] == "" || name[1] == name[0])
            {
                if (name[1] == "")
                {
                    Console.WriteLine("玩家的姓名不能为空");
                    name[1] = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("玩家1的名字不能和玩家2相同");
                    name[1] = Console.ReadLine();
                }
            }
            #endregion
            Console.Clear();

            draw();
            Console.WriteLine("{0}的士兵是A", name[0]);
            Console.WriteLine("{0}的士兵是B", name[1]);

            while (player[0] <= 99 && player[1] <= 99)
            {
                if (!flags[0])
                {
                    playGame(0);
                }
                else
                {
                    flags[0] = false;
                }
                if (player[0] >= 99)
                {
                    Console.Clear();
                    Console.WriteLine("玩家{0}无耻的赢了玩家{1}", name[0], name[1]);
                    break;
                }
                if (!flags[1])
                {
                    playGame(1);
                }
                else
                {
                    flags[1] = false;
                }

                if (player[1] >= 99)
                {
                    Console.Clear();

                    Console.WriteLine("玩家{0}无耻的赢了玩家{1}", name[1], name[0]);
                    break;
                }

            }//while
            Console.ReadKey();


        }
        public static void GameShow()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("************");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("************");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("***飞行棋***");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("************");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("************");
        }
        public static void InitailMap()
        {
            int[] luckyTurn = { 6, 23, 40, 55, 69, 83 };
            for (int i = 0; i < luckyTurn.Length; i++)
            {
                map[luckyTurn[i]] = 1;
            }
            int[] lindMine = { 5, 13, 17, 33, 38, 50, 64, 80, 94 };
            for (int i = 0; i < lindMine.Length; i++)
            {
                map[lindMine[i]] = 2;
            }
            int[] pause = { 9, 27, 60, 93 };
            for (int i = 0; i < pause.Length; i++)
            {
                map[pause[i]] = 3;
            }
            int[] timeTunnel = { 20, 25, 45, 63, 72, 88, 90 };
            for (int i = 0; i < timeTunnel.Length; i++)
            {
                map[timeTunnel[i]] = 4;
            }
        }
        public static void draw()
        {

            Console.WriteLine("图例：幸运轮盘：★    地雷：▼    暂停：卍    时空隧道：＠");
            int i;
            for (i = 0; i <= 29; i++)
            {
                Console.Write(draw_a(i));

            }
            Console.WriteLine();
            for (int j = 0; j < 5; j++)
            {
                for (int k = 1; k <= 29; k++)
                {
                    Console.Write("  ");
                }
                Console.WriteLine(draw_a(i++));
            }
            i += 30;
            for (int j = 64; j >= 35; j--)
            {
                Console.Write(draw_a(j));
            }
            Console.WriteLine();
            for (int j = 0; j < 5; j++)
            {
                Console.WriteLine(draw_a(i++));

            }
            for (int k = 70; k <= 99; k++)
            {
                Console.Write(draw_a(i++));
            }
            Console.WriteLine();
        }
        public static string draw_a(int n)
        {
            string s = "NULL";
            if (player[1] == player[0] && player[1] == n)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                s = "<>";
            }
            else if (player[0] == n)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                s = "Ａ";
            }
            else if (player[1] == n)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                s = "Ｂ";
            }
            else switch (map[n])
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        s = "★";
                        break;
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        s = "□";
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        s = "▼";
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        s = "卍";
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Green;
                        s = "＠";
                        break;
                }
            return s;
        }
        public static void playGame(int n)
        {
            Random r = new Random();
            int rNum = r.Next(1, 7);
            Console.WriteLine("玩家{0}按任意键开始掷骰子", name[n]);
            Console.ReadKey(true);
            Console.WriteLine("玩家{0}掷出了{1}点，按任意键继续", name[n], rNum);
            player[n] += rNum;
            Console.ReadKey(true);
            Console.Clear();
            poschange();
            draw();




            if (player[n] == player[1 - n])
            {
                player[1 - n] -= 6;
            }
            else
            {
                switch (map[player[n]])
                {
                    case 0:

                        Console.WriteLine("玩家{0}踩到了方块,安全,按任意键继续", name[n]);
                        Console.ReadKey(true);
                        break;
                    case 1:

                        Console.WriteLine("玩家{0}踩到了幸运方块，请选择1--交换位置，2--轰炸对方", name[n]);
                        string input = Console.ReadLine();
                        while (true)
                        {
                            if (input == "1")
                            {
                                Console.WriteLine("玩家{0}与玩家{1}交换位置", name[n], name[1 - n]);
                                int temt = player[n];
                                player[n] = player[1 - n];
                                player[1 - n] = temt;
                                Console.ReadKey(true);
                                break;
                            }
                            else if (input == "2")
                            {
                                Console.WriteLine("玩家{0}选择选择轰炸玩家{1}，玩家{2}退6格", name[n], name[1 - n], name[1 - n]);
                                Console.ReadKey(true);
                                player[1 - n] -= 6;
                                Console.WriteLine("玩家{0}退了6格", name[1 - n]);
                                Console.ReadKey(true);

                                break;

                            }
                            else
                            {
                                Console.WriteLine("玩家{0}很调皮，没有输入1或2，请重新输入", name[n]);
                                input = Console.ReadLine();
                            }


                        }

                        break;
                    case 2:
                        Console.WriteLine("玩家{0}踩到了地雷，退6格", name[n]);
                        Console.ReadKey(true);
                        player[n] -= 6;
                        break;
                    case 3:
                        Console.WriteLine("玩家{0}踩到了暂停，暂停一回合", name[n]);
                        Console.ReadKey(true);
                        flags[n] = true;
                        break;
                    case 4:
                        Console.WriteLine("玩家{0}踩到了时空隧道，前进十格", name[n]);
                        player[n] += 10;
                        Console.ReadKey(true);
                        break;



                }//switch
            }//else
            poschange();
            Console.Clear();
            draw();

        }
        public static void poschange()
        {
            if (player[0] < 0)
            {
                player[0] = 0;
            }
            if (player[1] < 0)
            {
                player[1] = 0;
            }
            if (player[0] >= 99)
            {
                player[0] = 99;
            }
            if (player[1] >= 99)
            {
                player[1] = 99;
            }
        }
    }
}

