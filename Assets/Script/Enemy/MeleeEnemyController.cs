using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyController : MonoBehaviour, EnemyBase
{
    private int hp;
    private bool isAlive;


    private void Awake()
    {
        hp = 10;
    }

    public void OnInteraction()
    {
        GetHurt();
    }


    private void GetHurt() 
    {
        hp -= 2;
        if (hp <= 0)
        {
            isAlive = false;
            Destroy(gameObject);
            PlayerPrefs.SetInt("numOfPaperClips", PlayerPrefs.GetInt("numOfPaperClips") + 5);
        }

    }
}
