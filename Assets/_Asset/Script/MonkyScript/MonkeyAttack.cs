using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyAttack : MonoBehaviour
{
    [SerializeField] private Transform[] Sideposition;
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform Monkey;
    [SerializeField] private Rigidbody2D mkrigi;
    [SerializeField] private GameObject point;
    private int kills;
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
        point = GameObject.Find("Scorenum");
        JumptoPoint();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            SetAttack(true);
            mkrigi.velocity = Vector2.zero;
            Debug.Log(mkrigi.velocity);
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
            collision.GetComponent<EnemyDeath>().Death();
            kills += 1;
            if (point != null)
            {
                point.GetComponent<GamePoint>().AddScore(10);
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

    public int MKkill()
    {
        return kills;
    }
    //IEnumerator JumptoPoint(Transform target)
    //{
    //    Monkey.position = Vector2.Lerp(Monkey.position, target.position, speed * Time.deltaTime);
    //    yield return null;
    //}
}
