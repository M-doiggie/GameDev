using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerOptionsController : MonoBehaviour
{
    public Canvas multiplayerScreen;
    public Canvas startScreen;

    public void goToHostLobbyScene() 
    {
    
    }

    public void joinALobby() 
    {
    
    }

    public void goBackToStartMenu() 
    {
        multiplayerScreen.gameObject.SetActive(false);
        startScreen.gameObject.SetActive(true);
    }

}
