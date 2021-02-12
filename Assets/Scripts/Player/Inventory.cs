using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int numTVs;
    public int numKills;
    
    private Text numTVsText;
    private Text numKillsText;

    public static Inventory instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
        numTVsText = GameObject.Find("numTVsText").GetComponent<Text>();
        numKillsText = GameObject.Find("numKillsText").GetComponent<Text>();
    }

    public void AddNumTVs()
    {
        numTVs++;
        numTVsText.text = numTVs.ToString();
    }

    public void AddKill()
    {
        numKills++;
        numKillsText.text = numKills.ToString();
    }
}
