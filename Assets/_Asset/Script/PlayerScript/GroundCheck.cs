using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool IsGround;
    [SerializeField] private LayerMask layer;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private float radius;

    private void Update()
    {
        checkground();
    }

    private void checkground()
    {
        IsGround = Physics2D.CircleCast(groundcheck.position, radius, transform.position, 0.0f, layer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(groundcheck.position, radius);
    }
}
