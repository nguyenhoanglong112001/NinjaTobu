using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rig2d;
    [SerializeField] private float knockforce;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyAttack"))
        {
            Vector2 pushdirection = transform.position - collision.transform.position;

            pushdirection.Normalize();

            rig2d.AddForce(pushdirection * knockforce, ForceMode2D.Impulse);
        }
    }

    public void SetKnockBack(float knockback)
    {
        knockforce = knockback;
    }
}
