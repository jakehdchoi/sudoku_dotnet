using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SudokuGenerator
{
    public static SudokuObject CreateSudokuObject()
    {
        SudokuObject sudokuObject = new SudokuObject();
        CreateRandomGroups(sudokuObject);
        return sudokuObject;
    }

    public static void CreateRandomGroups(SudokuObject sudokuObject)
    {
        List<int> values = new List<int>() { 0, 1, 2 };
        int index = Random.Range(0, values.Count);
        InsertRandomGroup(sudokuObject, 1 + values[index]);
        values.RemoveAt(index);

        index = Random.Range(0, values.Count);
        InsertRandomGroup(sudokuObject, 4 + values[index]);
        values.RemoveAt(index);

        index = Random.Range(0, values.Count);
        InsertRandomGroup(sudokuObject, 7 + values[index]);
    }

    public static void InsertRandomGroup(SudokuObject sudokuObject, int group)
    {
        sudokuObject.GetGroupIndex(group, out int startRow, out int startCol);
        List<int> values = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        for (int row = startRow; row < startRow + 3; row++)
        {
            for (int col = startCol; col < startCol + 3; col++)
            {
                int index = Random.Range(0, values.Count);
                sudokuObject.Values[row, col] = values[index];
                values.RemoveAt(index);
            }
        }
    }

}
