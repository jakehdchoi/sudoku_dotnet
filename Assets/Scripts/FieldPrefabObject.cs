using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldPrefabObject
{
    private int _row;
    private int _col;
    private GameObject _instance;

    public FieldPrefabObject(GameObject instance, int row, int col)
    {
        _instance = instance;
        Row = row;
        Col = col;
    }

    public int Row { get => _row; set => _row = value; }
    public int Col { get => _col; set => _col = value; }

    public void SetHoverMode()
    {
        _instance.GetComponent<Image>().color = new Color(0.70f, 0.99f, 0.99f);
    }

    public void UnsetHoverMode()
    {
        _instance.GetComponent<Image>().color = new Color(1f, 1f, 1f);

    }
}
