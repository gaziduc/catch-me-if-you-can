using UnityEngine;

public class Blink : MonoBehaviour
{
    public float maxAlpha;
    public float minAlpha;

    private SpriteRenderer sp;
    private bool isGoingDown = false;
    
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGoingDown)
        {
            if (sp.color.a > minAlpha)
                sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, sp.color.a - 0.002f);
            else
                isGoingDown = false;
        }
        else
        {
            if (sp.color.a < maxAlpha)
                sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, sp.color.a + 0.002f);
            else
            {
                isGoingDown = true;
            }
        }
    }
}
