namespace TicTacToeGame
{
    internal class Program
    {
        static char[] spaces = ['1', '2', '3', '4', '5', '6', '7', '8', '9'];
        static bool player = false;
        static int SpaceSize = spaces.Length;
        static int flag;
        static double Wins = 0;
        static double Loses = 0;

        /// <summary>
        /// Draw X on the board
        /// </summary>
        /// <param name="pos"></param>
        static void DrawX(int pos)
        {
            if (spaces[pos - 1] != 'X' && spaces[pos - 1] != 'O')
            {
                spaces[pos - 1] = 'X';
                SpaceSize--;
                player = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This cell is not empty! Try another one.");
                Console.ResetColor();
                Thread.Sleep(2000);

            }
        }

        /// <summary>
        /// Draw O on the board
        /// </summary>
        /// <param name="pos"></param>
        static void DrawO(int pos) 
        {
            if (spaces[pos - 1] != 'X' && spaces[pos - 1] != 'O')
            {
                spaces[pos - 1] = 'O';
                SpaceSize--;
                player = false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This cell is not empty! Try another one.");
                Console.ResetColor();
                Thread.Sleep(2000);
            }
        }

        static int IsPlaying()
        {
            if (spaces[0] == spaces[1] && spaces[1] == spaces[2] || // Row 1
                spaces[3] == spaces[4] && spaces[4] == spaces[5] || // Row 2
                spaces[6] == spaces[7] && spaces[7] == spaces[8] || // Row 3
                spaces[0] == spaces[3] && spaces[3] == spaces[6] || // Column 1
                spaces[1] == spaces[4] && spaces[4] == spaces[7] || // Column 2
                spaces[2] == spaces[5] && spaces[5] == spaces[8] || // Column 3
                spaces[0] == spaces[4] && spaces[4] == spaces[8] || // diagonal 1
                spaces[2] == spaces[4] && spaces[4] == spaces[6]    // diagonal 2
                )
            {
                if(player == true){ return 1; }
                else { return 2; }
            }
            else {
                if (SpaceSize == 0) {  return 0; }
            }
                return -1; 
        }
        static void DarwBoard()
        {
            Console.Clear();
            Console.Write("Player 1: X Palyer 2: O\t\t");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("WINS: {0} | LOSES: {1}\n\n", Wins, Loses);
            Console.ResetColor();
            Console.WriteLine("\t{0} | {1} | {2}", spaces[0], spaces[1], spaces[2]);
            Console.WriteLine("\t---------");
            Console.WriteLine("\t{0} | {1} | {2}", spaces[3], spaces[4], spaces[5]);
            Console.WriteLine("\t---------");
            Console.WriteLine("\t{0} | {1} | {2}", spaces[6], spaces[7], spaces[8]);
            Console.Write("\n\n");
        }

        static void ResetGame()
        {
            spaces = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            player = false;
            SpaceSize = spaces.Length;
            Console.Clear();
        }
        static void Main(string[] args)
        {

            do
            {
                int input;
                DarwBoard();
                if(player == false)
                {
                    Console.ForegroundColor= ConsoleColor.Blue;
                    Console.Write("Player 1 turn: ");
                    Console.ResetColor();
                    if(int.TryParse(Console.ReadLine(), out input) == false || input > 9 || input < 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("This Input is not permitted! Choose a number on the board.");
                        Console.ResetColor();
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        DrawX(input);
                    }
                }
                else
                {
                    Console.ForegroundColor= ConsoleColor.Green;
                    Console.Write("Player 2 turn: ");
                    Console.ResetColor();
                    if (int.TryParse(Console.ReadLine(), out input) == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Characters is not permitted! Choose a number on the board.");
                        Console.ResetColor();
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        DrawO(input);
                    }
                }
                DarwBoard();
                flag = IsPlaying();

                switch (flag)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Draw!");
                        Console.ResetColor();
                        Wins += .5f;
                        Loses += .5f;
                        Console.WriteLine("New Game? Y (yes) or N (No):");
                        string? choice = Console.ReadLine().ToLower();
                        if (choice.CompareTo("y") == 0)
                        {
                            flag = -1;
                            ResetGame();
                        }
                        else
                        {
                            flag = -2;

                        }
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Player 1 Won this round!");
                        Console.ResetColor();
                        Wins++;
                        Console.WriteLine("New Game? Y (yes) or N (No):");
                        choice = Console.ReadLine().ToLower();
                        if(choice.CompareTo("y") == 0)
                        {
                            flag = -1;
                            ResetGame();
                        }
                        else
                        {
                            flag = -2;
                            
                        }

                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Player 2 Won this round!");
                        Console.ResetColor();
                        Loses++;
                        Console.WriteLine("New Game? Y (yes) or N (No):");
                        choice = Console.ReadLine().ToLower();
                        if (choice.CompareTo("y") == 0)
                        {
                            flag = -1;
                            ResetGame();

                        }
                        else
                        {
                            flag = -2;
                            break;
                        }
                        break;
                }
                
            }while(flag == -1);
            
            if(Wins > Loses)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Player 1: {Wins} Player 2: {Loses}!\n");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Player 1 Won the game!");
                Console.ResetColor();
            }else if(Wins < Loses)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Player 1: {Wins} Player 2: {Loses}!\n");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Player 2 Won the game!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Player 1: {Wins} Player 2: {Loses}!\n");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("We have a DRAW!");
                Console.ResetColor();
            }

            Console.ReadKey();
        }
    }
}
