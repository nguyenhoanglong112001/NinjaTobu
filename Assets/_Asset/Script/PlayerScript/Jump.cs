using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rig2d;
    private Vector3 statposition;
    private Vector3 endposition;
    [SerializeField] private float conditiondistance;
    private Vector3 mouseposition;
    private Vector2 direction;
    [SerializeField] private float movespeed;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Animator animator;
    [SerializeField] private GroundCheck groundcheck;
    [SerializeField] private PowerCheck check;
    [SerializeField] private float maxjump;
    private float jumpcount;
    public bool ismoving;
    public bool jumping;
    [SerializeField] private MonkeyAttack mkatk;
    [SerializeField] private MonKeyCollect mkcollect;
    [SerializeField] private SoundManager manager;
    [SerializeField] private AudioSource JumpSound;

    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if(check.MonkeyAtkCheck())
        {
            mkatk = GameObject.Find("AttackDitect").GetComponent<MonkeyAttack>();
        }
        if(check.MonkeyCollectCheck())
        {
            mkcollect = GameObject.Find("CollectDitect").GetComponent<MonKeyCollect>();
        }
        FloowMouse();
        ResetJump();
        SetMovingCheck();
    }

    public bool MovingCheck()
    {
        return ismoving;
    }

    public void SetMovingCheck()
    {
        if(groundcheck.IsGround)
        {
            ismoving = false;
            jumping = false;
        }
        else if (!groundcheck.IsGround)
        {
            ismoving = true;
        }
    }

    private void FloowMouse()
    {
        mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mouseposition - transform.position).normalized; 
        if (Input.GetMouseButtonDown(0))
        {
            statposition = Input.mousePosition; // Luu vi tri dau khi nguoi dung cham
        }
        if (Input.GetMouseButton(0))
        {
            endposition = Input.mousePosition; // khi nguoi dung luot, se luu vao diem cuoi cung
        }
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 Swipedistance = endposition - statposition; // khi bo cham, tinh toan do dai tu diem dau den diem bo nut
            if (Swipedistance.magnitude > conditiondistance)
            {
                if (groundcheck.IsGround && jumpcount < maxjump/*&& jumpcount.jumpscount > 0)*/)
                {
                    if (Swipedistance.x > 0)
                    {
                        sprite.flipX = false;
                    }
                    else
                    {
                        sprite.flipX = true;
                    }
                    manager.SetJumpSound();
                    JumpSound.Play();
                    rig2d.velocity = new Vector2(direction.x * movespeed, direction.y * movespeed);// object se di chuyen theo huong duoc luot
                    jumpcount++;
                    ismoving = true;
                    jumping = true;
                    if (mkatk != null)
                    {
                        mkatk.SetAttack(false);
                    }
                    if (mkcollect != null)
                    {
                        mkcollect.SetCollect(false);
                    }
                    //HasJumpFirst = true;
                    animator.SetTrigger("IsRolling");
                }
                else if (jumpcount < maxjump && !groundcheck.IsGround/*HasJumpFirst*/)
                {
                    if (Swipedistance.x > 0)
                    {
                        sprite.flipX = false;
                    }
                    else
                    {
                        sprite.flipX = true;
                    }
                    manager.SetJumpSound();
                    JumpSound.Play();
                    rig2d.velocity = new Vector2(direction.x * movespeed, direction.y * movespeed);// object se di chuyen theo huong duoc luot
                    animator.SetTrigger("Jumping");
                    jumping = true;
                    jumpcount++;
                    //HasJumpFirst = false;
                }
                else if (jumpcount == maxjump)
                {
                    return;
                }
            }
        }
    }

    private void ResetJump()
    {
        if(groundcheck.IsGround)
        {
            jumpcount = 0;
        }
    }

    public void JumpUp(float jump)
    {
        maxjump += jump;
    }

    public void SetSpeed(float newspeed)
    {
        movespeed = newspeed;
    }

    public void SetGravity(float newgravity)
    {
        rig2d.gravityScale = newgravity;
    }
}