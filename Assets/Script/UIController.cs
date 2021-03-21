using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text numberOfPaperClips;

    void Update()
    {
        numberOfPaperClips.text = PlayerPrefs.GetInt("numOfPaperClips").ToString();
    }
}