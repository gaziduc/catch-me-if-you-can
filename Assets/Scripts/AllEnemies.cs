using UnityEngine;


public class AllEnemies : MonoBehaviour
{
    public static AllEnemies instance = null;
    public FollowThePath[] enemiesFollowingPath;
    public int moveSpeedAlert;
    public int moveSpeedWarning;
    public float rotationSpeedAlert;
    public float rotationSpeedWarning;
    
    public GameObject redSquare;
    
    public bool isInAlert;
    public bool isInWarning;

    private void Start()
    {
        instance = this;

        isInAlert = false;
        isInWarning = false;
    }

    public void AlertEnemies()
    {
        foreach (var enemy in enemiesFollowingPath)
        {
            if (!enemy.gameObject.GetComponent<DieOnKnife>().isDead)
            {
                enemy.gameObject.SetActive(true);
                enemy.SetSpeed(enemy.initialMoveSpeed * 1.8f, enemy.initialRotationSpeed * 1.8f);
                enemy.transform.GetChild(1).gameObject.SetActive(true);
                enemy.transform.GetChild(2).gameObject.SetActive(false);
            }
        }
        
        redSquare.SetActive(true);

        isInAlert = true;
    }

    public void WarnEnemies()
    {
        foreach (var enemy in enemiesFollowingPath)
        {
            if (!enemy.gameObject.GetComponent<DieOnKnife>().isDead)
            {
                enemy.gameObject.SetActive(true);
                enemy.SetSpeed(enemy.initialMoveSpeed * 1.4f, enemy.initialRotationSpeed * 1.4f);
                enemy.transform.GetChild(1).gameObject.SetActive(false);
                enemy.transform.GetChild(2).gameObject.SetActive(true);
            }
        }
        
        redSquare.SetActive(false);
    }

    public void ResetEnemiesState()
    {
        foreach (var enemy in enemiesFollowingPath)
        {
            if (!enemy.gameObject.GetComponent<DieOnKnife>().isDead)
            {
                enemy.SetSpeed(enemy.initialMoveSpeed, enemy.initialRotationSpeed);
                enemy.transform.GetChild(1).gameObject.SetActive(false);
                enemy.transform.GetChild(2).gameObject.SetActive(false);
            }
        }
        
        redSquare.SetActive(false);
    }
}
