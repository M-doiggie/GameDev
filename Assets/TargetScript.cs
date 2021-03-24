using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetScript : MonoBehaviour, EnemyBase
{
    private int hp;
    private GameObject player;

    private Text text;


    private void Awake()
    {
        hp = 0;
        player = GameObject.Find("Player");
        text = gameObject.GetComponentInChildren<Text>();
    }

    public void OnInteraction()
    {
        GetHurt();
    }


    private void GetHurt() 
    {
        
        hp += player.GetComponent<PlayerInteractionController>().getDamageOutput();
        text.text = hp.ToString();
    }
}
