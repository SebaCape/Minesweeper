using System;
using System.Collections.Generic;

namespace Minesweeper
{
     public class gameManager
     { 
          public static void Main()
          {
           gameBoard g = new gameBoard();

           //general board set up
           g.gameModeSelect();
           g.bGenerate();
           g.placeMines();
           g.sBoardUpdate();
           
           //loop to set adjacent mine count for each cell individually
           for(int i = 0; i < g.x; i++)
           {
            for(int j = 0; i < g.y; i++)
            {
             g.howManyAdj(i,j);
            }
           }

           g.attPrint();
          }
     }
}