using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private float alpha = 1f;
    private SpriteRenderer sr;

    public float destroySpeed = 0.5f;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, alpha);
        alpha -= destroySpeed * Time.fixedDeltaTime;
        
        if (alpha <= 0f)
            Destroy(gameObject);
    }
}
