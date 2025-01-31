using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private 
        AudioSource goldFX,stoneFX,playerLaughFX,pullFX,streachingFX,timerFX,gameOverFX;

    void Awake()
    {
        if(instance == null) { instance = this; }
    }

    public void GoldSound()
    {
        goldFX.Play();
    }

    public void StoneSound()
    {
        stoneFX.Play();
    }

    public void PlayerLaugh()
    {
        playerLaughFX.Play();
    }

    public void PullSound(bool playFX)
    {
        if (playFX)
        {
            if (!pullFX.isPlaying)
            {
                pullFX.Play();
            }
        }
        else
        {
            if (pullFX.isPlaying)
            {
                pullFX.Stop();
            }

        }
    }

    public void StreachingSound(bool playFX)
    {
        if (playFX) {
            if (!streachingFX.isPlaying)
            {
                streachingFX.Play();
            }
        }
        else
        {
            if (streachingFX.isPlaying)
            {
                streachingFX.Stop();
            }

        }
    
    }

    public void TimerSound(bool playFX)
    {
        if (playFX)
        {
            if (!timerFX.isPlaying)
            {
                timerFX.Play();
            }
        }
        else
        {
            if (timerFX.isPlaying)
            {
                timerFX.Stop();
            }

        }

    }

    public void GameEnd()
    {
        gameOverFX.Play();
    }
}
