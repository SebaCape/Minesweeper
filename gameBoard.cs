using System;
using System.Collections.Generic;

namespace Minesweeper
{
     public class gameBoard
     { 
          public static void Main()
          {
            //variable declaration
            int[,] board;
            string input;
            int mineCount;
            int x;
            int y;

            //board size selection prompt & logic
            gameSelect:
            Console.WriteLine("1 for small board, 2 for medium board, 3 for large board");
            input = Console.ReadLine();

            switch(input)
            {
               case "1":
               board = new int[8,8];
               x = 8;
               y = 8;
               mineCount = 13;
               break;

               case "2":
               board = new int[12,12];
               x = 12;
               y = 12;
               mineCount = 29;
               break;

               case "3":
               board = new int[20,20];
               x = 20;
               y = 20;
               mineCount = 80;
               break;

               default:
               goto gameSelect;
            }

            for(int i = 0; i < x; i++)
            {
             Random r = new Random();
             int n = r.Next(0,x);
             board[i,n] = -1;

             for(int j = 0; j < y; j++)
             {
               Console.Write(board[i,j]);
             }

             Console.WriteLine();
            } 
          }
     }
}