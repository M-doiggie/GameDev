using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInteractionController : MonoBehaviour
{
    public int health;
    public HealthBar healthbar;

    public Image crosshairContainer;
    public Sprite crosshairDefault;
    public Sprite crosshairFired;

    private float waitTime;
    private bool alreadyFired;

    private AudioSource gunShot;
    private void Awake()
    {
        PlayerPrefs.SetInt("numOfPaperClips",0);
        health = 20;
        gunShot = GetComponent<AudioSource>();
        waitTime = gunShot.clip.length - 1;
        alreadyFired = false;
    }

    void Update()
    {
        healthbar.SetHealth(health);
        PhysicsRaycasts();
    }

    void PhysicsRaycasts()
    {
        Vector3 centreOfScreen = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0);
        float distanceToFireRay = 40;
        Ray centreOfScreenRay = Camera.main.ScreenPointToRay(centreOfScreen);
        RaycastHit hit;
        if (Physics.Raycast(centreOfScreenRay, out hit, distanceToFireRay))
        {
            if (hit.transform.gameObject.GetComponent<EnemyBase>() is EnemyBase)
            {
                if (Input.GetMouseButtonDown(0) && alreadyFired == false)
                {
                    crosshairContainer.sprite = crosshairFired;
                    hit.transform.gameObject.GetComponent<EnemyBase>().OnInteraction();
                    alreadyFired = true;
                    GetComponent<AudioSource>().Play();
                }
                else
                {
                    StartCoroutine(WaitForSwapBack());
                }
            }

            if (LayerMask.LayerToName(hit.transform.gameObject.layer) == "EndControl" && Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadSceneAsync(2);
            }
            
        }
    }

    IEnumerator WaitForSwapBack() {
        yield return new WaitForSeconds(waitTime);
        crosshairContainer.sprite = crosshairDefault;
        alreadyFired = false;
    }
}
