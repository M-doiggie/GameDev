using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    private float flickerSpeed = 1f;
    private int randInt = 0;

    private bool onCooldown = false;

    void Start()
    {
        StartCoroutine(FlickerCoroutine());
    }

    IEnumerator FlickerCoroutine(){
        while(true){
            yield return new WaitForSecondsRealtime(flickerSpeed);
            gameObject.GetComponentInChildren<Light>().enabled = onCooldown;
            onCooldown = !onCooldown;
        }
    }
}
