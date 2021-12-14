using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreDetection : MonoBehaviour
{
    [SerializeField]
    private UnityEvent timer;
    public int score =0;
    [SerializeField]
    public TextMeshProUGUI scoreText;
    [SerializeField]
    public Animator enemyShip;
    [SerializeField] AudioSource enemyBoom;
    public bool gameHasEnded = false;

    private void Start()                                              // score text to UI screen
    {
        scoreText.text = "score:" + score; 
    }

    private void OnTriggerEnter(Collider other)                      //on trigger enter plays sound, adds point to score and destroys enemy if score is >= 3.
                                                                     //Invoke is used to activate the timer screen on first collision. 
    {
        enemyBoom.Play(); 
        AddPoint();
        DestroyEnemy();
        if (other.CompareTag("ScoreDetection"))
        {
            timer.Invoke();
        }
    }    
    public void AddPoint()                                           //adds on point per collision.
    {
        score += 1;
        scoreText.text = score.ToString() + "points";
    }
    public void DestroyEnemy()                                         //on three collisions enemy ship will sink down with animation and game will restart after 15 seconds, (so the animation and sound can play, may become shorter)
    {
        if (score >= 3)
        {
            enemyShip.Play("enemy enter", 0, 0.0f);
            Invoke("EndGame", 15f);
        }
    }
    public void EndGame()                                               //calls scene manager to restart scene
    {
        gameHasEnded = true;
        SceneManager.LoadScene("The Nautilus Ark");
    }
}
