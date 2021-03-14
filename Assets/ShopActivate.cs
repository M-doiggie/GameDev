using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopActivate : MonoBehaviour
{

    public string input;
    public bool onTrigger;
    private bool canInteract = false;
    private bool showGUI = false;
    private bool keypadScreen = false;
    private void Update()
    {
        if(canInteract && Input.GetKeyDown(KeyCode.E)){
            showGUI = true;
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

                if (GUI.Button(new Rect(5, 35, 100, 100), "1"))
                {
                    input += "1";
                }
                if (GUI.Button(new Rect(110, 35, 100, 100), "2"))
                {
                    input += "2";
                }
                if (GUI.Button(new Rect(215, 35, 100, 100), "3"))
                {
                    input += "3";
                }
                if (GUI.Button(new Rect(5, 140, 100, 100), "4"))
                {
                    input += "4";
                }
                if (GUI.Button(new Rect(110, 140, 100, 100), "5"))
                {
                    input += "5";
                }
                if (GUI.Button(new Rect(215, 140, 100, 100), "6"))
                {
                    input += "6";
                }
                if (GUI.Button(new Rect(5, 245, 100, 100), "7"))
                {
                    input += "7";
                }
                if (GUI.Button(new Rect(110, 245, 100, 100), "8"))
                {
                    input += "8";
                }
                if (GUI.Button(new Rect(215, 245, 100, 100), "9"))
                {
                    input += "9";
                }
                if (GUI.Button(new Rect(110, 350, 100, 100), "0"))
                {
                    input += "0";
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
}
