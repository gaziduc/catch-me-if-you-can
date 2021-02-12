using UnityEngine;
using UnityEngine.SceneManagement;
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
        
        // If is in menu
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            numTVsText = GameObject.Find("numTVsText").GetComponent<Text>();
            numKillsText = GameObject.Find("numKillsText").GetComponent<Text>();
        }
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
