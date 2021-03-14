using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelSelectorController : MonoBehaviour
{
    public Canvas levelSelectorScreen;
    public Canvas singlePlayerScreen;
    public AudioSource backgroundMusic;

    private Coroutine levelLoader;
    private int levelSelected;
    private float delay;

    void Awake() {
        delay = 1f;
        
    }

    void Start() {
        levelSelected = 0;
    }

    void Update() {
        if (levelSelected != 0) {
            levelLoader = StartCoroutine(loadLevel());
        };
    }

    public void goToLevelOne() 
    {
        levelSelected = 1;
        
    }

    private IEnumerator loadLevel()
    {
        float elaspedTime = 0;
        float currentVolume = backgroundMusic.volume;

        while (elaspedTime < delay)
        {
            elaspedTime += Time.deltaTime;
            backgroundMusic.volume = Mathf.Lerp(currentVolume, 0, elaspedTime / delay);
            yield return null;
        }
        SceneManager.LoadSceneAsync(levelSelected);
    }

    public void goToLevelTwo()
    {
        levelSelected = 2;
    }
    public void goToLevelThree()
    {
        levelSelected = 3;
    }
    public void goBackToSinglePlayerMenu()
    {
        levelSelectorScreen.gameObject.SetActive(false);
        singlePlayerScreen.gameObject.SetActive(true);
    }
}
