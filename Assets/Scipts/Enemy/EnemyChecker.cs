using UnityEngine;

public class EnemyChecker : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("CheckPlayer", 5, 5);   
    }

    public void CheckPlayer()
    {
        Debug.Log("CHECING");
    }
}
