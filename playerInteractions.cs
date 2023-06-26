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
       if(g.board[x,y].isActive != true)
       g.board[x,y].isActive = true;
       else
       Console.WriteLine("cell already active");
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
       if(g.board[x,y].isFlagged != true)
       g.board[x,y].isFlagged = true;
       else
       g.board[x,y].isFlagged = false;
      }

      //determines what will be done with that board cell
      public void actionSelect(string input, int x, int y, gameBoard g)
      {
       Console.WriteLine("Choose the x coordinate");
       x = Convert.ToInt32(Console.ReadLine());
       Console.WriteLine("Choose the y coordinate");
       y = Convert.ToInt32(Console.ReadLine());

       Console.WriteLine("Choose which action you would like to perform. Flag: F, Activate: A");
       input = Console.ReadLine();
       switch (input)
       {
       case "F":
       cellFlag(x,y,g);
       break;

       case "A":
       cellActivate(x,y,g);
       break;

       default:
       actionSelect("",0,0,g);
       break;
       }
      }

      //determines whether the game is over or not, additionally determines if player has won or lost 
      public void gameStateCheck()
      {
       switch(gameOver)
       {
        case 1:
        Console.WriteLine("Game Over, you lose");
        break;

        case 2:
        Console.WriteLine("Game Over, you win");
        break;

        default:
        break;
       }
      }
     }
}