using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    public class TikTakTou : IStudyTest
    {
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1; //By default player 1 is set  
        static int choice; //This holds the choice at which position user want to mark  


        // The flag variable checks who has won if it's value is 1 then some one has won the match if -1 then Match has Draw if 0 then match is still running  
        static int flag = 0;


        public void Play()
        {
            var task = new Task(() =>
            {
                while (true)
                {
                    foreach (ConsoleColor c in Enum.GetValues(typeof(ConsoleColor)))
                    {
                        var x = Console.CursorLeft;
                        var y = Console.CursorTop;

                        Console.CursorLeft = 0; // set position
                        Console.CursorTop = 0; // set position

                        Console.ForegroundColor = c;
                        Console.WriteLine("Welcome to Tic Tac Toe!");

                        Console.CursorLeft = x;
                        Console.CursorTop = y;

                        Thread.Sleep(1000);
                    }
                }

            });
            
            do
            {
                Console.Clear();// whenever loop will be again start then screen will be clear  

                Console.WriteLine("Welcome to Tic Tac Toe!");
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Player1:X");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Player2:O");
                Console.ResetColor();
                Console.WriteLine("\n");
                if (player % 2 == 0)//checking the chance of the player  
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Player 2's turn");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Player 1's turn");
                    Console.ResetColor();
                }
                Console.WriteLine("\n");
                Board();// calling the board Function

                if (task.Status != TaskStatus.Running)
                {
                    task.Start();
                }
                
                choice = int.Parse(Console.ReadLine());//Taking users choice  

                // checking that position where user want to run is marked (with X or O) or not  
                if (arr[choice] != 'X' && arr[choice] != 'O')
                {

                    if (player % 2 == 0) //if chance is of player 2 then mark O else mark X  
                    {

                        arr[choice] = 'O';
                        player++;
                    }
                    else
                    {
                        arr[choice] = 'X';
                        player++;
                    }
                }
                else //If there is any possition where user want to run and that is already marked then show message and load board again  
                {
                    Console.WriteLine("Sorry the row {0} is already marked with {1}", choice, arr[choice]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Please wait 2 second board is loading again.....");
                    Thread.Sleep(2000);
                }
                flag = CheckWin();// calling of check win  
            } while (flag != 1 && flag != -1);// This loop will be run until all cell of the grid is not marked with X and O or some player is not win  

            Console.Clear();// clearing the console  
            Board();// getting filled board again  

            if (flag == 1)// if flag value is 1 then some one has win or means who played marked last time which has win  
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Player {0} has won", (player % 2) + 1);
                Console.ResetColor();
            }
            else// if flag value is -1 the match will be draw and no one is winner  
            {
                Console.WriteLine("Draw");
            }
            Console.ReadLine();
        }
        // Board method which creates board  
        private static void Board()
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
            Console.ResetColor();
        }

        //Checking that any player has won or not  
        private static int CheckWin()
        {
            //Horzontal Winning Condtion
            //Winning Condition For First Row  
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }
            //Winning Condition For Second Row  
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }
            //Winning Condition For Third Row  
            else if (arr[6] == arr[7] && arr[7] == arr[8])
            {
                return 1;
            }


            //Vertical Winning Condtion
            //Winning Condition For First Column      
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
            //Winning Condition For Second Column  
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            //Winning Condition For Third Column  
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }


            //Diagonal Winning Condition
            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1;
            }


            // Checking For Draw
            // If all the cells or values filled with X or O then any player has won the match  
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }


            else
            {
                return 0;
            }
        }

        public void Study()
        {
            this.Play();
        }
    }
}

