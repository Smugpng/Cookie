using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{

    public static Player Instance {  get; private set; }
    private PlayerControler controler;
    private int playerPoints;

    public int points = 0;
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    private void Start()
    {
        controler = new PlayerControler(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collectable itemScript = collision.GetComponent<Collectable>();
        if(itemScript != null)
        {
            itemScript.PickUp(gameObject);
        }
        else
        {

        }
    }
   
    void OnMove(InputValue value)
    {
        controler.Transport(value.Get<Vector2>());
    }
    public void AddPoints(int pointsGained,GameObject collected)
    {
        Destroy(collected);
        playerPoints += pointsGained;
        Debug.Log(playerPoints);
    }


}
