using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SudokuObject
{
    public int[,] Values = new int[9, 9];

    public void GetGroupIndex(int group, out int startRow, out int startCol)
    {
        startRow = 0;
        startCol = 0;
        switch (group)
        {
            case 1:
                startRow = 0;
                startCol = 0;
                break;
            case 2:
                startRow = 0;
                startCol = 3;
                break;
            case 3:
                startRow = 0;
                startCol = 6;
                break;
            case 4:
                startRow = 3;
                startCol = 0;
                break;
            case 5:
                startRow = 3;
                startCol = 3;
                break;
            case 6:
                startRow = 3;
                startCol = 6;
                break;
            case 7:
                startRow = 6;
                startCol = 0;
                break;
            case 8:
                startRow = 6;
                startCol = 3;
                break;
            case 9:
                startRow = 6;
                startCol = 6;
                break;

        }

    }
}
