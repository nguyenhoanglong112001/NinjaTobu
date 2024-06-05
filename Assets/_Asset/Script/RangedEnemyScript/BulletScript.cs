using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject firepoint;
    [SerializeField] private Rigidbody2D rig2d;
    [SerializeField] private PowerCheck powercheck;
    [SerializeField] private float speed;

    private void Start()
    {
        powercheck = GameObject.FindWithTag("Player").GetComponent<PowerCheck>();
        firepoint = GameObject.FindWithTag("FirePoint");
        Vector3 direction = firepoint.transform.position - transform.position;
        rig2d.velocity = new Vector2(direction.x, direction.y).normalized * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Map"))
        {
            return;
        }
        Destroy(gameObject);
        if(collision.CompareTag("Player"))
        {
            if(powercheck.BulletProofCheck())
            {
                return;
            }
            else
            {
                collision.GetComponent<PlayerControll>().Death();
            }
        }
    }
}
