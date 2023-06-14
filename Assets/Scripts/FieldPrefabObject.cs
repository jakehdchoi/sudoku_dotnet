using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldPrefabObject
{
    private int _row;
    private int _col;
    private GameObject _instance;

    public FieldPrefabObject(GameObject instance, int row, int col)
    {
        _instance = instance;
        _row = row;
        _col = col;
    }
}
