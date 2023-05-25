using System;
using System.Collections.Generic;

namespace Minesweeper
{
     public class Cell
     { 
      //cell attribute variable declaration (is it a mine, is it flagged, has it been activated, how many mines are next to it)
      private bool isMine;
      private bool isActive;
      private bool isFlagged;
      private int adjMines;
      
      //Cell object constructor
      public Cell(bool iM, bool iF, bool iA, int aM)
      {
       isMine = iM;
       isFlagged = iF;
       isActive = iA;
       adjMines = aM;
      }
      
      public string PrintData()
      {
        return "Is Mine: " + isMine + " Is Flagged: " + isFlagged + " Adjacent Mines: " + adjMines;
      }
     }
}