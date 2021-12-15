using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreDetection : MonoBehaviour                              //timer is triggered on collision. Score triggers events in DestroyEnemy function.
{
    [SerializeField]
    private UnityEvent timer;
    public int score =0;
    [SerializeField]
    public TextMeshProUGUI scoreText;
    [SerializeField]
    public Animator enemyShip;
    [SerializeField] AudioSource enemyBoom;                            //audio source for collison
    public bool gameHasEnded = false;
    [SerializeField]
    ParticleSystem fire;                                               //particle system for sinking aniomation, triggered by score.
    [SerializeField]
    AudioSource enemySinking;                                          //audio source for sinking animation
    [SerializeField]
    AudioSource targetDestroyed;

    private void Start()                                              // score text to UI screen
    {
        gameHasEnded = false;
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
    public void DestroyEnemy()                                         //on three collisions enemy ship will sink down with animation, play audio sources, and game will restart after 15 seconds, (so the animation and sound can play, may become shorter)
    {
        if (score >= 3)
        {
            targetDestroyed.Play();
            enemySinking.Play();
            enemyShip.Play("enemy enter", 0, 0.0f);
            Invoke("EndGame", 15f);
            fire.Play();
        }
    }
    public void EndGame()                                               //calls scene manager to restart scene
    {
        gameHasEnded = true;
        SceneManager.LoadScene("The Nautilus Ark");
    }
}
