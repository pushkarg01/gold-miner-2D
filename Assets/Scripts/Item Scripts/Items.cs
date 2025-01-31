using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public float hookSpeed;
    public int scoreVal;

    void OnDisable()
    {
        GameplayManager.instance.DisplayScore(scoreVal);
    }
}
