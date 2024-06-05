using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] private LayerMask targetlayer;
    [SerializeField] private Animator anima;
    [SerializeField] private Transform findpoint;
    [SerializeField] private float aimradius;
    [SerializeField] private Transform target;
    [SerializeField] private Transform head;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //var aimranged = Physics2D.CircleCast(findpoint.position, aimradius, transform.position, 0.0f, targetlayer);
        //if (aimranged.collider != null)
        //{
        //    var dir = target.position - head.position;
        //    var angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        //    head.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //}
    }
}
