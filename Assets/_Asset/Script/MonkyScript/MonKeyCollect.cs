using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonKeyCollect : MonoBehaviour
{
    [SerializeField] private Transform[] Sideposition;
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform Monkey;
    [SerializeField] private Rigidbody2D mkgoldrigi;
    private bool iscoinleft;
    private bool iscoinright;
    private bool iscollect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        JumptoPoint();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            SetCollect(true);
            mkgoldrigi.velocity = Vector2.zero;
            if (Vector2.Distance(Monkey.position, Sideposition[0].position) < 0.1f)
            {
                animator.SetTrigger("Jump");
                iscoinleft = true;
                iscoinright = false;
            }
            else if (Vector2.Distance(Monkey.position, Sideposition[1].position) < 0.1f)
            {
                animator.SetTrigger("Jump");
                iscoinleft = false;
                iscoinright = true;
            }
        }
    }

    private void JumptoPoint()
    {
        if (iscoinright && !iscoinleft)
        {
            Monkey.position = Vector2.Lerp(Monkey.position, Sideposition[0].position, speed * Time.deltaTime);
        }
        else if (!iscoinright && iscoinleft)
        {
            Monkey.position = Vector2.Lerp(Monkey.position, Sideposition[1].position, speed * Time.deltaTime);
        }
    }

    public void SetCollect(bool collcet)
    {
        iscollect = collcet;
    }

    public bool GetCollect()
    {
        return iscollect;
    }
}
