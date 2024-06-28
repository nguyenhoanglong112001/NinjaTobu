using UnityEngine;
using TigerForge;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject firepoint;
    [SerializeField] private Rigidbody2D rig2d;
    [SerializeField] private PowerCheck powercheck;
    [SerializeField] private float speed;
    private Vector3 direction;

    private void Start()
    {
        powercheck = GameObject.FindWithTag("Player").GetComponent<PowerCheck>();
        firepoint = GameObject.FindWithTag("FirePoint");
        if (firepoint != null)
        {
            direction = firepoint.transform.position - transform.position;
            rig2d.velocity = new Vector2(direction.x, direction.y).normalized * speed * Time.deltaTime;
        }
    }

    private void Update()
    {
    }

    private void OnEnable()
    {
        if (firepoint != null)
        {
            direction = firepoint.transform.position - transform.position;
            rig2d.velocity = new Vector2(direction.x, direction.y).normalized * speed * Time.deltaTime;
            Debug.Log("direction = " + direction);
            Debug.Log("firepoint = " + firepoint.transform.position);
            Debug.Log("Object point = " + transform.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Map"))
        {
            return;
        }
        //Destroy(gameObject);
        gameObject.SetActive(false);
        if (collision.CompareTag("Player"))
        {
            if(powercheck.BulletProofCheck())
            {
                return;
            }
            else
            {
                //collision.GetComponent<PlayerControll>().Death();
            }
        }
    }
}
