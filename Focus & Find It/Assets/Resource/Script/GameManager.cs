using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //public int m_totalItem;
    public GameObject[] m_goalItem;
    public Text[] m_textItem;
    public GameObject winPanel, pausePanel;
    
    
    int currentItemTotal, sceneIndex;
    public int levelPassed;
    private bool isEnd,isPaused=false;

    private void Start()
    {

        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelPassed = PlayerPrefs.GetInt("levelpassed");

        isEnd = false;
        foreach(GameObject goalItem in m_goalItem)
        {
            Data.m_totalItem += 1;
        }
        currentItemTotal = Data.m_totalItem;
        Debug.Log("Total item that have to be clicked: " + Data.m_totalItem);
    }

    private void Update()
    {
      
        if(Data.m_totalItem != currentItemTotal && isEnd==false)
        {
            foreach (GameObject goalItem in m_goalItem)
            {
                if (!goalItem.activeSelf)
                {
                    foreach(Text textItem in m_textItem)
                    {
                        if(goalItem.name == textItem.text)
                        {
                            textItem.gameObject.GetComponent<Text>().color =Color.red;
                            break;
                        }
                    }
                }
            }
        }
        if (Data.m_totalItem == 0)
        {
            WinCondition();
        }
        if (Data.m_totalItem!=0) {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused == false)
                {
                    GameObject.Find("Main Camera").GetComponent<AudioSource>().Pause();
                    pausePanel.SetActive(true);
                    isPaused = true;
                }
                else
                {
                    GameObject.Find("Main Camera").GetComponent<AudioSource>().UnPause();
                    pausePanel.SetActive(false);
                    isPaused = false;
                }
            }
        }
        
    }

    public void playGame()
    {    
        GameObject.Find("Main Camera").GetComponent<AudioSource>().enabled = true;
    }

    

    private void WinCondition()
    {
        
        Debug.Log("LP "+levelPassed);
        Debug.Log("SC " + sceneIndex);

        if (levelPassed < sceneIndex)
        {
            PlayerPrefs.SetInt("levelpassed", sceneIndex);
        }
        GameObject.Find("Main Camera").GetComponent<AudioSource>().enabled = false;

        isEnd = true;
       
        winPanel.SetActive(true);
    }

}
