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
        if (collision.CompareTag("WallRight"))
        {
            rigi2d.velocity = Vector2.zero;
            rigi2d.gravityScale = 0;
            anima.SetBool("IsWalling", true);
            sprite.flipX = true;
        }
        else if (collision.CompareTag("WallLeft"))
        {
            rigi2d.velocity = Vector2.zero;
            rigi2d.gravityScale = 0;
            anima.SetBool("IsWalling", true);
            sprite.flipX = false;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
<<<<<<< HEAD
        if (gamemanager != null)
=======
        if(collision.CompareTag("WallLeft") || collision.CompareTag("WallRight") || collision.CompareTag("Ground"))
>>>>>>> parent of b90ae34 (fix small power)
        {
            rigi2d.gravityScale = gravity;
            anima.SetBool("IsWalling", false);
            anima.SetBool("IsDown", false);
        }
    }
}
