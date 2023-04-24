using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIFadeOut : MonoBehaviour
{
    public float startDelay;
    public float rate;
    public TMP_Text text;
    private bool fading = false;
    
    private void Awake() {
        Invoke("StartFade", startDelay);
    }

    private void StartFade() { fading = true; }
    
    void FixedUpdate()
    {
        if (fading)
            text.alpha -= rate;

        if (text.alpha < 0)
        {
            fading = false; 
            gameObject.SetActive(false);
        }
    }
}
