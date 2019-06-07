using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingText : MonoBehaviour
{
    private bool fading;
    private SpriteRenderer sr;
    private float alpha;
    
    void Start()
    {
        fading = false;
        sr = GetComponent<SpriteRenderer>();
        alpha = 1;
    }

    void Update()
    {
        if (fading)
        {
            alpha -= 0.01f;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, alpha);
        }

    }

    public void Restore()
    {
        fading = false;
        alpha = 1;
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1);
    }

    public void Fade()
    {
        fading = true;
    }
}
