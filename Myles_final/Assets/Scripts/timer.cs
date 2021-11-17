using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //added to use UI options and put text canvas on screen.
using TMPro;
public class timer : MonoBehaviour
{
    public GameObject textDisplay; 
    public int timeValue = 60; 
    public bool takingAway1 = false; 
    // Update is called once per frame

    private void Start()
    {
        textDisplay.GetComponent<Text>().text = "time:" + timeValue; //dispalays timeValue as string at start 
    }
    void Update()
    {
        if (takingAway1 == false && timeValue > 0)
        {
            StartCoroutine(timerDown()); //used with enumerator to enable constant options. 
        }
        IEnumerator timerDown() 
        {
            takingAway1 = true;
            yield return new WaitForSeconds(1); //like deltatime. 
            timeValue -= 1;
            textDisplay.GetComponent<Text>().text = "time0:00" + timeValue; //displays timeValue reduction as it updates. Also displays in seconds instead of 00:00. this is why the string is empty. 
            takingAway1 = false; 
        }

    }

}
