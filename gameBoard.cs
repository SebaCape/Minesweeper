using System;
using System.Collections.Generic;

namespace Minesweeper
{
     public class gameBoard
     { 
          public static void Main()
          {
            //variable declaration
            Cell[,] board;
            string gameMode;
            int mineCount;
            int x;
            int y;

            //board size selection prompt & logic
            gameSelect:
            Console.WriteLine("1 for small board, 2 for medium board, 3 for large board");
            gameMode = Console.ReadLine();

            switch(gameMode)
            {
               case "1":
               board = new Cell[8,8];
               x = 8;
               y = 8;
               mineCount = 13;
               break;

               case "2":
               board = new Cell[12,12];
               x = 12;
               y = 12;
               mineCount = 29;
               break;

               case "3":
               board = new Cell[20,20];
               x = 20;
               y = 20;
               mineCount = 80;
               break;

               default:
               goto gameSelect;
            }

            //board generation
            for(int i = 0; i < x; i++)
            {
             for(int j = 0; j < y; j++)
             {
              board[i,j] = new Cell();
              //Console.WriteLine(board[i,j].PrintData());
             }
            } 

            //mine placement
            Random rx = new Random();
            int nx;
            Random ry = new Random();
            int ny;
            int currentMines = 0;

            while(currentMines < mineCount)
            {
             nx = rx.Next(0,x);
             ny = ry.Next(0,y);
             if(board[ny,nx].isMine != true)
             {
             board[ny,nx].isMine = true;
             currentMines++;
             }
            }
            
            //adjacent mine counter for individual cell
            void howManyAdj(int xx, int yy)
            {
                for (int i = y - 1; i <= y + 1; i++)
                {
                  for (int j = x - 1; j <= x + 1; j++)
                  {
                    if (i >= 0 && i < y && j >= 0 && j < x)
                      {
                      if (board[i,j].isMine)
                        {
                          board[xx,yy].adjMines ++;
                        }
                      }
                  }
                }
            }

             /* code for printing out each mines' attributes
            for(int i = 0; i < x; i++)
            {
             for(int j = 0; j < y; j++)
             {
              Console.WriteLine(board[i,j].PrintData());
             }
            }*/

          }
     }
}