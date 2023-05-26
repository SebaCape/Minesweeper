using System;
using System.Collections.Generic;

namespace Minesweeper
{
     public class Cell
     { 
      //cell attribute variable declaration (is it a mine, is it flagged, has it been activated, how many mines are next to it)
      public bool isMine;
      public bool isActive;
      public bool isFlagged;
      public int adjMines;
      
      //overloaded Cell constructor
      public Cell(bool iM, bool iF, bool iA, int aM)
      {
       isMine = iM;
       isFlagged = iF;
       isActive = iA;
       adjMines = aM;
      }
      //default Cell constructor
      public Cell()
      {
       isMine = false;
       isActive = false;
       isFlagged = false;
       adjMines = 0;
      }

      //attribute returning methods
      public bool isAMine()
      {
        return isMine;
      }

      public bool isAFlagged()
      {
        return isFlagged;
      }

      public bool isActivated()
      {
        return isActive;
      }

      public int adjacentMines()
      {
        return adjMines;
      }
      
      //Data print method
      public string PrintData()
      {
        return "Is Mine: " + isMine + " Is Flagged: " + isFlagged + " Adjacent Mines: " + adjMines;
      }
     }
}