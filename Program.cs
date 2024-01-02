using System;
using System.Threading;
namespace TIC_TAC_TOE
{
    class Program
    {
        
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int[] arrchoices = { 1, 2, 3, 4, 5, 6 , 7, 8, 9 };
        static int playercount;
        static int player = 1; 
        static string playname1 ="", playname2="";
        static int choice; 
        static int flag = 0;
        static void Main(string[] args)
        {
            
            
             Console.BackgroundColor = ConsoleColor.DarkBlue;
             Console.Clear();
            
             Console.ForegroundColor = ConsoleColor.White;
            
            welcome();
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
    
            
            do
            {
              Console.Write("Type 1 for single player, Type 2 for multiplayer ");
              playercount = Convert.ToInt32(Console.ReadLine());
              
            }
            while(playercount < 1 || playercount > 2);
            
            do
            {
                if(playercount == 1)
                {
                    Console.Write("Enter player 1 name: ");
                    playname1 = Console.ReadLine();
                }
                else
                {
                    Console.Write("Enter player 1 name: ");
                    playname1 = Console.ReadLine();
                    
                    Console.Write("Enter player 2 name: ");
                    playname2 = Console.ReadLine();
                }
                
                do
                {
                    Console.Clear();
                    Console.WriteLine("Player1:X and Player2:O");
                    Console.WriteLine("\n");
                    if (playercount == 1) {
                        if (player % 2 == 1) {
                            Console.WriteLine("Press 0 to exit ");
                            Console.WriteLine("\n");
                            Board();
                            choice = Int32.Parse(Console.ReadLine());
                        } else {
                            Easybot();
                        }
                    } else {
                        if (player % 2 == 0)
                        {
                            Console.WriteLine("Player 2 Chance");
                        }
                        else
                        {
                            Console.WriteLine("Player 1 Chance");
                        }
                        Console.WriteLine("Press 0 to exit ");
                        Console.WriteLine("\n");
                        Board();
                        choice = Int32.Parse(Console.ReadLine());
                    }
                    
                    if(choice != 0)
                    {
                       
                        if (arr[choice] != 'X' && arr[choice] != 'O')
                        {
                            removeTaken();
                            
                            if (player % 2 == 0) 
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
                        else
                        
                        {
                            Console.WriteLine("Sorry the row {0} is already marked with {1}", choice, arr[choice]);
                            Console.WriteLine("\n");
                            Console.WriteLine("Please wait a moment board is loading again.....");
                            Thread.Sleep(2000);
                        }
                        flag = CheckWin();
                    } else
                    
                    {
                        flag = 1;
                    }
                    
                    
                    
                }
                while (flag != 1 && flag != -1);
                
                Console.Clear();
                Board();
                if (flag == 1 && choice != 0)
                {
                    if (playercount == 1) {
                        if ((player % 2)+ 1 == 1) {
                            Console.WriteLine(playname1+" has won");
                        } else {
                            Console.WriteLine("Bot has won");
                        }
                    } else {
                        if ((player % 2)+ 1 == 1) {
                            Console.WriteLine(playname1+" has won");
                        } else {
                            Console.WriteLine(playname2+" has won");
                        }
                        
                    }
                    
                }
                else if(choice == 0)
                {
                    
                }
                else
                {
                    Console.WriteLine("Draw");
                }
                
                Console.WriteLine("Do you want to play again? Press (1) if YES and Press (0) if you want to EXIT");
                choice = Int32.Parse(Console.ReadLine());
                
                if (choice == 1) {
                    Console.Clear();
                    renewBoard();
                }
                
                
            }while(choice != 0);
            
            
        }
        
        public static void welcome()
        {
            Console.WriteLine("************************************************");
            Console.WriteLine("************************************************");
            Console.WriteLine("** **      **       *******       **       ** **");
            Console.WriteLine("**   **  **         **   **         **   **   **");
            Console.WriteLine("**     **           **   **           **      **");
            Console.WriteLine("**   **  **    **   **   **  **     **  **    **");
            Console.WriteLine("** **      **  **   *******  **   **      **  **");
            Console.WriteLine("************************************************");
            Console.WriteLine("************************************************");
            Console.WriteLine("                 Tic Tac Toe                    ");
        }
        
        public static void renewBoard()
        {
            player = 1;
            arr[0] = '0';
            arr[1] = '1';
            arr[2] = '2';
            arr[3] = '3';
            arr[4] = '4';
            arr[5] = '5';
            arr[6] = '6';
            arr[7] = '7';
            arr[8] = '8';
            arr[9] = '9';
        }
        
        public static void removeTaken()
        {
            for (int i = 0; i < arrchoices.Length; i++)
            {
                if (arrchoices[i] == choice)
                {
                    for (int index = i + 1; index < arrchoices.Length; index++)
                    {
                        arrchoices[index - 1] = arrchoices[index];
                    }
                    Array.Resize(ref arrchoices, arrchoices.Length - 1);
                    return;
                }
            }
        }
        
        public static void Easybot()
        {
            Random rnd = new Random();
            int num = rnd.Next(arrchoices.Length - 1);
            choice = arrchoices[num];
            removeTaken();
        }
        
        
        
        public static void Board()
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
        
        public static int CheckWin()
        {
            #region Horzontal Winning Condtion
            
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }
            
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }
            
            else if (arr[7] == arr[8] && arr[8] == arr[9])
            {
                return 1;
            }
            #endregion
            #region vertical Winning Condtion
            
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
            
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }
            #endregion
            #region Diagonal Winning Condition
            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1;
            }
            #endregion
            #region Checking For Draw
            
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }
            #endregion
            else
            {
                return 0;
            }
        }
    }
}




