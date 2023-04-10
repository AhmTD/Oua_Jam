using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvas.SetActive(false);
        }
    }
    public GameObject canvas;
    public void StartButtonClick()
    {
        SceneManager.LoadScene(1);

    }
    public void GuideButtonClick()
    {
       canvas.SetActive(true);


    }
    public void ReturnStartMenuButtonClick()
    {
        SceneManager.LoadScene(0);

    }
    public void Quit()
    {
        Application.Quit();
    }



}
