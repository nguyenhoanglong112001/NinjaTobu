using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyAttack : MonoBehaviour
{
    [SerializeField] private Transform[] Sideposition;
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform Monkey;
    private bool isenemyleft;
    private bool isenemyright;
    private bool isatk;

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
        if(collision.CompareTag("Enemy"))
        {
            SetAttack(true);
            if (Vector2.Distance(Monkey.position,Sideposition[0].position)<0.1f)
            {
                animator.SetTrigger("Jump");
                isenemyleft = true;
                isenemyright = false;
            }
            else if (Vector2.Distance(Monkey.position, Sideposition[1].position) < 0.1f)
            {
                animator.SetTrigger("Jump");
                isenemyleft = false;
                isenemyright = true;
            }
        }
    }

    private void JumptoPoint()
    {
        if (isenemyright && !isenemyleft)
        {
            Monkey.position = Vector2.Lerp(Monkey.position, Sideposition[0].position, speed * Time.deltaTime);
        }
        else if (!isenemyright && isenemyleft)
        {
            Monkey.position = Vector2.Lerp(Monkey.position, Sideposition[1].position, speed * Time.deltaTime);
        }
    }

    public void SetAttack(bool atk)
    {
        isatk = atk;
    }

    public bool GetAttack()
    {
        return isatk;
    }

    //IEnumerator JumptoPoint(Transform target)
    //{
    //    Monkey.position = Vector2.Lerp(Monkey.position, target.position, speed * Time.deltaTime);
    //    yield return null;
    //}
}
