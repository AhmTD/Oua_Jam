using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObject : MonoBehaviour
{

    public float scaleFactor = 0.1f; 
    public float minScale = 0.5f; 
    public float maxScale = 2f; 
    private bool isIncreasing = true; 

    void Update()
    {
       
        if (isIncreasing)
        {
            transform.localScale += new Vector3(scaleFactor, scaleFactor, 0) * Time.deltaTime;
        }
        else
        {
            transform.localScale -= new Vector3(scaleFactor, scaleFactor, 0) * Time.deltaTime;
        }

       
        if (isIncreasing && transform.localScale.x >= maxScale)
        {
            isIncreasing = false;
        }
       
       
        else if (!isIncreasing && transform.localScale.x <= minScale)
        {
            isIncreasing = true;
        }
    }





}
