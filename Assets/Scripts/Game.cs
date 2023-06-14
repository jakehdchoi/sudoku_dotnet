using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject SudokuFieldPanel;
    public GameObject FieldPrefab;

    void Start()
    {
        for (int i = 0; i < 81; i++)
        {
            GameObject.Instantiate(FieldPrefab, SudokuFieldPanel.transform);
        }
    }

}
