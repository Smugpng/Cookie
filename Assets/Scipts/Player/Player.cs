using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{

    public static Player Instance {  get; private set; }
    private PlayerControler controler;

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


}
