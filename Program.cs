using System;
using System.Collections.Generic;
namespace tic_tac_toe
{
    class Program
    {
        static void draw_board(List<string> spaces)
        {
            //Draw out the board
            Console.WriteLine($"{spaces[7]}|{spaces[8]}|{spaces[9]}");
            Console.WriteLine($"{spaces[4]}|{spaces[5]}|{spaces[6]}");
            Console.WriteLine($"{spaces[1]}|{spaces[2]}|{spaces[3]}");
        }
        static void logic(List<string> spaces, List<bool> filled) {
            int x;
            int y;
            for (y = 11; y < 13; y++) {
                for (x = 1; x < 8; x = x+3){ // Horizontal
                    if (spaces[x] == spaces[y] & spaces[x+1] == spaces[y] & spaces[x+2] == spaces[y]) {Console.BackgroundColor = ConsoleColor.Yellow; Console.WriteLine("Winner!"); filled[0] = true;}}
                for (x = 1; x < 4; x++){ //Vertical
                    if (spaces[x] == spaces[y] & spaces[x+3] == spaces[y] & spaces[x+6] == spaces[y]) {Console.BackgroundColor = ConsoleColor.Yellow; Console.WriteLine("Winner!"); filled[0] = true;}}
                for (x = 1; x < 4; x = x+2){
                    if (spaces[x] == spaces[y] & spaces[x+4] == spaces[y] & spaces[x+8] == spaces[y]) {Console.BackgroundColor = ConsoleColor.Yellow; Console.WriteLine("Winner!"); filled[0] = true;}
                    else if (spaces[x] == spaces[y] & spaces[x+2] == spaces[y] & spaces[x+4] == spaces[y]) {Console.BackgroundColor = ConsoleColor.Yellow; Console.WriteLine("Winner!"); filled[0] = true;}}
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
                    if (filled[space] == false) {
                        //Put an X or O
                        spaces[space] = turn;
                        //Check if the game is over
                        logic(spaces, filled);
                        if (turn == "X" & filled[0] == false) {
                            Console.BackgroundColor = ConsoleColor.Blue; 
                            turn = "O";
                            }
                        else if (filled[0] == false) {
                            Console.BackgroundColor = ConsoleColor.Red; 
                            turn = "X";
                            }
                        filled[space] = true;
                    }
                    else {Console.BackgroundColor = ConsoleColor.Black; Console.WriteLine("\nThat is not an open space");} 
                }      
                draw_board(spaces); 
                Console.Write("Would you like to play again (yes/no): ");
                answer = Console.ReadLine();
            }
        }
    }
}