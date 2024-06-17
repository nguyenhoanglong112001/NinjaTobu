using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyATkClimb : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rig2d;
    [SerializeField] private float speed;
    [SerializeField] private Transform player;
    [SerializeField] private float distance;
    [SerializeField] private MonkeyWallCheck wallcheck;
    [SerializeField] private MonkeyAttack mkatk;
    [SerializeField] private Transform ground;
    void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        ground = GameObject.FindWithTag("SpikeGround").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Climb();
    }

    private void Climb()
    {
        if (player != null)
        {
            var currentdistance = Vector2.Distance(transform.position, ground.position);
            if (wallcheck.GetCheck())
            {
                if (distance - currentdistance > 0.1f && !mkatk.GetAttack() || player.transform.position.y > transform.position.y)
                {
                    rig2d.velocity = Vector2.up * speed * Time.deltaTime;
                    animator.SetBool("IsClimb", true);
                }
                else if (distance - currentdistance < 0.1f || mkatk.GetAttack())
                {
                    Debug.Log(mkatk.GetAttack());
                    rig2d.velocity = Vector2.zero;
                    animator.SetBool("IsClimb", false);
                }
            }
        }
        if(player == null)
        {
            rig2d.velocity = Vector2.zero;
        }
    }
}

