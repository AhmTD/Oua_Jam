using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputCheck : MonoBehaviour
{
    public InputField inputField;
    public GameObject halfQuestion;
    public GameObject halfWinUi;
    public GameObject halfLoseUi;
    public TextMeshProUGUI countdownText;
    private string answer2 ="private Scene_scene; _scene = SceneManager.GetActiveScene();";
    private string answer3 ="public void DebugFunction(){Debug.Log(\"Debug Fonksiyonu Aktif\")}";
    private string answer1 ="Debug.Log(\"Bu mesaj konsolda görünür\");";
    private string answer4 ="abc";
    
    private bool isWin;
    
    // Start is called before the first frame update
    void Start()
    {
        isWin = false;
    }
    public void CheckAnswer()
    {
       
        if (inputField.text==answer1 || inputField.text==answer2 || inputField.text==answer3||inputField.text==answer4)
        {
            isWin = true;
            halfQuestion.SetActive(false);
            halfWinUi.SetActive(true);
            Debug.Log("cevap doğru");
            CharacterController.countdownValue=20f;
            CharacterController.tm = false;
            countdownText.enabled = false;
            //buttonController.winUi.SetActive(true);
            //GameObject winUi = buttonController.winUi;
            
        }
        else
        {
            halfQuestion.SetActive(false);
            halfLoseUi.SetActive(true);
            Debug.Log("soru yanlış hocam");
            Time.timeScale = 0f;
            countdownText.enabled = false;

            //GameObject loseUi = buttonController.loseUi; 
            //buttonController.loseUi.SetActive(false);

        }
    }
}
