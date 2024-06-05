using UnityEngine;

public class EnemyDetection :MonoBehaviour
{
    [SerializeField] private Animator anaima;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anaima.SetTrigger("Attack");
        }
    }
}
