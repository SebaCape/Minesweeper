﻿using System;
using System.Collections.Generic;

namespace Minesweeper
{
     public class gameBoard
     { 
      
            //variable declaration
            public Cell[,] board; //data in 2d array that is dealt with
            string [,] sBoard; //data that is shown to user
            string gameMode; //board size
            int mineCount; //how many mines placed depending on board size
            public int x;
            public int y;
            public int cellsLeft;
            
            //random integers for later mine placement
            Random rx = new Random();
            int nx;
            Random ry = new Random();
            int ny;
            int currentMines = 0;

            public void gameModeSelect() //self explanatory
            {
             gameSelect:
             Console.ForegroundColor = ConsoleColor.Green;
             Console.WriteLine("1 for small board, 2 for medium board, 3 for large board", Console.ForegroundColor);
             gameMode = Console.ReadLine();
             Console.ForegroundColor = ConsoleColor.Gray;

             switch(gameMode)
             {
               case "1":
               board = new Cell[8,8];
               sBoard = new string[8,8];
               x = 8;
               y = 8;
               mineCount = 8;
               cellsLeft = (x*y) - mineCount;
               break;

               case "2":
               board = new Cell[12,12];
               sBoard = new string[12,12];
               x = 12;
               y = 12;
               mineCount = 18;
               cellsLeft = (x*y) - mineCount;
               break;

               case "3":
               board = new Cell[20,20];
               sBoard = new string[20,20];
               x = 20;
               y = 20;
               mineCount = 50;
               cellsLeft = (x*y) - mineCount;
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
             if(!board[ny,nx].isMine)
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
             if (!board[xx, yy].isMine)
             {
              for (int i = yy - 1; i <= yy + 1; i++)
              {
               for (int j = xx - 1; j <= xx + 1; j++)
               {
                if (i >= 0 && i < y && j >= 0 && j < x)
                {
                 if (board[j, i].isMine)
                 {
                  board[xx, yy].adjMines++;
                 }
                }
               }
              }
              }
            }

            //shows each cells individual attributes
            public void attPrint()
            {
             for(int i = 0; i < x; i++)
             {
              for(int j = 0; j < y; j++)
              {
               Console.Write(board[i,j].PrintData());
              }
             }
            }

            //updates string board to be accurate to cells current attributes
            public void sBoardUpdate()
            {
             for(int i = 0; i < x; i++)
              {
               for(int j = 0; j < y; j++)
               {
                if(board[i,j].isActive == false)
                sBoard[i,j] = ("I");
                else if(board[i,j].isActive == true)
                sBoard[i,j] = board[i,j].adjMines.ToString();
                if(board[i,j].isFlagged == true)
                sBoard[i,j] = "F";
               }
              }
            }

            //prints board of cells in way that shows whether they are active or not
            public void boardPrint()
            {
             Console.WriteLine("\n");
             for(int i = 0; i < x; i++)
              {
               for(int j = 0; j < y; j++)
                {
                 if(board[i,j].isActive == true && board[i,j].isMine == true) //setting of color of different cells in game
                 Console.ForegroundColor = ConsoleColor.DarkRed;
                 else if(board[i,j].isActive == true)
                 Console.ForegroundColor = ConsoleColor.Yellow;
                 else if(board[i,j].isFlagged == true)
                 Console.ForegroundColor = ConsoleColor.Magenta;
                 else
                 Console.ForegroundColor = ConsoleColor.Gray;

                 Console.Write(sBoard[i,j]);
                } 
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Gray;
              }
            }
     }
}