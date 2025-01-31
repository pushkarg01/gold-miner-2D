using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;

    [SerializeField]private TextMeshProUGUI countdownText;
    public int countdownTimer = 60;

    [SerializeField]private TextMeshProUGUI scoreText;
    private int scoreCount;

    [SerializeField] private Image scoreFillUI;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
       
    }

    void Start()
    {
        DisplayScore(0);
        countdownText.text =countdownTimer.ToString();

        StartCoroutine("CountDown");
        
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(1f);

        countdownTimer -=1;

        countdownText.text =countdownTimer.ToString();
        if(countdownTimer <= 10)
        {
            SoundManager.instance.TimerSound(true);
        }

        StartCoroutine("CountDown");

        if(countdownTimer <= 0){
            StopCoroutine("CountDown");

            SoundManager.instance.GameEnd();
            SoundManager.instance.TimerSound(false);

            StartCoroutine(RestartGame());
        }
    }

    public void DisplayScore(int scoreValue)
    {
        if (scoreText == null) return;
        
        scoreCount += scoreValue;
        scoreText.text = "$ " + scoreCount;

        scoreFillUI.fillAmount = (float)scoreCount / 100f;

         if(scoreCount >= 100)
         {
           
                StopCoroutine("CountDown");
                SoundManager.instance.GameEnd();
                StartCoroutine(RestartGame());
         }
        
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(4f);

        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
