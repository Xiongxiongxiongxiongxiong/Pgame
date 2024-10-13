using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public Text timeScore;
    public GameObject _ganmeOverUI;

    private void Awake()
    {
        //单例模式
        if (instance !=null)
        {
            Destroy(gameObject);
        }

        instance = this;
    }


    

    // Update is called once per frame
    void Update()
    {
        timeScore.text = Time.timeSinceLevelLoad.ToString("00");
    }




    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }



    public static void GameOver(bool dead)
    {
        //暂停游戏
        if (dead)
        {
            instance._ganmeOverUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
