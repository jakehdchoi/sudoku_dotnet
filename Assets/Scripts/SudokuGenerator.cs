using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SudokuGenerator
{
    public static SudokuObject CreateSudokuObject()
    {
        _finalSudokuObject = null;
        SudokuObject sudokuObject = new SudokuObject();
        CreateRandomGroups(sudokuObject);
        if (TryToSolve(sudokuObject))
        {
            sudokuObject = _finalSudokuObject;
        }
        else
        {
            throw new System.Exception("Something went wrong");
        }
        return RemoveSomeRandomNumbers(sudokuObject);
    }

    private static SudokuObject RemoveSomeRandomNumbers(SudokuObject sudokuObject)
    {
        SudokuObject newSudokuObject = new SudokuObject();
        newSudokuObject.Values = (int[,])sudokuObject.Values.Clone();
        List<int> values = GetValues();
        bool isFinished = false;
        while (!isFinished)
        {
            int index = Random.Range(0, values.Count);
            int searchedIndex = values[index];
            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    if (i * j == searchedIndex)
                    {
                        values.RemoveAt(index);
                        SudokuObject nextSudokuObject = new SudokuObject();
                        nextSudokuObject.Values = (int[,])newSudokuObject.Values.Clone();
                        nextSudokuObject.Values[i - 1, j - 1] = 0;
                        if (TryToSolve(nextSudokuObject, true))
                        {
                            newSudokuObject = nextSudokuObject;
                        }
                    }
                }
            }
            if (values.Count < 30)
            {
                isFinished = true;
            }
        }
        return newSudokuObject;
    }

    private static List<int> GetValues()
    {
        List<int> values = new List<int>();
        for (int i = 1; i < 10; i++)
        {
            for (int j = 1; j < 10; j++)
            {
                values.Add(i * j);
            }
        }
        return values;
    }

    private static SudokuObject _finalSudokuObject;

    private static bool TryToSolve(SudokuObject sudokuObject, bool OnlyOne = false)
    {
        // find empty fields which can be filled
        if (HasEmptyFieldsToFill(sudokuObject, out int row, out int col, OnlyOne))
        {
            List<int> possibleValues = GetPossibleValues(sudokuObject, row, col);
            foreach (var possibleValue in possibleValues)
            {
                SudokuObject nextSudokuObject = new SudokuObject();
                nextSudokuObject.Values = (int[,])sudokuObject.Values.Clone();
                nextSudokuObject.Values[row, col] = possibleValue;
                if (TryToSolve(nextSudokuObject, OnlyOne))
                {
                    return true;
                }
            }
        }

        // has sudokuobject empty fields
        if (HasEmptyFields(sudokuObject))
        {
            return false;
        }
        _finalSudokuObject = sudokuObject;
        return true;
        // finish
    }

    private static bool HasEmptyFields(SudokuObject sudokuObject)
    {
        for (int iRow = 0; iRow < 9; iRow++)
        {
            for (int jCol = 0; jCol < 9; jCol++)
            {
                if (sudokuObject.Values[iRow, jCol] == 0)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private static List<int> GetPossibleValues(SudokuObject sudokuObject, int row, int col)
    {
        List<int> possibleValues = new List<int>();
        for (int value = 1; value < 10; value++)
        {
            if (sudokuObject.IsPossibleNumberInPosition(value, row, col))
            {
                possibleValues.Add(value);
            }
        }
        return possibleValues;
    }

    private static bool HasEmptyFieldsToFill(SudokuObject sudokuObject, out int row, out int col, bool OnlyOne = false)
    {
        row = 0;
        col = 0;
        int amountOfPossibleValues = 10;
        for (int iRow = 0; iRow < 9; iRow++)
        {
            for (int jCol = 0; jCol < 9; jCol++)
            {
                if (sudokuObject.Values[iRow, jCol] == 0)
                {
                    int _currentAmount = GetPossibleAmountOfValues(sudokuObject, iRow, jCol);
                    if (_currentAmount != 0)
                    {
                        if (_currentAmount < amountOfPossibleValues)
                        {
                            amountOfPossibleValues = _currentAmount;
                            row = iRow;
                            col = jCol;
                        }
                    }
                }
            }
        }
        if (OnlyOne)
        {
            if (amountOfPossibleValues == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        if (amountOfPossibleValues == 10)
        {
            return false;
        }
        return true;
    }

    private static int GetPossibleAmountOfValues(SudokuObject sudokuObject, int row, int col)
    {
        int amount = 0;
        for (int value = 1; value < 10; value++)
        {
            if (sudokuObject.IsPossibleNumberInPosition(value, row, col))
            {
                amount++;
            }
        }
        return amount;
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
