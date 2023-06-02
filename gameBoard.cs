using System;
using System.Collections.Generic;

namespace Minesweeper
{
     public class gameBoard
     { 
      
            //variable declaration
            Cell[,] board;
            string [,] sBoard;
            string gameMode;
            int mineCount;
            public int x;
            public int y;
            
            Random rx = new Random();
            int nx;
            Random ry = new Random();
            int ny;
            int currentMines = 0;

            public void gameModeSelect()
            {
             gameSelect:
             Console.WriteLine("1 for small board, 2 for medium board, 3 for large board");
             gameMode = Console.ReadLine();

             switch(gameMode)
             {
               case "1":
               board = new Cell[8,8];
               sBoard = new string[8,8];
               x = 8;
               y = 8;
               mineCount = 13;
               break;

               case "2":
               board = new Cell[12,12];
               sBoard = new string[12,12];
               x = 12;
               y = 12;
               mineCount = 29;
               break;

               case "3":
               board = new Cell[20,20];
               sBoard = new string[20,20];
               x = 20;
               y = 20;
               mineCount = 80;
               break;

               default:
               goto gameSelect;
             }
            }

            //board generation
           public void bGenerate()
            {
             for(int i = 0; i < x; i++)
             {
              for(int j = 0; j < y; j++)
              {
               board[i,j] = new Cell();
              }
             } 
            }

            //mine placement
           public void placeMines()
           {
            while(currentMines < mineCount)
            {
             nx = rx.Next(0,x);
             ny = ry.Next(0,y);
             if(board[ny,nx].isMine != true)
             {
             board[ny,nx].isMine = true;
             board[ny,nx].adjMines = -1;
             currentMines++;
             }
            }
           }
            
            //adjacent mine counter for individual cell
            public void howManyAdj(int xx, int yy)
            {
              if(board[xx,yy].isMine != true)
               {
                for (int i = y - 1; i <= y + 1; i++)
                {
                  for (int j = x - 1; j <= x + 1; j++)
                  {
                    if (i >= 0 && i < y && j >= 0 && j < x)
                     {
                      if (board[i,j].isMine == true)
                        {
                          board[xx,yy].adjMines += 1;
                        }
                     }
                  }
                }
               }
            }

            public void attPrint()
            {
             for(int i = 0; i < x; i++)
             {
              for(int j = 0; j < y; j++)
              {
               Console.WriteLine(board[i,j].PrintData());
              }
             }
            }

            public void boardPrint()
            {

            }
     }
}