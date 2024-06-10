using UnityEngine;

public class EnemyDetection :MonoBehaviour
{
    [SerializeField] private Animator anaima;
    [SerializeField] private Transform attackpoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask targetlayer;
    [SerializeField] private int maxattack;
    [SerializeField] private FlipEnemy flipcom;
    [SerializeField] private GameObject Vision;
    [SerializeField] private int delaytimeatk;
    private float timer;
    private int attackcount;
    private bool isattack;

    private void Start()
    {
        attackcount = maxattack;
    }
    private void Update()
    {
        Detection();
        EndAttack();
        if(isattack)
        {
            timer += Time.deltaTime;
            if (timer > delaytimeatk)
            {
                isattack = false;
                timer = 0;
            }
        }
    }

    private void Detection()
    {
        var hit = Physics2D.CircleCast(attackpoint.position, radius, transform.position, 0.0f, targetlayer);
        if(hit.collider != null)
        {
            if(attackcount > 0 && !isattack)
            {
                anaima.SetTrigger("Attack");
                attackcount -= 1;
                isattack = true;
            }
        }
    }

    private void EndAttack()
    {
        if (attackcount <= 0)
        {
            anaima.SetBool("EndAtk", true);
            flipcom.enabled = false;
            Vision.SetActive(false);
            InvokeRepeating(nameof(ResetAttack), 5.0f, 0.0f);
        }
    }

    private void ResetAttack()
    {
        anaima.SetBool("EndAtk", false);
        attackcount = maxattack;
        flipcom.enabled = true;
        Vision.SetActive(true);
        CancelInvoke();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(attackpoint.position, radius);
    }
}
