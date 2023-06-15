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
               mineCount = 8;
               break;

               case "2":
               board = new Cell[12,12];
               sBoard = new string[12,12];
               x = 12;
               y = 12;
               mineCount = 18;
               break;

               case "3":
               board = new Cell[20,20];
               sBoard = new string[20,20];
               x = 20;
               y = 20;
               mineCount = 50;
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
                sBoard[i,j] = "I";
                else if(board[i,j].isFlagged == true)
                sBoard[i,j] = "F";
                else if(board[i,j].isActive == true)*/
                sBoard[i,j] = board[i,j].adjMines.ToString();
               }
              }
            }

            //prints board of cells in way that shows whether they are active or not
            public void boardPrint()
            {
             for(int i = 0; i < x; i++)
              {
               for(int j = 0; j < y; j++)
                {
                 Console.Write(sBoard[i,j]);
                } 
                Console.WriteLine();
              }
            }
     }
}