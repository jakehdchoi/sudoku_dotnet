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
    public GameObject ControlPanel;
    public GameObject ControlPrefab;
    public Button InformationButton;


    void Start()
    {
        CreateFieldPrefabs();
        CreateControlPrefabs();
    }

    private bool isInformationButtonActive = false;
    public void OnClick_InformationButton()
    {
        Debug.Log($"OnClick_InformationButton: ");
        if (isInformationButtonActive)
        {
            isInformationButtonActive = false;
            InformationButton.GetComponent<Image>().color = new Color(1f, 1f, 1f);
        }
        else
        {
            isInformationButtonActive = true;
            InformationButton.GetComponent<Image>().color = new Color(0.70f, 0.99f, 0.99f);
        }
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

                FieldPrefabObject fieldPrefabObject = new FieldPrefabObject(instance, row, col);
                _fieldPrefabObjectDic.Add(new Tuple<int, int>(row, col), fieldPrefabObject);

                instance.GetComponent<Button>().onClick.AddListener(
                    () => OnClick_FieldPrefabs(fieldPrefabObject)
                    );
            }
        }
    }

    private void CreateControlPrefabs()
    {
        for (int i = 1; i < 10; i++)
        {
            GameObject instance = GameObject.Instantiate(ControlPrefab, ControlPanel.transform);
            instance.GetComponentInChildren<Text>().text = i.ToString();

            ControlPrefabObject controlPrefabObject = new ControlPrefabObject();
            controlPrefabObject.Number = i;

            instance.GetComponent<Button>().onClick.AddListener(
                () => OnClick_ControlPrefabs(controlPrefabObject)
                );

        }
    }

    private void OnClick_ControlPrefabs(ControlPrefabObject controlPrefabObject)
    {
        Debug.Log($"OnClick_ControlPrefabs: {controlPrefabObject.Number}");
        if (_currentHoveredFieldPrefab != null)
        {
            if (isInformationButtonActive)
            {
                _currentHoveredFieldPrefab.SetSmallNumber(controlPrefabObject.Number);
            }
            else
            {
                _currentHoveredFieldPrefab.SetNumber(controlPrefabObject.Number);
            }
        }
    }


    private FieldPrefabObject _currentHoveredFieldPrefab;
    private void OnClick_FieldPrefabs(FieldPrefabObject fieldPrefabObject)
    {
        Debug.Log($"OnClick_FieldPrefabs Row({fieldPrefabObject.Row}) Col({fieldPrefabObject.Col})");
        if (_currentHoveredFieldPrefab != null)
        {
            _currentHoveredFieldPrefab.UnsetHoverMode();
        }
        _currentHoveredFieldPrefab = fieldPrefabObject;
        fieldPrefabObject.SetHoverMode();
    }

}
