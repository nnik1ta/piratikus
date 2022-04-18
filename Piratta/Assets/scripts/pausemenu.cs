using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class pausemenu : MonoBehaviour
{
    public bool pausegame;
    public GameObject pausemenugame; 
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausegame)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pausemenugame.SetActive(false);
        Time.timeScale = 1f;
        pausegame = false;
    }
    public void Pause()
    {
        pausemenugame.SetActive(true);
        Time.timeScale = 0f;
        pausegame = true;
    }
    public void loadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Mainmenu");
    }
}

