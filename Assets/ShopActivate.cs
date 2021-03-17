using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopActivate : MonoBehaviour
{
    public PlayerInteractionController player;
    public string input;
    public bool onTrigger;
    private bool canInteract = false;
    private bool showGUI = false;
    private bool keypadScreen = false;
    private bool NoMoneyCheck = false;
    private bool NoHealCheck = false;


    private void Update()
    {
        if(canInteract && Input.GetKeyDown(KeyCode.E)){
            showGUI = true;
        }
        if (NoMoneyCheck){
            StartCoroutine("SetNoMoneyCheckToFalse");
        }
        if (NoHealCheck){
            StartCoroutine("SetNoHealCheckToFalse");
        }
        
    }

    private void OnGUI()
    {
            if (canInteract)
            {
                GUI.Box(new Rect(0, 0, 200, 25), "Press e to open keypad");

                if (Input.GetKeyDown(KeyCode.E))
                {
                    keypadScreen = true;
                    onTrigger = false;
                    Cursor.lockState = CursorLockMode.Confined;
                }
            }

            if (keypadScreen)
            {
                GUI.Box(new Rect(0, 0, 320, 450), "");
                GUI.Box(new Rect(5, 5, 310, 25), input);

                if (GUI.Button(new Rect(5, 35, 100, 100), "Heal \n 10 Clips"))
                {
                    if (PlayerPrefs.GetInt("numOfPaperClips") < 10){
                        NoMoneyCheck = true;
                    }
                    else
                    {
                        if (player.getHealth()+5 >= 20){
                            NoHealCheck = true;
                        }
                        else
                        {
                            PlayerPrefs.SetInt("numOfPaperClips", PlayerPrefs.GetInt("numOfPaperClips") - 10);
                            player.takeDamage(-5);
                        }
                    }
                }
                if (NoMoneyCheck)
                {
                    GUI.Box(new Rect(100,100,150,200), "You don't have enough funds.");
                    
                }
                if (NoHealCheck)
                {
                    GUI.Box(new Rect(100,100,500,500), "You dont need to be healed.");
                }
                }
            }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "Player"){
            canInteract = false;
            showGUI = false;
        }
    }

    private IEnumerator SetNoMoneyCheckToFalse(){
        yield return new WaitForSeconds(1.5f);
        if (NoMoneyCheck)
        {
            NoMoneyCheck = false;
        }
        yield return null;
    }

    private IEnumerator SetNoHealCheckToFalse(){
        yield return new WaitForSeconds(1.5f);
        if (NoHealCheck)
        {
            NoHealCheck = false;
        }
        yield return null;
    }
}
