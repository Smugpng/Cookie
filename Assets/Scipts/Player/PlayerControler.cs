using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControler
{
    [Header("Player Info")]
    public GameObject playerObj;
    public Vector3 playerPosition;
    private Vector3 playerStartScale;

    [Header("Tweening")]
    private float leanTime = .15f;

    [Header("Movement")]
    private Vector2 newPos;

    public PlayerControler()
    {

    
    }
    public PlayerControler(GameObject player)
    {
        this.playerObj = player;
        playerStartScale = player.transform.localScale;
    }
    
    public void Transport(Vector2 moveinput) //Move Command
    {
        if (moveinput == new Vector2(0, 0)) return; //Checks if player input is a move press or release input.

        SFXManager.Instance.PlaySound();
        if (LeanTween.isTweening(playerObj)) //If player is already moving and in the animation skip ahead to the end of the animation and stop the tween
        {
            LeanTween.cancel(playerObj);
            playerObj.transform.position = newPos;
            playerObj.transform.localScale = playerStartScale;
        }

        newPos = playerObj.transform.position + new Vector3((int)moveinput.x, (int)moveinput.y, 0); //finding new position

        if (!CanMove(newPos))
        {
            SFXManager.Instance.ErrorSound();
            InPlace(newPos);
            return;
        }



        LeanTween.move(playerObj, newPos, leanTime).setEaseOutBack().setEaseOutCirc(); //movement tween
        LeanTween.scale(playerObj, new Vector3(.75f, .75f, .75f), leanTime).setEaseInOutBounce().setLoopPingPong(1); //cosmetic scale tween
    }

    private bool CanMove(Vector3 desiredLocation)//Checks if the new postion is blocked
    {
        if (WallSpawn.Instance.wallPlacements.Contains(desiredLocation)) 
        { return false; }
        else return true;
    }
    private void InPlace(Vector3 desiredLocation) //Can be bypassed if inputed fast fix next time
    {
        Vector3 pos = ((playerObj.transform.position / 2) + (desiredLocation / 2));
        LeanTween.move(playerObj, pos, .05f).setEaseOutBack().setLoopPingPong(1); //movement tween
        LeanTween.scale(playerObj, new Vector3(1.25f, 1.25f, 1.25f), .1f).setEaseInOutBounce().setLoopPingPong(1);
    }

}
