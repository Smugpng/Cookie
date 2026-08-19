using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControler
{
    public GameObject playerObj;
    private float leanTime = .15f;

    public Vector3 playerPosition;
    public PlayerControler()
    {

    
    }
    public PlayerControler(GameObject player)
    {
        this.playerObj = player;
    }
    private Vector2 newPos;
    public void Transport(Vector2 moveinput)
    {
        if (moveinput == new Vector2(0, 0)) return;

        SFXManager.Instance.PlaySound();
        if (LeanTween.isTweening(playerObj))
        {
            LeanTween.cancel(playerObj);
            playerObj.transform.position = newPos;
            playerObj.transform.localScale = new Vector3(1, 1, 1);
        }

        newPos = playerObj.transform.position + new Vector3((int)moveinput.x, (int)moveinput.y, 0);

        LeanTween.move(playerObj, newPos, leanTime).setEaseOutBack().setEaseOutCirc();
        LeanTween.scale(playerObj, new Vector3(.75f, .75f, .75f), leanTime).setEaseInOutBounce().setLoopPingPong(1);
    }



}
