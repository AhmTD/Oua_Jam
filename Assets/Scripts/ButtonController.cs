using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject questionUi;
    public GameObject winUi;
    public GameObject loseUi;
    private Scene _scene;
    public GameObject halfWinUi;
    public GameObject halfLoseUi;
    public TextMeshProUGUI countdownText; 
    private void Awake()
    {
        _scene = SceneManager.GetActiveScene();
    }

    void Start()
    {

    }
    void Update()
    {
    }
    public void TrueButtonClick()
    {
        questionUi.gameObject.SetActive(false);
        winUi.gameObject.SetActive(true);
        CharacterController.tm = false;
        Debug.Log("komut çalıoşıyor");
        

    }

    public void FalseButtonClick()
    {
        questionUi.gameObject.SetActive(false);
        loseUi.gameObject.SetActive(true);
        CharacterController.tm = false;
       
    }

    public void RestartButtonClick()
    {
        SceneManager.LoadScene(_scene.buildIndex);
        halfLoseUi.SetActive(false);
       
    }
    public void NextLevelButtonClick()
    {
        SceneManager.LoadScene(_scene.buildIndex + 1);
        
    }

    public void ContinueButton()
    {
        halfWinUi.SetActive(false);

        PlayerController.isMove = true;
    }
}
