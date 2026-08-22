using System.Collections.Generic;
using UnityEngine;

public class WallSpawn : MonoBehaviour
{
    [Header("Placeables")]
    [Range(1, 10f)]
    [SerializeField] private int numOfWalls, numOfPickups;
    [SerializeField] private int randomizeAmount;

    [SerializeField] private GameObject wallPrefab, enemyPrefab;
    //public List<Vector3> cookiePlacements = new List<Vector3>();
    //public List<GameObject> cookies = new List<GameObject>();

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

        //cookiePlacements.Clear();
        walls.Clear();

        PlaceWalls();
        PlaceEnemy();
    }
    private void PlaceWalls()
    {
        int gulp = numOfWalls + Random.Range(-randomizeAmount, randomizeAmount); //Wall Placements
        for (int i = 0; i < gulp; i++)
        {
            GameObject wall = Instantiate(wallPrefab);
            wall.transform.SetParent(gameObject.transform);
            wall.transform.position = GeneratePlacement();

            wallPlacements.Add(wall.transform.position);
            walls.Add(wall);
        }
    }
    private void PlaceEnemy()
    {
        GameObject Enemy = Instantiate(enemyPrefab);
        Enemy.transform.position = GeneratePlacement();
    }
    /*private void PlaceCookies()
    {
        int gulp = numOfPickups + Random.Range(-randomizeAmount, randomizeAmount); //Wall Placements
        for (int i = 0; i < gulp; i++)
        {
            GameObject cookie = Instantiate(cookiePrefavs);
            cookie.transform.SetParent(gameObject.transform);
            cookie.transform.position = GeneratePlacement();

            cookiePlacements.Add(cookie.transform.position);
            cookies.Add(cookie);
        }
    }*/

    private Vector3 GeneratePlacement()
    {
        Vector3 pos = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), 0);
        if (pos == new Vector3(0, 0, 0) || wallPlacements.Contains(pos)/*|| cookiePlacements.Contains(pos)*/)
        {
            return GeneratePlacement();
        }
        else return pos;
    }

    
}
