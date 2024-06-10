using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMove : MonoBehaviour
{
    [SerializeField] private float movespeed;
    [SerializeField] private float ditectradius;
    [SerializeField] private Rigidbody2D playerrigi;
    [SerializeField] private GameObject follow;
    private float playerY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * movespeed * Time.deltaTime);
    }

    //public void CheckPlayerJump()
    //{
    //    if(playerrigi != null)
    //    {
    //        playerY = playerrigi.velocity.y;
    //    }

    //    float stopspeed = 0;
    //    if(playerY > ditectradius)
    //    {
    //        Debug.Log("Stop");
    //        gameObject.transform.SetParent(follow.transform);
    //        transform.Translate(Vector2.up * stopspeed * Time.deltaTime);
    //    }
    //    else if (playerY < ditectradius)
    //    {
    //        Debug.Log("Go");
    //        gameObject.transform.SetParent(null);
    //        transform.Translate(Vector2.up * movespeed * Time.deltaTime);
    //    }
    //}


    public void SetSpeed(float numspeed)
    {
        movespeed += numspeed;
    }
}
