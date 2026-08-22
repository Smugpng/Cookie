using System.Collections;
using UnityEngine;

public class Cookie : MonoBehaviour
{
    private Collectable cookie;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cookie = new Collectable(24);
        
    }

}
