using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDownTimer : MonoBehaviour
{
    [SerializeField] float startTime = 0f;
    [SerializeField] TextMeshProUGUI timerText;
    float timer;
    public bool gameHasEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        timer = startTime;

        do
        {
            timer -= Time.deltaTime;

            FormatText();
            yield return null;
        }
        while (timer > 0);
        if (timer <=0)
        {
            Invoke("EndGame", 15f);
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

