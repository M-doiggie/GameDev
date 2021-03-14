using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlayerOptionsController : MonoBehaviour
{
    public Canvas singlePlayerScreen;
    public Canvas levelSelectorScreen;
    public Canvas startScreen;

    public void goToLevelSelector() 
    {
        singlePlayerScreen.gameObject.SetActive(false);
        levelSelectorScreen.gameObject.SetActive(true);
    }

    public void continueGame() 
    {
        //Load previous game
    }

    public void goBackToStartMenu() 
    {
        singlePlayerScreen.gameObject.SetActive(false);
        startScreen.gameObject.SetActive(true);
    }
}
