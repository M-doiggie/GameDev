using UnityEngine;

public class StartScreenController : MonoBehaviour
{
    public Canvas startScreen;
    public Canvas singlePlayerScreen;
    public Canvas multiplayerScreen;
    public Canvas creditScreen;

    public void goToSinglePlayerScreen() {
        startScreen.gameObject.SetActive(false);
        singlePlayerScreen.gameObject.SetActive(true);
    }

    public void goToMultiplayerScreen()
    {
        startScreen.gameObject.SetActive(false);
        multiplayerScreen.gameObject.SetActive(true);
    }

    public void goToCreditScreen()
    {
        startScreen.gameObject.SetActive(false);
        creditScreen.gameObject.SetActive(true);
    }

}
