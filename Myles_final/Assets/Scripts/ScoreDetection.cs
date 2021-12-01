using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ScoreDetection : MonoBehaviour
{
    [SerializeField]
    private UnityEvent timer;
    public int score =0;
    public TextMeshProUGUI scoreText;
    [SerializeField]
    public Animator enemyShip;

    private void Start()
    {
        scoreText.text = "score:" + score; 
    }

    private void OnTriggerEnter(Collider other)
    {
        AddPoint();
        DestroyEnemy();
        if (other.CompareTag("ScoreDetection"))
        {
            timer.Invoke();
        }
    }    
    public void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString() + "points";
    }
    public void DestroyEnemy()
    {
        if (score >= 3)
        {
            enemyShip.Play("ship destroyed", 0, 0.0f);
        }
    }
}
