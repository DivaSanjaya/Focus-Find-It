using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button lv2btn, lv3btn;
    public int levelPassed;
    // Start is called before the first frame update
    void Update()
    {
        
        levelPassed = PlayerPrefs.GetInt("levelpassed");
        lv2btn.interactable = false;
        lv3btn.interactable = false;

        switch (levelPassed)
        {
            case 1:
                lv2btn.interactable = true;
                break;
            case 2:
                lv2btn.interactable = true;
                lv3btn.interactable = true;
                break;
            case 3:
                lv2btn.interactable = true;
                lv3btn.interactable = true;
                break;
        }
    }

    public void ResetLevel()
    {
        lv2btn.interactable = false;
        lv3btn.interactable = false;
        PlayerPrefs.DeleteAll();
    }
}
