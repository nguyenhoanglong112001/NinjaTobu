using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigi2d;
    [SerializeField] private Animator anima;
    [SerializeField] private SpriteRenderer sprite;
    private float gravity;

    private void Start()
    {
        gravity = rigi2d.gravityScale;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("WallRight") || collision.CompareTag("SideLeft"))
        {
            rigi2d.velocity = Vector2.zero;
            rigi2d.gravityScale = 0;
            anima.SetBool("IsWalling", true);
            sprite.flipX = true;
        }
        else if (collision.CompareTag("WallLeft") || collision.CompareTag("SideRight"))
        {
            rigi2d.velocity = Vector2.zero;
            rigi2d.gravityScale = 0;
            anima.SetBool("IsWalling", true);
            sprite.flipX = false;

        }
        if (collision.CompareTag("DownGround"))
        {
            rigi2d.velocity = Vector2.zero;
            rigi2d.gravityScale = 0;
            anima.SetBool("IsDown", true);
            anima.SetBool("IsWalling", false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("WallLeft") || collision.CompareTag("WallRight") || collision.CompareTag("DownGround") || collision.CompareTag("SideGround") || collision.CompareTag("SideRight") || collision.CompareTag("SideLeft"))
        {
            rigi2d.gravityScale = gravity;
            anima.SetBool("IsWalling", false);
            anima.SetBool("IsDown", false);
        }
    }
}
