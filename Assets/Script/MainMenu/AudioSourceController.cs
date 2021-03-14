using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceController : MonoBehaviour
{

    private bool fadeAudio;

    // Start is called before the first frame update
    void Start()
    {
        fadeAudio = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeAudio) 
        {
            Debug.LogError("Audio source Volume: " + gameObject.GetComponent<AudioSource>().volume);
            if (gameObject.GetComponent<AudioSource>().volume <= 0)
            {
                gameObject.GetComponent<AudioSource>().Stop();
                fadeAudio = false;
            }
            else 
            {
                gameObject.GetComponent<AudioSource>().volume -= 0.3f * Time.deltaTime;
            }
        }

    }

    public void fadeMusic() {
        Debug.LogError("Fading");
        fadeAudio = true;
    }
}
