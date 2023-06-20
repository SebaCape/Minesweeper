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

      //determines which cell of the board will be flagged
      public void cellFlag()
      {

      }

      //determines what will be done with that board cell
      public void actionSelect()
      {
       
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