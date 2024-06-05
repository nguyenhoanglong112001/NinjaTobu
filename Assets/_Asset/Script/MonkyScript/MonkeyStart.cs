using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyStart : MonoBehaviour
{
    [SerializeField] private Transform[] StartPoint;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private float speed;
    private int r;
    // Start is called before the first frame update
    void Start()
    {
        r = Random.Range(0, 2);
        if(r==0)
        {
            sprite.flipX = true;
        }
        else if(r==1)
        {
            sprite.flipX = false;
        }
        StartCoroutine(StartMove());
        animator.SetTrigger("Jump");
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator StartMove()
    {
        while(Vector2.Distance(transform.position, StartPoint[r].position)>0.1f)
        {
            transform.position = Vector2.Lerp(transform.position, StartPoint[r].position, speed * Time.deltaTime);
            yield return null;
        }
    }
}
