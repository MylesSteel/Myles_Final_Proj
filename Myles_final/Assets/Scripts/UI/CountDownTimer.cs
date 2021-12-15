using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;                                      //access to scene options. such as restart.

public class CountDownTimer : MonoBehaviour
{
    [SerializeField] float startTime = 0f;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] AudioSource targetLost;                             //audio source for target lost audio played with warp animation at end of timer.
    [SerializeField] Animator warp;                                     //warp animation.
    float timer;
    public bool gameHasEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());                                          //used to prevent update function requirement
    }

    private IEnumerator Timer()
    {
        timer = startTime;

        do
        {
            timer -= Time.deltaTime;                                      //populated fields start time will be -1 by deltatime. call format text to display clean timer.

            FormatText();
            yield return null;
        }
        while (timer > 0);
        if (timer <=0)                                                      //plays audio source and restart game after 15 seconds.
        {
            targetLost.Play();
            Invoke("EndGame", 15f);
            warp.Play("warp");
        }
    }
    private void FormatText()
    {
        int minutes = (int)(timer / 60 % 60);
        int seconds = (int)(timer % 60);

        timerText.text = " ";
        if (minutes > 0) { timerText.text += minutes + "m ";}
        if (seconds > 0) { timerText.text += seconds + "s ";}
    }
    public void EndGame()                                               //calls scene manager to restart scene
    {
        gameHasEnded = true;
        //Debug.Log("Game Over");
        SceneManager.LoadScene("The Nautilus Ark");
    }
}

