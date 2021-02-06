using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableChildInTime : MonoBehaviour
{
    public float time;
    private GameObject child;

    // Start is called before the first frame update
    void Start()
    {
        child = transform.GetChild(0).gameObject;
        StartCoroutine(DisbaleAndWait());
    }

    private IEnumerator DisbaleAndWait()
    {
        while (true)
        {
            child.SetActive(!child.activeSelf);
            yield return new WaitForSeconds(time);
        }
    }
}
