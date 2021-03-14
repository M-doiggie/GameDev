using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditScreenController : MonoBehaviour
{
    public Canvas creditScreen;
    public Canvas startScreen;

    public void goBackToStartMenu()
    {
        creditScreen.gameObject.SetActive(false);
        startScreen.gameObject.SetActive(true);
    }
}
