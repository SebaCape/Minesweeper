using System;
using System.Collections.Generic;

namespace Minesweeper
{
     public class playerInteractions
     { 
      int gameOver = 0;
      
      //determines which cell of the board will be activated
      public void cellActivate(int x, int y, gameBoard g)
      {
       if(g.board[x,y].isActive != true && g.board[x,y].isFlagged != true)
       {
       g.board[x,y].isActive = true;

       if(g.board[x,y].isMine == false)
       g.cellsLeft--;

       cellCheck(x,y,g);
       adjActivate(x,y,g);

       if(g.cellsLeft == 0)
       gameOver = 2;
       }
       else
       Console.WriteLine("\ncell already active or flagged \n");
      }

     //checks whether specific cell is a mine or is flagged, if not, it will display the cells adjacent mines variable
     public void cellCheck(int x, int y, gameBoard g)
     {
      if(g.board[x,y].isMine == true && g.board[x,y].isActive == true)
      gameOver = 1;
     }

      //determines which cell of the board will be flagged
      public void cellFlag(int x, int y, gameBoard g)
      {
       if(g.board[x,y].isFlagged != true && g.board[x,y].isActive != true)
       {
       g.board[x,y].isFlagged = true;
       Console.WriteLine("\nFlagged");
       }

       else
       {
       g.board[x,y].isFlagged = false;
       Console.WriteLine("\nUnflagged");
       }
      }

      //determines what will be done with that board cell
      public void actionSelect(string input, int x, int y, gameBoard g)
      {
       Console.WriteLine("\nChoose the x coordinate (1-" + g.x + ")");
       x = Convert.ToInt32(Console.ReadLine()) - 1;
       Console.WriteLine("\nChoose the y coordinate (1-" + g.y + ")");
       y = Convert.ToInt32(Console.ReadLine()) - 1;

       Console.WriteLine("\nChoose which action you would like to perform. Flag: F, Activate: A");
       input = Console.ReadLine();
       switch (input)
       {
       case "F": case "f":
       cellFlag(y,x,g);
       break;

       case "A": case "a":
       cellActivate(y,x,g);
       break;

       default:
       actionSelect("",0,0,g);
       break;
       }
      }

      //determines whether the game is over or not, additionally determines if player has won or lost 
      public int gameStateCheck()
      {
        return gameOver;
      }
          
      //activates adjacent 0s, recursion
     public void adjActivate(int xx, int yy, gameBoard g)
            {
             if (!g.board[xx, yy].isMine)
             {
              for (int i = yy - 1; i <= yy + 1; i++)
              {
               for (int j = xx - 1; j <= xx + 1; j++)
               {
                if (i >= 0 && i < g.y && j >= 0 && j < g.x)
                {
                 if (g.board[xx,yy].adjMines == 0 && g.board[j,i].isActive == false)
                 {
                  cellActivate(j,i,g);
                 }
                }
               }
              }
              }
            }
     }
}
