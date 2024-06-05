using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float movingspeed;
    [SerializeField] private Rigidbody2D rig2d;
    [SerializeField] private Animator anima;
    private Transform currentpoint;
    // Start is called before the first frame update
    void Start()
    {
        currentpoint = pointA;
    }

    // Update is called once per frame
    void Update()
    {
        AutoMoving();
    }


    private void AutoMoving()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentpoint.position, movingspeed*Time.deltaTime);
        if (Vector3.Distance(transform.position, currentpoint.position) < 0.1f)
        {
            if (currentpoint == pointA)
            {
                currentpoint = pointB;
                anima.SetBool("IsRight", true);
                anima.SetBool("IsLeft", false);

            }
            else if (currentpoint == pointB)
            {
                currentpoint = pointA;
                anima.SetBool("IsLeft", true);
                anima.SetBool("IsRight", false);
            }
        }
    }
}
