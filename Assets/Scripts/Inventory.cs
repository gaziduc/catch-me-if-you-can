using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int numTVs;
    private Text numTVsText;

    // Start is called before the first frame update
    void Start()
    {
        numTVsText = GameObject.Find("numTVsText").GetComponent<Text>();
    }

    public void AddNumTVs()
    {
        numTVs++;
        numTVsText.text = numTVs.ToString();
    }
}
