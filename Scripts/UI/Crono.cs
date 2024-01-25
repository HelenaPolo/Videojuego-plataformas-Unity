using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Crono : MonoBehaviour
{

    private string textCrono;


    void Start()
    {
        InvokeRepeating("CronoGame", 0.0f, 1.0f);
    }


    public void CronoGame()
    {

        General.sec = General.sec+1;

        if (General.sec == 60)
        {

            General.min = General.min + 1;
            General.sec = 0;
        }

        textCrono = ""; 

        if (General.min < 10)
        {
            textCrono = textCrono + "0";
        }
        textCrono = textCrono + General.min +":";

        if (General.sec < 10)
        {
            textCrono = textCrono + "0";
        }
        textCrono = textCrono + General.sec;


        this.gameObject.GetComponent<Text>().text = textCrono;

    }
       
}
