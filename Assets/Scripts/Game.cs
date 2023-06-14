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

                FieldPrefabObject _fieldPrefabObject = new FieldPrefabObject(instance, row, col);
                _fieldPrefabObjectDic.Add(new Tuple<int, int>(row, col), _fieldPrefabObject);

                instance.GetComponent<Button>().onClick.AddListener(
                    () => OnClick_FieldPrefabs(_fieldPrefabObject)
                    );
            }
        }
    }

    private FieldPrefabObject _currentHoveredFieldPrefab;
    private void OnClick_FieldPrefabs(FieldPrefabObject _fieldPrefabObject)
    {
        Debug.Log($"Clicked Prefab Row({_fieldPrefabObject.Row}) Col({_fieldPrefabObject.Col})");
        if (_currentHoveredFieldPrefab != null)
        {
            _currentHoveredFieldPrefab.UnsetHoverMode();
        }
        _currentHoveredFieldPrefab = _fieldPrefabObject;
        _fieldPrefabObject.SetHoverMode();
    }

}
