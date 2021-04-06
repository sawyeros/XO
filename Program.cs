using System;

namespace XO
{
    class Program
    {
        static public char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }; //array for tiles while 0 is ignored
        static int player = 1; //start position
        static int tile; //the tile choice of the player
        static int statusflag = 0;//  if 0 match is still on. if 1 someone won. if -1 its draw

        public static void display()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
            Console.WriteLine("     |     |      ");
        }

        public static int Status()
        {
            //First Row 
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }
            //Second Row 
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }
            //Third Row 
            else if (arr[6] == arr[7] && arr[7] == arr[8])
            {
                return 1;
            }

            //First Column     
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
            //Second Column
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            //Third Column
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }
            //Diagonals
            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1;
            }

            //DRAW
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }

            //Game still on
            else
            {
                return 0;
            }
        }

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();// clear screen at start
                Console.WriteLine("Player1:X and Player2:O");
                Console.WriteLine("\n");
                display();// calling the board Function
                Console.WriteLine("\n");
                if (player % 2 == 0)//checking turn
                {
                    Console.WriteLine("Player 2 turn");
                }
                else
                {
                    Console.WriteLine("Player 1 turn");
                }
                Console.WriteLine("\n");
               
                tile = int.Parse(Console.ReadLine());//users entry 

                // checking for legal entry
                if (tile >= 10 || tile <= 0)
                {
                    Console.WriteLine("please choose tiles between 1-9");
                    Console.WriteLine("\n");
                    Console.WriteLine("press enter and try again.....");
                    Console.ReadLine();
                }
                else if (arr[tile] != 'X' && arr[tile] != 'O')
                {
                    if (player % 2 == 0) //even numbers for player 2
                    {
                        arr[tile] = 'O';
                        player++;
                    }
                    else    //odd numbers for player 1
                    {
                        arr[tile] = 'X';
                        player++;
                    }
                }
                else //taken tile
                {
                    Console.WriteLine("tile {0} has {1}", tile, arr[tile]);
                    Console.WriteLine("\n");
                    Console.WriteLine("press enter and try again.....");
                    Console.ReadLine();
                }
                statusflag = Status();// calling check win
            } while (statusflag != 1 && statusflag != -1);// This loop will be run until draw or win

            Console.Clear();
            display();

            if (statusflag == 1)// win - last player who moved has won
            {
                Console.WriteLine("\n");
                Console.WriteLine("Player {0} has won", (player % 2) + 1);
            }
            else// draw
            {
                Console.WriteLine("\n");
                Console.WriteLine("Draw");
            }
            Console.ReadLine();
        }
    }
}
