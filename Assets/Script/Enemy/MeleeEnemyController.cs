using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyController : MonoBehaviour, EnemyBase
{
    private int hp;
    private bool isAlive;
    private GameObject player;


    private void Awake()
    {
        hp = 10;
        player = GameObject.Find("Player");
    }

    public void OnInteraction()
    {
        GetHurt();
    }


    private void GetHurt() 
    {
        
        hp -= player.GetComponent<PlayerInteractionController>().getDamageOutput();
        if (hp <= 0)
        {
            isAlive = false;
            Destroy(gameObject);
            PlayerPrefs.SetInt("numOfPaperClips", PlayerPrefs.GetInt("numOfPaperClips") + 5);
        }

    }
}
