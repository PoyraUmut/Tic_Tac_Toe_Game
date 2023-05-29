using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Login();           
            Console.ReadLine();
        }
        static void Login()
        {
            while (true)
            {
                Console.WriteLine("Enter the name of the first player.");
                string player1_name = Console.ReadLine();
                Console.WriteLine("Enter the name of the second player.");
                string player2_name = Console.ReadLine();

                Console.WriteLine("Welcome! {0} select the letter you want it. (x for X, o for O)", player1_name);
                char player1_letter = Console.ReadKey().KeyChar;
                Console.Clear();
                Console.WriteLine("Welcome! {0} select the letter you want it. (x for X, o for O)", player2_name);
                char player2_letter = Console.ReadKey().KeyChar;
                Console.Clear();
                if (player1_letter == 'x' && player2_letter == 'o')
                {
                    start(player1_name,player2_name);
                    break;
                }
                else if (player1_letter == 'o' && player2_letter == 'x')
                {
                    start(player2_name, player1_name);
                    break;
                }
                else if (player1_letter == player2_letter)
                {
                    Console.WriteLine("Two players choosed the same letter therefore the letters will give randomly.");
                    Random rnd = new Random();
                    int x = rnd.Next(0, 2);
                    if(x == 0)
                    {
                        Console.WriteLine("{0} will be X {1} will be O", player1_name, player2_name);
                        Console.WriteLine("Enter the any key for start the game.");
                        Console.ReadKey();
                        Console.Clear();
                        start(player1_name, player2_name);//player1_letter = 'x' , player2_letter 'o'
                    }
                    else
                    {
                        Console.WriteLine("{0} will be X {1} will be O", player2_name, player1_name);
                        Console.WriteLine("Enter the any key for start the game.");
                        Console.ReadKey();
                        Console.Clear();
                        start(player2_name, player1_name);//player1_letter = 'o' , player2_letter 'x'
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid letter. Please try again.");
                }
            }
        }
        static void start(string first_player,string second_player)
        {
            char[,] map = { { '*', '*', '*' }, { '*', '*', '*' }, { '*', '*', '*' } };
            int turn = 0;// for play the players in order.
            while (true)
            {
                show_map(map);

                if (turn % 2 == 0)
                {
                    while (true)
                    {                       
                        Console.WriteLine("{0}'s turn. Write down which row and column you want to put letters in.",first_player);
                        int row = Convert.ToInt32(Console.ReadLine());
                        int column = Convert.ToInt32(Console.ReadLine());
                        if (map[row,column] == 'O' || map[row,column] == 'X')
                        {
                            Console.WriteLine("This index already has letter.");
                        }
                        else
                        {
                            map[row, column] = 'X';
                            show_map(map);
                            turn++;
                            Console.Clear();
                            break;
                        }
                    }                   
                    //Console.Clear();
                }

                else if (turn % 2 == 1)
                {
                    while (true)
                    {
                        Console.WriteLine("{0}'s turn. Write down which row and column you want to put letters in.", second_player);
                        int row = Convert.ToInt32(Console.ReadLine());
                        int column = Convert.ToInt32(Console.ReadLine());
                        if (map[row, column] == 'O' || map[row, column] == 'X')
                        {
                            Console.WriteLine("This index already has letter.");
                        }
                        else
                        {
                            map[row, column] = 'O';
                            show_map(map);
                            turn++;
                            Console.Clear();
                            break;
                        }
                    }
                }

                if ((map[0,0] == 'X'&& map[0,1] == 'X'&& map[0,2] == 'X')||
                    (map[1, 0] == 'X' && map[1, 1] == 'X' && map[1, 2] == 'X')|| 
                    (map[2, 0] == 'X' && map[2, 1] == 'X' && map[2, 2] == 'X')||
                    (map[0, 0] == 'X' && map[1, 1] == 'X' && map[2, 2] == 'X')|| 
                    (map[0, 0] == 'X' && map[1, 0] == 'X' && map[2, 0] == 'X')||
                    (map[0, 1] == 'X' && map[1, 1] == 'X' && map[2, 1] == 'X')||
                    (map[0, 2] == 'X' && map[1, 2] == 'X' && map[2, 2] == 'X')) //terms of winning for X..
                {
                    show_map(map);
                    Console.WriteLine("{0} has won!",first_player);
                    break;
                }
                

                if ((map[0, 0] == 'O' && map[0, 1] == 'O' && map[0, 2] == 'O')||
                   (map[1, 0] == 'O' && map[1, 1] == 'O' && map[1, 2] == 'O')||
                   (map[2, 0] == 'O' && map[2, 1] == 'O' && map[2, 2] == 'O')||
                   (map[0, 0] == 'O' && map[1, 1] == 'O' && map[2, 2] == 'O')||
                   (map[0, 0] == 'O' && map[1, 0] == 'O' && map[2, 0] == 'O')||
                   (map[0, 1] == 'O' && map[1, 1] == 'O' && map[2, 1] == 'O')||
                   (map[0, 2] == 'O' && map[1, 2] == 'O' && map[2, 2] == 'O')) //terms of winning for O..
                {
                    show_map(map);
                    Console.WriteLine("{0} has won!",second_player);
                    break;
                }

                if(map[0, 0] != '*'&& map[0, 1] != '*' && map[0, 2] != '*' && map[1, 0] != '*' &&
                    map[1, 1] != '*' && map[1, 2] != '*' && map[2, 0] != '*' && map[2, 1] != '*' && map[2, 2] != '*')//terms of draw..
                {
                    show_map(map);
                    Console.WriteLine("Draw!!");
                    break;
                }// end of the terms of the winning.
            }
            
        }
        static void show_map(char[,] map)//shows the table.
        {           
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
