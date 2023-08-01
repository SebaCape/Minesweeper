using System;
using System.Collections.Generic;

namespace Minesweeper
{
     public class gameManager
     { 
          public static void Main()
          {
           //initialization of objects for unique methods
           gameBoard g = new gameBoard();
           playerInteractions p = new playerInteractions();

           //general board set up
           int gState = 0;
           g.gameModeSelect();
           g.bGenerate();
           g.placeMines();
           
           //loop to set adjacent mine count for each cell individually
           for(int i = 0; i < g.x; i++)
           {
            for(int j = 0; j < g.y; j++)
            {
             g.howManyAdj(i,j);
            }
           }
           
           //Gameplay loop
           gloop:
           p.actionSelect(null,0,0,g);
           

           //end of turn update
           g.sBoardUpdate();
           g.boardPrint();
           gState = p.gameStateCheck();
           
           switch(gState)
           {
            case 1:
            Console.WriteLine("\n You lose");
            break;

            case 2:
            Console.WriteLine("\n You win");
            break;
            
            default:
            break;
           }

           goto gloop;

           gOver: ;
          }
     }
}