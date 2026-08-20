using System.Collections.Generic;
using UnityEngine;

public class WallSpawn : MonoBehaviour
{
    [Range(1, 10f)]
    [SerializeField] private int numOfWalls;
    [SerializeField] private int randomizeAmount;

    [SerializeField] private GameObject wallPrefab;
    public List<Vector3> wallPlacements = new List<Vector3>();
    public List<GameObject> walls = new List<GameObject>();



    public static WallSpawn Instance { get; private set; }
   
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        
        for (int i = 0; i < walls.Count; i++)
        {
            Destroy(walls[i]);
            
        }
        wallPlacements.Clear();
        walls.Clear();

        int gulp = numOfWalls + Random.Range(-randomizeAmount, randomizeAmount);
        for (int i = 0; i < gulp; i++)
        {
            GameObject wall = Instantiate(wallPrefab);
            wall.transform.SetParent(gameObject.transform);
            wall.transform.position = GeneratePlacement();

            wallPlacements.Add(wall.transform.position);
            walls.Add(wall);
        }
    }

    private Vector3 GeneratePlacement()
    {
        Vector3 pos = new Vector3(Random.Range(-20,20), Random.Range(-20, 20),0);
        if (pos == new Vector3(0, 0, 0))
        {
            return GeneratePlacement();
        }
        else return pos;
    }

    
}
