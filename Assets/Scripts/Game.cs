using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Game : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject SudokuFieldPanel;
    public GameObject FieldPrefab;

    void Start()
    {
        CreateFieldPrefabs();
    }

    private Dictionary<Tuple<int, int>, FieldPrefabObject> _fieldPrefabObjectDic =
        new Dictionary<Tuple<int, int>, FieldPrefabObject>();

    private void CreateFieldPrefabs()
    {
        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                GameObject instance = GameObject.Instantiate(FieldPrefab, SudokuFieldPanel.transform);
                // instance.GetComponentInChildren<Text>().text = i.ToString();
                FieldPrefabObject _fieldPrefabObject = new FieldPrefabObject(instance, row, col);
                _fieldPrefabObjectDic.Add(new Tuple<int, int>(row, col), _fieldPrefabObject);
            }
        }
    }

}
