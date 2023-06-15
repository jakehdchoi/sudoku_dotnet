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

    public bool isChangeable = true;

    public bool TryGetTextByName(string name, out Text text)
    {
        // name은 prefab에서 사용하는 text object의 이름(파일명?)이다
        text = null;
        Text[] texts = _instance.GetComponentsInChildren<Text>();
        foreach (var currentText in texts)
        {
            if (currentText.name.Equals(name))
            {
                text = currentText;
                return true;
            }
        }
        return false;
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

    public void SetNumber(int number)
    {
        // _instance.GetComponentInChildren<Text>().text = number.ToString();
        if (TryGetTextByName("Value", out Text text))
        {
            text.text = number.ToString();
            for (int i = 1; i < 10; i++)
            {
                if (TryGetTextByName($"Number_{i}", out Text textNumber))
                {
                    textNumber.text = "";
                }

            }
        }
    }

    public void SetSmallNumber(int number)
    {
        if (TryGetTextByName($"Number_{number}", out Text text))
        {
            text.text = number.ToString();
            if (TryGetTextByName("Value", out Text textValue))
            {
                textValue.text = "";
            }
        }
    }
}
