using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool IsGround;
    [SerializeField] private LayerMask layer;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private float radius;
    //[SerializeField] private Animator anima;
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Ground") || collision.CompareTag("UpGround"))
    //    {
    //        if(anima.runtimeAnimatorController != null)
    //        {
    //            anima.SetBool("IsGround", true);
    //            anima.SetBool("IsWalling", false);
    //        }
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Ground") || collision.CompareTag("UpGround"))
    //    {
    //        anima.SetBool("IsGround", false);
    //    }
    //    if (collision.CompareTag("DownGround"))
    //    {
    //        anima.SetBool("IsDown", false);
    //    }
    //}

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
