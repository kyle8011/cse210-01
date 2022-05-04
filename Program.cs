using System;
using System.Collections.Generic;
namespace tic_tac_toe
{
    class Program
    {
        static void draw_board(List<string> spaces)
        {
            //Draw out the board
            Console.WriteLine($"     {spaces[7]}|{spaces[8]}|{spaces[9]}");
            Console.WriteLine($"     {spaces[4]}|{spaces[5]}|{spaces[6]}");
            Console.WriteLine($"     {spaces[1]}|{spaces[2]}|{spaces[3]}");
        }
        static void logic(List<string> spaces, List<bool> filled, string turn) {
            int x;
            int y;
            int count;
            for (y = 11; y < 13; y++) {
                for (x = 1; x < 8; x = x+3){ // Horizontal
                    if (spaces[x] == spaces[y] & spaces[x+1] == spaces[y] & spaces[x+2] == spaces[y]) {Console.BackgroundColor = ConsoleColor.Yellow; Console.WriteLine($"    {turn}'s Win!"); filled[0] = true;}}
                for (x = 1; x < 4; x++){ //Vertical
                    if (spaces[x] == spaces[y] & spaces[x+3] == spaces[y] & spaces[x+6] == spaces[y]) {Console.BackgroundColor = ConsoleColor.Yellow; Console.WriteLine($"    {turn}'s Win!"); filled[0] = true;}}
                //Diagonal 
                if (spaces[1] == spaces[y] & spaces[5] == spaces[y] & spaces[9] == spaces[y]) {Console.BackgroundColor = ConsoleColor.Yellow; Console.WriteLine($"    {turn}'s Win!"); filled[0] = true;}
                else if (spaces[3] == spaces[y] & spaces[5] == spaces[y] & spaces[7] == spaces[y]) {Console.BackgroundColor = ConsoleColor.Yellow; Console.WriteLine($"    {turn}'s Win!"); filled[0] = true;}
            }
            //Cat's game
            count = 0;
            for (x = 1; x < 10; x++) {
                if (filled[x] == true & filled[0] == false) {
                    count++;
                }
                if (count == 8) {   
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("   Cat's Game");
                    filled[0] = true;
                }
            }
        }
        static void Main(string[] args)
        {
            //Create and fill lists to be used in the game
            //"Spaces" to indicate what number to put in which space
            //"filled" to indicate if the space has been filled yet. 
            //Using "turn" to tell whose turn it is and slot 10 to tell if the game is over
            int x = 0;
            string turn = "X";
            int space = 1;
            string answer = "yes";
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to tic-tac-toe!");
            Console.WriteLine("Enter a number to draw there,");
            Console.WriteLine("enter a zero to end the game.");
            List<string> spaces = new List<string>();
            List<bool> filled = new List<bool>();
            for (x = 0; x < 11; x++) {
                spaces.Add(x.ToString());
                filled.Add(false);
                } 
            spaces.Add("X");
            spaces.Add("O");   
            
            //Reset the game if play again
            while (answer != "no"){
                for(x = 1; x < 10; x++){
                    spaces[x] = x.ToString();
                    filled[x] = false;
                }
                filled[0] = false;
                turn = "X";
                Console.BackgroundColor = ConsoleColor.Red;

                //What to do everytime a value is entered
                while (filled[0] == false & space != 0)
                {
                    Console.WriteLine($" \nIt is now {turn}'s turn");
                    //Draw the board
                    draw_board(spaces);
                    Console.Write($"Select a space to draw an {turn}: ");

                    //Receive input
                    space = int.Parse(Console.ReadLine());
                    //If the space is not filled
                    if (filled[space] == false & space < 10) {
                        //Put an X or O in the space
                        spaces[space] = turn;

                        //Check if the game is over
                        logic(spaces, filled, turn);

                        //Change turns
                        if (turn == "X" & filled[0] == false) {
                            Console.BackgroundColor = ConsoleColor.Blue; 
                            turn = "O";
                            }
                        else if (filled[0] == false) {
                            Console.BackgroundColor = ConsoleColor.Red; 
                            turn = "X";
                            }
                        //Fill the space
                        filled[space] = true;
                    }
                    //If an invalid number is typed
                    else {Console.BackgroundColor = ConsoleColor.Black; Console.WriteLine("\nThat is not an open space");} 
                }      
                //End of game, prompt to play again
                draw_board(spaces); 
                Console.Write("Would you like to play again (yes/no): ");
                answer = Console.ReadLine();
            }
        }
    }
}