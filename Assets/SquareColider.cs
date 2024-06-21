using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareColider : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator playeranimator;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Rigidbody2D playerrigi;
    [SerializeField] private Jump checkjump;


    private void Start()
    {
        playeranimator = GameObject.FindWithTag("Player").transform.GetChild(0).GetComponent<Animator>();
        sprite = GameObject.FindWithTag("Player").transform.GetChild(0).GetComponent<SpriteRenderer>();
        playerrigi = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        checkjump = GameObject.FindWithTag("Player").GetComponent<Jump>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            ContactPoint2D contactpoint = collision.GetContact(0);
            Vector2 contactPosition = contactpoint.point;
            Vector2 groundCenter = collision.otherCollider.bounds.center;

            float deltaX = contactPosition.x - groundCenter.x;
            float deltaY = contactPosition.y - groundCenter.y;

            if(Mathf.Abs(deltaX) > Mathf.Abs(deltaY))
            {
                if(deltaX > 0)
                {
                    Debug.Log("a");
                    playerrigi.velocity = Vector2.zero;
                    playerrigi.gravityScale = 0;
                    playeranimator.SetBool("IsWalling", true);
                    playeranimator.SetBool("IsGround", false);
                    sprite.flipX = false;
                }
                else
                {
                    Debug.Log("b");
                    playerrigi.velocity = Vector2.zero;
                    playerrigi.gravityScale = 0;
                    playeranimator.SetBool("IsWalling", true);
                    playeranimator.SetBool("IsGround", false);
                    sprite.flipX = true;
                }
            }
            else
            {
                if(deltaY > 0)
                {
                    Debug.Log("c");
                    playeranimator.SetBool("IsGround", true);
                    playeranimator.SetBool("IsWalling", false);
                }
                else
                {
                    Debug.Log("d");
                    playerrigi.velocity = Vector2.zero;
                    playerrigi.gravityScale = 0;
                    if(!checkjump.ismoving)
                    {
                        playeranimator.SetBool("IsGround", false);
                        playeranimator.SetBool("IsDown", true);
                        playeranimator.SetBool("IsWalling", false);
                    }    
                }
            }
        }
    }


}
