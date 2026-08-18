using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControler
{
    public GameObject playerPos;
    public PlayerControler()
    {

    
    }
    public PlayerControler(GameObject player)
    {
        this.playerPos = player;
    }

    public void Up()
    {
        Vector3 newPos = playerPos.transform.position + new Vector3(0, 1, 0);
        playerPos.transform.position = newPos;
        Debug.Log("TEST");
    }
    public void Down()
    {
        Vector3 newPos = playerPos.transform.position + new Vector3(0, -1, 0);
        playerPos.transform.position = newPos;
    }
    public void Left()
    {
        Vector3 newPos = playerPos.transform.position + new Vector3(-1, 0, 0);
        playerPos.transform.position = newPos;
    }
    public void Right()
    {
        Vector3 newPos = playerPos.transform.position + new Vector3(1, 0, 0);
        playerPos.transform.position = newPos;
    }

}
