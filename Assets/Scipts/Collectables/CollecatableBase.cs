using Unity.VisualScripting;
using UnityEngine;

public class Collectable
{
    public int points;
    public AudioClip collectSound;

    public Collectable()
    {

    }
    public Collectable(int init_points)
    {
        points = init_points;
    }
    public void PickUp(GameObject player)
    {
        Debug.Log("Pick Up");
    }
}
