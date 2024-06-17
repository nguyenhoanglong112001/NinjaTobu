using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyWallCheck : MonoBehaviour
{
    [SerializeField] private bool IsOnWall;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WallLeft") || collision.CompareTag("WallRight"))
        {
            IsOnWall = true;
            animator.SetBool("IsOnWall", true);
            if(sprite.flipX)
            {
                sprite.flipX = false;
            }
            else
            {
                sprite.flipX = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("WallLeft") || collision.CompareTag("WallRight"))
        {
            IsOnWall = false;
            animator.SetBool("IsOnWall", false);
        }
    }

    public bool GetCheck()
    {
        return IsOnWall;
    }
}
