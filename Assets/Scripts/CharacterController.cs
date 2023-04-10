using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class CharacterController : MonoBehaviour
{
    public GameObject questionUiObject;
    public GameObject speedCode;
    public GameObject tip;
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI UIbook, UIfun;
    public int collectedBook, collectedfun;
    public static float countdownValue;
    public static bool tm = false;
    public GameObject loseUi;
    public GameObject halfLoseUi;
    public GameObject nextLevel;

    private bool finish;
    private bool halfFinish;

    void Start()
    {
        finish = false;
        halfFinish = false;
        UIbook.text = "0/4";
        UIfun.text = "0/4";
        countdownValue = 30f;
        Time.timeScale = 1.0f;
        countdownText.enabled = false;
        tm = false;
        nextLevel.SetActive(true);

    }
    void Update()
    {

        if (tm == true)
        {
            Timer();
        }
    }

    private void Timer()
    {
        if (countdownValue > 0f)
        {
            countdownValue -= 1f * Time.deltaTime;
            countdownText.text = Mathf.RoundToInt(countdownValue).ToString();

        }
        else
        {
            Time.timeScale = 0.0f;
            //losetext ayarlanacak.
            if (finish==true)
            {
                questionUiObject.SetActive(false);
                loseUi.SetActive(true);
                finish = false;
                Debug.Log("adfafgjahdsfg");
            }
            if (halfFinish==true)
            {
                questionUiObject.SetActive(false);
                halfLoseUi.SetActive(true);
                halfFinish = false;
                Debug.Log("adfafgjahdsfg");
            }
            
        }
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("halfFinish"))
        {
            speedCode.SetActive(true);   
            countdownText.enabled=true;
            halfFinish = true;
            tm = true;
            nextLevel.SetActive(false);
            col.collider.enabled = false;
        }
        if (col.gameObject.CompareTag("Finish"))
        {
            countdownText.enabled = true;
            finish = true;
            tm = true;

            if (collectedBook >= 4)
            {
                questionUiObject.SetActive(true);
            }
            else
            {
                questionUiObject.SetActive(true);
                tip.SetActive(false);
            }

        }

        if (col.gameObject.CompareTag("Book"))
        {

            col.gameObject.SetActive(false);
            collectedBook++;
            UIbook.text = collectedBook + "/4";

        }

        if (col.gameObject.CompareTag("MovieTicket"))
        {
            countdownValue = countdownValue - 2f;
            Debug.Log("geldim");
            col.gameObject.SetActive(false);
            collectedfun++;
            UIfun.text = collectedfun + "/4";

        }

    }


}
