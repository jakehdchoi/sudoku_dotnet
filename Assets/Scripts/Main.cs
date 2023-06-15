using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public Button EasyButton;
    public Button MediumButton;
    public Button HardButton;

    public void OnClick_Easy()
    {
        SceneManager.LoadScene("GameScene");
        GameSettings.selectedLevelNumber = 1;
    }
    public void OnClick_Medium()
    {
        SceneManager.LoadScene("GameScene");
        GameSettings.selectedLevelNumber = 2;
    }
    public void OnClick_Hard()
    {
        SceneManager.LoadScene("GameScene");
        GameSettings.selectedLevelNumber = 3;
    }

}
